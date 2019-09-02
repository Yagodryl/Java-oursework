using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JavaAndReact.Entities
{
    [Table("tblClientOrders")]
    public class ClientOrder
    {
        public long Id { get; set; }
        [Required, StringLength(8)]
        public string NuberOfOrder { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }

        public ICollection<Product> Products { get; set; }

        [ForeignKey("Client")]
        public long ClientId { get; set; }
        public virtual ClientProfile Client { get; set; }
    }
}
