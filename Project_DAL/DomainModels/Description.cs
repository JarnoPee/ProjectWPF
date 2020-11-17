﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Project_DAL.DomainModels
{
    [Table("Descriptions")]
    public class Description
    {
        [Key]
        public int DescriptionID { get; set; }

        [Required]
        public string Beschrijving { get; set; }

        //navigatieproperties
        public Location Location { get; set; }
    }
}