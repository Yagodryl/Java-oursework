using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JavaAndReact.Entities
{
    [Table("tblClients")]
    public class ClientProfile: ProfileBase
    {
        [Required, StringLength(250) ]
        public string Address { get; set; }

        public virtual ClientCard Card { get; set; }

        public virtual ICollection<ClientOrder> ClientOrders { get; set; }
    }
}
