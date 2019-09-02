using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JavaAndReact.Entities
{
    public abstract class ProfileBase
    {
        [Key, ForeignKey("User")]
        public long Id { get; set; }

        [Required, StringLength(75)]
        public string FirstName { get; set; }

        [Required, StringLength(75)]
        public string MiddleName { get; set; }

        [Required, StringLength(75)]
        public string LastName { get; set; }

        /// <summary>
        /// Фото користувача
        /// </summary>
        [StringLength(150)]
        public string Image { get; set; }

        public virtual DbUser User { get; set; }
    }
}
