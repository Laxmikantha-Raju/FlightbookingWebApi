using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly FlightTicketBookingDBContext _BookingContext;
        public BookingRepository(FlightTicketBookingDBContext context)
        {
            _BookingContext = context;
        }

        public string AddPassengerBookingDetail(BookingPassengerDetails tbl)
        {
            Random generateRandom = new Random();
            string strBookedPNR = "";
            if (tbl != null)
            {

                foreach (var booking in tbl.tblBookings)
                {
                    strBookedPNR = generateRandom.Next(1, 100) + booking.BookingFlightNumber;
                    booking.BookingPnr = strBookedPNR;
                    _BookingContext.TblBookings.Add(booking);
                    SaveChanges();

                    foreach (var passengers in tbl.tblPassengers)
                    {
                        passengers.PassengerPnr = strBookedPNR;
                        _BookingContext.TblPassengers.Add(passengers);
                        SaveChanges();
                    }
                }
            }
            return strBookedPNR;
        }

        public void CancelBooking(string pnr)
        {
            var pnrdetail = _BookingContext.TblBookings.Where(x => x.BookingPnr.ToLower() == pnr.ToLower()).ToList(); ;
            if (pnrdetail != null)
            {
                foreach (var cancel in pnrdetail)
                {
                    var persondetail = _BookingContext.TblPassengers.Where(x => x.PassengerPnr == cancel.BookingPnr).ToList();
                    cancel.BookingIsActiceYn = "N";
                    _BookingContext.TblBookings.Update(cancel);
                    SaveChanges();
                    foreach (var passenger in persondetail)
                    {
                        passenger.PassengerIsActiceYn = "N";
                        _BookingContext.TblPassengers.Update(passenger);
                        SaveChanges();
                    }
                }
            }
        }

        public BookingPassengerDetails GetBookingDetailFromPNR(string pnr)
        {

            ICollection<TblBooking> tblbooking = _BookingContext.TblBookings.Where(x => x.BookingPnr.ToLower() == pnr.ToLower() && x.BookingIsActiceYn == "Y").ToList<TblBooking>();
            ICollection<TblPassenger> tblpassenger = _BookingContext.TblPassengers.Where(x => x.PassengerPnr.ToLower() == pnr.ToLower() && x.PassengerIsActiceYn == "Y").ToList<TblPassenger>();
            BookingPassengerDetails bookingPassengerDetails = new BookingPassengerDetails();
            bookingPassengerDetails.tblBookings = tblbooking;
            bookingPassengerDetails.tblPassengers = tblpassenger;
            var result = bookingPassengerDetails;
            return result;
        }

        public void SaveChanges()
        {
            _BookingContext.SaveChanges();
        }

        IEnumerable<BookingPassengerDetails> IBookingRepository.GetBookingDetail()
        {
            return (IEnumerable<BookingPassengerDetails>)_BookingContext.TblBookings.ToList();
        }

        public BookingPassengerDetails GetUserHistory(string emailId)
        {
            BookingPassengerDetails bookingPassengerDetails = new BookingPassengerDetails();
            var result = bookingPassengerDetails;
            ICollection<TblBooking> tblbooking = _BookingContext.TblBookings.Where(x => x.BookingEmailId.ToLower() == emailId.ToLower() && x.BookingIsActiceYn == "Y").ToList<TblBooking>();
            if (tblbooking != null)
            {
                bookingPassengerDetails.tblBookings = tblbooking;
                foreach (var booking in tblbooking)
                {
                    ICollection<TblPassenger> persondetail = _BookingContext.TblPassengers.Where(x => x.PassengerPnr == booking.BookingPnr && x.PassengerIsActiceYn == "Y").ToList();
                    bookingPassengerDetails.tblPassengers = persondetail;
                }
                result = bookingPassengerDetails;
            }
            return result;
        }
    }
}
