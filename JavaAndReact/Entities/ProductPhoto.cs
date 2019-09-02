using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JavaAndReact.Entities
{
    [Table("tblProductsPhotos")]
    public class ProductPhoto
    {
        public long Id { get; set; }

        [Required, StringLength(255)]
        public string Name { get; set; }

        [ForeignKey("Product")]
        public long ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
