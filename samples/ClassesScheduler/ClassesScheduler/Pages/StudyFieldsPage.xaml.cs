using ClassesScheduler.ViewModels;
using Xamarin.Forms;

namespace ClassesScheduler.Pages
{
    public partial class StudyFieldsPage : ContentPage
    {
        public StudyFieldsPage()
        {
            InitializeComponent();
            BindingContext = new StudyFieldsViewModel(Navigation);            
        }
    }
}
