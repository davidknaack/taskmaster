using Xamarin.Forms;

namespace TaskMaster
{
    public class HomePage : ContentPage
    {
        public bool IsStartButtonEnabled { get { return startBtn.IsEnabled; } set { startBtn.IsEnabled = value; } }

        private Button startBtn;

        public HomePage()
        {
            var al = new AbsoluteLayout();
            Content = al;

            var bg = new Image()
            {
                Source = ImageSource.FromResource("TaskMaster.Images.background.jpg"),
                Aspect = Aspect.AspectFill
            };
            al.Children.Add(bg, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.SizeProportional);

            startBtn = new Button(){Text = "Start"};
            startBtn.Clicked += async (a, b) =>
            {
                var nav = DependencyService.Get<NavigationService>();
                if (nav != null)
                    await nav.GotoPageAsync(AppPage.TasksPage);
            };
            al.Children.Add(startBtn, new Rectangle(0.5, 0.5, 150, 60), AbsoluteLayoutFlags.PositionProportional);

            //  NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
