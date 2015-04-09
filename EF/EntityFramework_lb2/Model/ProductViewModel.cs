using SnusData.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_lb2.Model
{
    public class ProductViewModel
    {
        public static Func<Product, ProductViewModel> Converter = x => new ProductViewModel
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Count = x.Count,
            Type = x.Type != null ? x.Type.Name : "<-none Type->",
            Nicotine = x.Nicotine,
            Rating = x.Rating
        };
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Count { get; set; }
        public string Type { get; set; }
        public string Nicotine { get; set; }
        public int? Rating { get; set; }
    }
}
