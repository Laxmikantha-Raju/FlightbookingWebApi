using DAL.Interface;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public class UsersRepository : IUsers
    {
        private readonly FlightTicketBookingDBContext _dbContext;
        public UsersRepository(FlightTicketBookingDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        //public void DeleteUser(int UserId)
        //{
        //    var product = _dbContext.TblUserDetails.Find(UserId);
        //    _dbContext.TblUserDetails.Remove(product);
        //    Save();
        //}

        public TblUserDetail GetUserByID(int user)
        {
            return _dbContext.TblUserDetails.Find(user);
        }

        public IEnumerable<TblUserDetail> GetUsers()
        {
            return _dbContext.TblUserDetails.ToList();
        }

        public void InsertUsers(TblUserDetail userDetail)
        {
            _dbContext.TblUserDetails.Add(userDetail);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        //public void UpdateUser(TblUserDetail user)
        //{
        //    _dbContext.Entry(user).State = EntityState.Modified;
        //    Save();
        //}
    }
}
