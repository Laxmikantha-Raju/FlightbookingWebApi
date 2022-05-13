using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class TblUserDetail
    {
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmailid { get; set; }
        public string UserPassword { get; set; }
        public string UserPhoneNo { get; set; }
        public int? UserCreatedBy { get; set; }
        public DateTime? UserCreatedOn { get; set; }
        public int? UserUpdatedBy { get; set; }
        public DateTime? UserUpdatedOn { get; set; }
        public int? UserIsDeleted { get; set; }
        public string UserIsAdmin { get; set; }
    }
}
