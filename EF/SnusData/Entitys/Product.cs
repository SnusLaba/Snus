using SnusData.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace SnusData.Entitys
{

    public partial class Product
    {
        [Filter(FilterFlag.ContainsFilterIn, "id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Filter(FilterFlag.ContainsFilterIn, "name")]
        public string Name { get; set; }

        [Filter(FilterFlag.ContainsFilterIn, "description")]
        
        public string Description { get; set; }

        [Filter(FilterFlag.IntervalStart, "countStart")]
        [Filter(FilterFlag.IntervalEnd, "countEnd")]
        public int Count { get; set; }

        [Filter(FilterFlag.Down, "type")]
        public virtual ProductType Type { get; set; }
        [Filter(FilterFlag.IntervalStart, "priceStart")]
        [Filter(FilterFlag.IntervalEnd, "priceEnd")]
        public decimal Price { get; set; }
        [Filter(FilterFlag.IntervalStart, "nicotineStart")]
        [Filter(FilterFlag.IntervalEnd, "nicotineEnd")]
        public int Nicotine { get; set; }
        [Filter(FilterFlag.IntervalStart, "ratingStart")]
        [Filter(FilterFlag.IntervalEnd, "ratingEnd")]
        public int Rating { get; set; }
        public virtual ICollection<Coments> Coments { get; set; }

        public virtual ICollection<File> File { get; set; }
    }
}
