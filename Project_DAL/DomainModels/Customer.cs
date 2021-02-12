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

        [Required(ErrorMessage = "Achternaam is required")]
        [MaxLength(30)]
        public string Achternaam { get; set; }

        [Required(ErrorMessage = "Voornaam is required")]
        [MaxLength(20)]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(150)]
        [Index(IsUnique = true)]
        [EmailAddress(ErrorMessage = "Email Address is Invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Land is required")]
        public string Land { get; set; }

        [Required(ErrorMessage = "Straat is required")]
        public string Straat { get; set; }

        [Required(ErrorMessage = "Huisnummer is required")]
        public string Huisnummer { get; set; }

        [Required(ErrorMessage = "Postcode is required")]
        public string Postcode { get; set; }

        [Required(ErrorMessage = "Gemeente is required")]
        public string Gemeente { get; set; }

        [Required(ErrorMessage = "Wachtwoord is required")]
        public string Paswoord { get; set; }
        [Required]
        [DefaultValue("False")]
        public bool IsAdmin { get; set; }


        //Navigatieproperties
        public ICollection<LocationCustomer> LocationCustomers { get; set; }
    }
}
