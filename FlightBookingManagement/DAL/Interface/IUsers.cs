using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;

namespace DAL.Interface
{
    public interface IUsers
    {
        IEnumerable<TblUserDetail> GetUsers();
        TblUserDetail GetUserByID(int User);
        void InsertUsers(TblUserDetail tblUserDetail);
        //void DeleteUser(int UserId);
        //void UpdateUser(TblUserDetail tblUserDetail);
        void Save();
    }

}
