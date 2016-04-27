using Xamarin.Forms;

namespace TaskMaster
{
    public partial class TasksPage : ContentPage
    {
        public TasksPage(TasksPageViewModel tpvm)
        {
            InitializeComponent();
            BindingContext = tpvm;
        }
    }
}
