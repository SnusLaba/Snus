using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace SnusData.Entitys
{
    public partial class Locations
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Country_Id { get; set; }
        public virtual Country Country { get; set; }

        
        [StringLength(10)]
        public string Address { get; set; }

        [StringLength(10)]
        public string Telephone { get; set; }
    }
}
