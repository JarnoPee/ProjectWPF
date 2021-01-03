using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DAL.DomainModels 
{
    [Table("LocationCustomers")]
    public class LocationCustomer : BasisModel.Basisklasse
    {
        [Key]
        public int LocationCustomerID { get; set; }
        
        [Index("IX_LocationIDCustomerID", 1, IsUnique = true)]
        public int LocationID { get; set; }

        [Index("IX_LocationIDCustomerID", 2, IsUnique = true)]
        public int CustomerID { get; set; }

        //Navigatieproperties
        public Location Location { get; set; }
        public Customer Customer { get; set; }
    }
}
