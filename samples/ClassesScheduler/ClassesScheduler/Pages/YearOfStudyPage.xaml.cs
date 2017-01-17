using ClassesScheduler.ViewModels;
using Xamarin.Forms;

namespace ClassesScheduler.Pages
{
    public partial class YearOfStudyPage : ContentPage
    {
        public YearOfStudyPage()
        {
            InitializeComponent();
            BindingContext = new YearOfStudyViewModel(Navigation);            
        }
    }
}
