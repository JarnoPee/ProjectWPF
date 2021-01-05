using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_DAL.DomainModels
{
    [Table("Previews")]
    public class Preview
    {
        [Key]
        public int PreviewID { get; set; }

        [Required]
        public string PreviewBeschrijving { get; set; }

        //navigatieproperties
        public ICollection<Location> Locations { get; set; }
    }
}
