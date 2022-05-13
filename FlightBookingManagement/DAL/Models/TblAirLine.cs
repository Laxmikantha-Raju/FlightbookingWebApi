using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class TblAirLine
    {
        public int AirlineNo { get; set; }
        public string AirlineName { get; set; }
        public string AirlineUploadLogo { get; set; }
        public string AirlineContactNo { get; set; }
        public string AirlineContactAddress { get; set; }
        public int? AirlineCreatedBy { get; set; }
        public DateTime? AirlineCreatedOn { get; set; }
        public int? AirlineUpdatedBy { get; set; }
        public DateTime? AirlineUpdatedOn { get; set; }
        public string AirlineIsActiveYn { get; set; }
    }
}
