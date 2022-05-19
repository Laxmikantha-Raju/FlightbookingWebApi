using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interface
{
    public interface IBookingRepository
    {
        public ICollection<TblBooking> GetBookingDetail();
        public string AddPassengerBookingDetail(BookingPassengerDetails tbl);
        public void CancelBooking(string pnr);
        public void CancelById(int id);

        public BookingPassengerDetails GetBookingDetailFromPNR(string pnr);
        
        public BookingPassengerDetails GetUserHistory(string emailId);

        public void SaveChanges();

        Task<List<Discount>> GetDiscountList();
    }
}
