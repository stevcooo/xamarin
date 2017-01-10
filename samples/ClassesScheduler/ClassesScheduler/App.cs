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

        static App _instance;
        public static App Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new App();
                }
                return _instance;
            }
        }

        private ScheduleParametars _sheduleParametars;
        public ScheduleParametars ScheduleParametars
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
