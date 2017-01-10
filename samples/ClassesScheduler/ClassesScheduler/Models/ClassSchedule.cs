using ClassesScheduler.Enums;

namespace ClassesScheduler.Models
{
    public class ClassSchedule
    {
        public int Id { get; set; }
        public string ClassromCode { get; set; }

        public int FromHour { get; set; }

        public int ToHour { get; set; }

        public WeekDay WeekDay { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public int SemestarScheduleId { get; set; }
    }
}
