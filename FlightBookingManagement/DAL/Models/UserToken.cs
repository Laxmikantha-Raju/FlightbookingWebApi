using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class UserToken
    {
        public virtual ICollection<TblUserDetail> ICTblUserDetails { get; set; }
        public virtual Tokens ICToken { get; set; }

    }
}
