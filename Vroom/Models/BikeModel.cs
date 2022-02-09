using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Vroom.Models
{
    public class BikeModel
    {      
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Int64  BikeModelId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ModelName { get; set; }
        public string Description { get; set; }
    }
}
