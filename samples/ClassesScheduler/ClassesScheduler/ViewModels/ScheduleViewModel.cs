using ClassesScheduler.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ClassesScheduler.ViewModels
{
    public class ScheduleViewModel
    {
        public ScheduleViewModel()
        {
            InitializeDays();
            DetectSemester();
            GetSchedule();
        }

        public Course c = new Course();
        public SemestarSchedule ss { get; set; }

        private ICollection<CassSchedulesForSpecificDay> _days;
        public ICollection<CassSchedulesForSpecificDay> Days
        {
            get
            {
                if (_days == null)
                    _days = new ObservableCollection<CassSchedulesForSpecificDay>();
                return _days;
            }
        }
                
        private void InitializeDays()
        {
            CassSchedulesForSpecificDay csfsd = new CassSchedulesForSpecificDay();
            csfsd.NameOfDay = "Monday";
            Days.Add(csfsd);

            csfsd = new CassSchedulesForSpecificDay();
            csfsd.NameOfDay = "Tuesday";
            Days.Add(csfsd);

            csfsd = new CassSchedulesForSpecificDay();
            csfsd.NameOfDay = "Wednesday";
            Days.Add(csfsd);

            csfsd = new CassSchedulesForSpecificDay();
            csfsd.NameOfDay = "Thursday";
            Days.Add(csfsd);

            csfsd = new CassSchedulesForSpecificDay();
            csfsd.NameOfDay = "Friday";
            Days.Add(csfsd);
        }
        private void DetectSemester()
        {
            App.ScheduleParametars.Semester = new KeyValue();
            var month = DateTime.Now.Month;
            if (month < 6)
                App.ScheduleParametars.Semester.Key = "Summer";
            else
                App.ScheduleParametars.Semester.Key = "Winter";
        }
        private void GetSchedule()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://classesschedulerapi.kostoski.com/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Task.Run(async () =>
                {
                    HttpResponseMessage response = await client.GetAsync(String.Format("semestarSchedules/{0}/{1}/{2}", App.ScheduleParametars.StudyField.Key, App.ScheduleParametars.YearOfStudy, App.ScheduleParametars.Semester.Key));
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string jsonResponse = response.Content.ReadAsStringAsync().Result.Replace("'", "\'");
                        try
                        {
                            var result = JsonConvert.DeserializeObject<SemestarSchedule>(jsonResponse);
                            if (result != null)
                            {
                                ss = result;

                                if (ss != null)
                                {
                                    PopulateSchedule();
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }

                }).Wait();
            }
        }
        private void PopulateSchedule()
        {
            Days.Where(t => t.NameOfDay == "Monday").FirstOrDefault().Classes = ss.ClassSchedules.Where(t => t.WeekDay == Enums.WeekDay.Monday).OrderBy(t => t.FromHour).ToList();

            Days.Where(t => t.NameOfDay == "Tuesday").FirstOrDefault().Classes = ss.ClassSchedules.Where(t => t.WeekDay == Enums.WeekDay.Tuesday).OrderBy(t => t.FromHour).ToList();

            Days.Where(t => t.NameOfDay == "Wednesday").FirstOrDefault().Classes = ss.ClassSchedules.Where(t => t.WeekDay == Enums.WeekDay.Wednesday).OrderBy(t => t.FromHour).ToList();

            Days.Where(t => t.NameOfDay == "Thursday").FirstOrDefault().Classes = ss.ClassSchedules.Where(t => t.WeekDay == Enums.WeekDay.Thursday).OrderBy(t => t.FromHour).ToList();

            Days.Where(t => t.NameOfDay == "Friday").FirstOrDefault().Classes = ss.ClassSchedules.Where(t => t.WeekDay == Enums.WeekDay.Friday).OrderBy(t => t.FromHour).ToList();
        }
    }
}
