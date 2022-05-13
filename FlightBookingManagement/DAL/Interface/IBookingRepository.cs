using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;

namespace DAL.Interface
{
    public interface IBookingRepository
    {
        public IEnumerable<BookingPassengerDetails> GetBookingDetail();
        public string AddPassengerBookingDetail(BookingPassengerDetails tbl);
        public void CancelBooking(string pnr);

        public BookingPassengerDetails GetBookingDetailFromPNR(string pnr);
        
        public BookingPassengerDetails GetUserHistory(string emailId);

        public void SaveChanges();
    }
}
