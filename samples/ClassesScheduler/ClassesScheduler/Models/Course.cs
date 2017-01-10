using ClassesScheduler.Enums;

namespace ClassesScheduler.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsMandatorySubject { get; set; }

        public int NumberOfCredits { get; set; }

        public Semester SemesterType { get; set; }

        public int ProffesorId { get; set; }

        public virtual Proffesor Proffesor { get; set; }
    }
}
