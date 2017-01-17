using ClassesScheduler.ViewModels;
using Xamarin.Forms;

namespace ClassesScheduler.Pages
{
    public partial class SchedulePage : CarouselPage
    {
        public SchedulePage()
        {   
            InitializeComponent();
            var viewModel = new ScheduleViewModel();
            BindingContext = viewModel;
            ItemsSource = viewModel.Days;
        }
    }
}
