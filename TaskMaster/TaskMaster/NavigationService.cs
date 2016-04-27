using System.Threading.Tasks;
using System;

namespace TaskMaster
{
    public enum AppPage
    {
        TasksPage,
    }

    public class NavigationService
    {
        public async Task GotoPageAsync(AppPage page)
        {
            var nav = App.Current.MainPage.Navigation;

            switch (page)
            {
                case AppPage.TasksPage:
                    if (App.Current == null) return; 
                    await nav.PushAsync(new TasksPage(new TasksPageViewModel(App.TaskList)), true);
                    return;

                default:
                    throw new ArgumentOutOfRangeException("Attempt to navigate to invalid page");
            }
        }
    }
}