using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JavaAndReact.Entities
{
    [Table("tblClientCards")]
    public class ClientCard
    {
        [Key, ForeignKey("Client")]
        public long Id { get; set; }

        public virtual ICollection<Product> Products { get; set; }    
        
        public virtual ClientProfile Client { get; set; }
    }
}
