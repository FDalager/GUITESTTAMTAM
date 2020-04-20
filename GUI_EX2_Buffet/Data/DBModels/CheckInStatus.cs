using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUI_EX2_Buffet.Data.DBModels
{
    public class CheckInStatus
    {
        public int NumberOfAdultsCheckedIn { get; set; }
        public int NumberOfChildsCheckedIn { get; set; }

        public BreakfastReservations BreakfastReservation { get; set; }

        public int Room { get; set; }

    }
}
