namespace TaskMaster
{
    public class TaskViewModel
    {
        public string Title { get { return _task.Title; } }
        public string Description { get { return _task.Description; } }
        public bool Done { get { return _task.Done; } }

        private TMTask _task;

        public TaskViewModel(TMTask task)
        {
            _task = task;
        }
    }
}