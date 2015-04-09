using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace SnusData.Entitys
{
   

    public partial class Coments
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int User_Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Text { get; set; }

        public int Products_Id { get; set; }

        public virtual Product Product { get; set; }

        public virtual Users Users { get; set; }
    }
}
