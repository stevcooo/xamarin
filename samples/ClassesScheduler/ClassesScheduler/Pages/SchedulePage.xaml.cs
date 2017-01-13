using ClassesScheduler.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ClassesScheduler.Pages
{
    public partial class SchedulePage : CarouselPage
    {
        public SchedulePage()
        {
            Title = "Schedule";
            NavigationPage.SetHasBackButton(this, true);
            InitializeComponent();
            var viewModel = new ScheduleViewModel();
            BindingContext = viewModel;
            ItemsSource = viewModel.Days;
        }
    }
}
