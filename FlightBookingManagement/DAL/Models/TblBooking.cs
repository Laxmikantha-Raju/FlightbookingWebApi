using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class TblBooking
    {
        public int BookingId { get; set; }
        public string BookingName { get; set; }
        public string BookingEmailId { get; set; }
        public int? BookingNoOfSeatBook { get; set; }
        public int? BookingPassengerId { get; set; }
        public string BookingMeal { get; set; }
        public string BookingSeatNo { get; set; }
        public string BookingFlightNumber { get; set; }
        public string BookingPnr { get; set; }
        public string BookingIsActiceYn { get; set; }
        public int? BookingCreatedBy { get; set; }
        public DateTime? BookingCreatedOn { get; set; }
        public int? BookingUpdatedBy { get; set; }
        public DateTime? BookingUpdatedOn { get; set; }
    }
}
