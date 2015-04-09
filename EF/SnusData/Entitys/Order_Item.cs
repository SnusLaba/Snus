using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace SnusData.Entitys
{
   

    public partial class Order_Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public long OrderId { get; set; }
        public virtual Orders Order { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Count { get; set; }
        public virtual decimal Past_Price { get; set; }        
    }
}
