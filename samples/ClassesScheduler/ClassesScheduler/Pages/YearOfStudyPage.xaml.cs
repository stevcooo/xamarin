using ClassesScheduler.ViewModels;

using Xamarin.Forms;

namespace ClassesScheduler.Pages
{
    public partial class YearOfStudyPage : ContentPage
    {
        public YearOfStudyPage()
        {
            //Title = "Year of study";
            //NavigationPage.SetBackButtonTitle(this, "Back");
            //NavigationPage.SetHasBackButton(this, true);
            InitializeComponent();
            BindingContext = new YearOfStudyViewModel(Navigation);            
            
        }

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            Navigation.PopAsync();
            return true;
        }
    }
}
