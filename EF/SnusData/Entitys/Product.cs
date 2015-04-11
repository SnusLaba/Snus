using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace SnusData.Entitys
{

    public partial class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Description { get; set; }

        public int? Count { get; set; }

        public virtual ProductType Type { get; set; }
        public decimal Price { get; set; }
        [StringLength(10)]
        public string Nicotine { get; set; }
        public int? Rating { get; set; }
        public virtual ICollection<Coments> Coments { get; set; }

        public virtual ICollection<File> File { get; set; }
    }
}
