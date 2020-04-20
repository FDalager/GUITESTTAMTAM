using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUI_EX2_Buffet.Data.DBModels
{
    public class BreakfastReservations
    {
        public int Room { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChilds { get; set; }
        public DateTime Date { get; set; }

        public CheckInStatus CheckInStatuses { get; set; }
    }
}
