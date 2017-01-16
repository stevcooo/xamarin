using ClassesScheduler.Models;
using ClassesScheduler.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ClassesScheduler
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new StudyFieldsPage());            
        }        

        private static ScheduleParametars _sheduleParametars;
        public static ScheduleParametars ScheduleParametars
        {
            get
            {
                if (_sheduleParametars == null)
                    _sheduleParametars = new ScheduleParametars();
                return _sheduleParametars;
            }
            set
            {
                _sheduleParametars = value;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
