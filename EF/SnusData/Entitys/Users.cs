using SnusData.Attributes;
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
        [Filter(FilterFlag.ContainsFilterIn, "id")]
        public int Id {get;set;}

        [Required]
        
        [Filter(FilterFlag.ContainsFilterIn, "firstName")]
        public string FirstName { get; set; }

        
        
        [Filter(FilterFlag.ContainsFilterIn, "secondName")]
        public string SecondName { get; set; }

        
        
        [Filter(FilterFlag.IntervalStart, "ageStart")]
        [Filter(FilterFlag.IntervalEnd, "ageEnd")]
        public int Age { get; set; }

        [Filter(FilterFlag.Equal, "role")]
        public virtual Roles Role { get; set; }

        
        [Filter(FilterFlag.ContainsFilterIn, "sex")]
        public string Sex { get; set; }

       
        
        [Filter(FilterFlag.ContainsFilterIn, "email")]
        public string Email { get; set; }

   
        
        [Filter(FilterFlag.ContainsFilterIn, "password")]
        public string Password { get; set; }

        public virtual Locations Location { get; set; }

        public virtual Orders CurrentOrder { get; set; }

        public virtual ICollection<Coments> Coments { get; set; }

        public virtual ICollection<Orders> OrderHistory { get; set; }

    }
}
