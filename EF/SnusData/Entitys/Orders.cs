using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace SnusData.Entitys
{

    public partial class Orders
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        
        
        public string Create_Date { get; set; }
        public int UserId { get; set; }
        public Users User { get; set; }
        public virtual ICollection<Order_Item> Order_Items { get; set; }
    }
}
