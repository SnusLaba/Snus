using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace SnusData.Entitys
{
    public partial class Users
    {
        public Users()
        {
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string FirstName { get; set; }

        
        [StringLength(10)]
        public string SecondName { get; set; }

        
        [StringLength(10)]
        public string Age { get; set; }

        public virtual Roles Role { get; set; }

        [StringLength(10)]
        public string Sex { get; set; }

       
        [StringLength(10)]
        public string Email { get; set; }

   
        [StringLength(10)]
        public string Password { get; set; }

        public virtual Locations Location { get; set; }

        public virtual Orders CurrentOrder { get; set; }

        public virtual ICollection<Coments> Coments { get; set; }

        public virtual ICollection<Orders> OrderHistory { get; set; }

    }
}
