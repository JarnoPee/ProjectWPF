using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_DAL.DomainModels
{
    [Table("Locations")]
    public class Location
    {
        [Key]
        public int LocationID { get; set; }

        [Required]
        public string Naam { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal? Prijs { get; set; }

        [Required]
        public string Land { get; set; }

        [Required]
        public string Stad { get; set; }

        [Required]
        public string Straat { get; set; }

        [Required]
        public string Huisnummer { get; set; }

        [Required]
        public string Diepte { get; set; }

        [Required]
        public string Geschiktheid { get; set; }

        //navigatieproperties
        public ICollection<LocationCustomer> LocationCustomers { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Description> Descriptions { get; set; }
        public ICollection<Preview> Previews { get; set; }
    }
}
