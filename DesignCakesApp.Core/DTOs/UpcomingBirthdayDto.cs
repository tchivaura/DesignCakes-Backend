using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignCakesApp.Core.DTOs
{
    public class UpcomingBirthdayDto
    {
        public string LovedOneName { get; set; }
        public DateTime NextBirthday { get; set; }
        public string DayOfWeek { get; set; }
        public int AgeTurning { get; set; }
        public int customerId { get; set; }

        public string Relationship { get; set; }
        public string gender { get; set; }
    }
}
