using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class TblPassenger
    {
        public int PassengerId { get; set; }
        public string PassengerPnr { get; set; }
        public string PassengerName { get; set; }
        public int? PassengerAge { get; set; }
        public string PassengerGender { get; set; }
        public string PassengerMealType { get; set; }
        public string PassengerSeatNo { get; set; }
        public decimal? PassengerPrice { get; set; }
        public string PassengerIsActiceYn { get; set; }
        public int? PassengerCreatedBy { get; set; }
        public DateTime? PassengerCreatedOn { get; set; }
        public int? PassengerUpdatedBy { get; set; }
        public DateTime? PassengerUpdatedOn { get; set; }
    }
}
