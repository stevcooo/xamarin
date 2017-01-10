using ClassesScheduler.Enums;
using System.Collections.Generic;

namespace ClassesScheduler.Models
{
    public class SemestarSchedule
    {
        public int Id { get; set; }
        public int Year { get; set; }

        public Semester SemesterType { get; set; }

        public string YearOfStudy { get; set; }

        public StudyField StudyField { get; set; }

        public List<ClassSchedule> ClassSchedules { get; set; }
    }
}
