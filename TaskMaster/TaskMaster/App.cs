using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;

using Xamarin.Forms;

namespace TaskMaster
{
    public class App : Application
    {
        public static List<TMTask> TaskList;
        private HomePage _homePage;

        public App()
        {
            // The root page of your application
            DependencyService.Register<NavigationService>();
            _homePage = new HomePage();
            var np = new NavigationPage(_homePage);
            MainPage = np;
        }

        protected override async void OnStart()
        {
            const string TaskCache = "tasks.json";
            var fh = DependencyService.Get<IFileHelper>();
            string jsonTasks="[]";

            // Handle when your app starts
            // TODO: TaskMasterServer API class 
            if (CrossConnectivity.Current.IsConnected)
            {
                // Download current task list and cache locally
                jsonTasks = await new HttpClient().GetStringAsync("http://ac0kg.ddns.us:6482/123/tasks");
                // TODO: error handling
                await fh.SaveLocalFileAsync(TaskCache, jsonTasks);
            } else
            {
                // Not connected, use the cached data
                var tasks = await fh.LoadLocalFileAsync(TaskCache);
                if (tasks == null)
                {
                    // No cached data
                    jsonTasks = "{\"tasks\":[{\"title\":\"samptitle\",\"description\":\"sample\",\"done\":false}]}";
                }
            }
            
            TaskList = JsonConvert.DeserializeObject<List<TMTask>>(jsonTasks);
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
