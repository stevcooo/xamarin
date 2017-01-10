using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesScheduler.Models
{
    public class ScheduleParametars
    {
        public KeyValue StudyField { get; set; }
        public KeyValue Semester { get; set; }
        public int Year { get; set; }
        public int YearOfStudy { get; set; }
    }
}
