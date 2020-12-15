using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_DAL.DomainModels
{
    [Table("Categorys")]
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Naam { get; set; }

        //navigatieproperties
        public ICollection<Location> Locations { get; set; }


    }
}
