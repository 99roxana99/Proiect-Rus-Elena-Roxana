using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect.Models
{
    public class Car
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength=3)]
        [Display(Name="Car Name")]
        public string Model { get; set; }
        public string Mark { get; set; }
        [Range(1,50000)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime LaunchingDate { get; set; }
        public int ProducerID { get; set; }
        public Producer Producer{ get; set; }

        public ICollection<CarCategory> CarCategories { get; set; }
    }
}
