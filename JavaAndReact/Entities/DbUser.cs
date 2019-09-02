using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaAndReact.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class DbUser : IdentityUser<long>
    {
        public ICollection<DbUserRole> UserRoles { get; set; }
        public virtual ClientProfile Client { get; set; }
        public virtual SellerProfile Seller { get; set; }
    }
}
