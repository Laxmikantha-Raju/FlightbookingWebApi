using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class TblInventory
    {
        public string FlightNumber { get; set; }
        public int? FlightAirlineNo { get; set; }
        public string FlightFromPlace { get; set; }
        public string FlightToPlace { get; set; }
        public DateTime? FlightStartDateTime { get; set; }
        public DateTime? FlightEndDateTime { get; set; }
        public string FlighScheduleDays { get; set; }
        public string FlightInstrumentUsed { get; set; }
        public int? FlightBusinessClassSeat { get; set; }
        public int? FlightEconomyClassSeat { get; set; }
        public double? FlightTicketCost { get; set; }
        public int? FlightNoOfRows { get; set; }
        public int? FlightMeal { get; set; }
        public int? FlightCreatedBy { get; set; }
        public DateTime? FlightCreatedOn { get; set; }
        public int? FlightUpdatedBy { get; set; }
        public DateTime? FlightUpdatedOn { get; set; }
        public string FlightIsActiveYn { get; set; }
    }
}
