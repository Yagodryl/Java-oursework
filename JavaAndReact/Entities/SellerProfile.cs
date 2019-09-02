using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JavaAndReact.Entities
{
    [Table("tblSeller")]
    public class SellerProfile: ProfileBase
    {
        public SellerStorage Storage { get; set; }

    }
}
