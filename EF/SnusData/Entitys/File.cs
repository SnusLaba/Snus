using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace SnusData.Entitys
{
    
    [Table("File")]
    public partial class File
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        
        public string Path { get; set; }

        [Required]
        
        public string Name { get; set; }

        [Required]
        
        public string Description { get; set; }
        public int FileType_Id { get; set; }
        public FileType FileType { get; set; }
    }
}
