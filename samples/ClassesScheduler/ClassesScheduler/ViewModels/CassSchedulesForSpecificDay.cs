using ClassesScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesScheduler.ViewModels
{
    public class CassSchedulesForSpecificDay
    {
        public String NameOfDay { get; set; }
        public ICollection<ClassSchedule> Classes { get; set; }
    }
}
