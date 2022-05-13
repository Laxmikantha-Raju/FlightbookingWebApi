using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public partial class BookingPassengerDetails
    {
        //public TblBooking[] tblBookings { get; set; }

        //public TblPassenger[] tblPassengers { get; set; }
        public virtual ICollection<TblBooking> tblBookings { get; set; }
        public virtual ICollection<TblPassenger> tblPassengers { get; set; }


    }
}
