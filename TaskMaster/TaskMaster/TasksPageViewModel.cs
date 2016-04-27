using System.Collections.Generic;
using System.Net.Http;

namespace TaskMaster
{
    public class TasksPageViewModel
    {
        public List<TaskViewModel> TasksViewModels { get; set; }

        public TasksPageViewModel(List<TMTask> taskList)
        {
            TasksViewModels = new List<TaskViewModel>();

            foreach (var task in taskList)
                TasksViewModels.Add(new TaskViewModel(task));
        }
    }
}
