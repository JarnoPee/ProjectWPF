using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Project_DAL.DomainModels
{
    [Table("Customers")]
    public class Customer : BasisModel.Basisklasse
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        [MaxLength(30)]
        public string Achternaam { get; set; }

        [Required]
        [MaxLength(20)]
        public string Voornaam { get; set; }

        [Required]
        [MaxLength(150)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Required]
        public string Land { get; set; }

        [Required]
        public string Straat { get; set; }

        [Required]
        public string Huisnummer { get; set; }

        [Required]
        public string Postcode { get; set; }

        [Required]
        public string Gemeente { get; set; }

        [Required]
        public string Paswoord { get; set; }
        [Required]
        [DefaultValue("False")]
        public bool IsAdmin { get; set; }


        //Navigatieproperties
        public ICollection<LocationCustomer> LocationCustomers { get; set; }
    }
}
