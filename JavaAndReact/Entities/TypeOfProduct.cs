using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JavaAndReact.Entities
{
    [Table("tblTypeOfProducts")]
    public class TypeOfProduct
    {
        public long Id { get; set; }
        [Required, StringLength(75)]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
