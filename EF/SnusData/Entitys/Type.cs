using SnusData.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace SnusData.Entitys
{
    public class Type
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Filter(FilterFlag.ContainsFilterIn, "name")]
        
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
    public class FileType : Type
    {

    }
    public class ProductType : Type
    {

    }
    public class UserType : Type
    {

    }
}
