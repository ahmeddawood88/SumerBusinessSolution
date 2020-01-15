﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SumerBusinessSolution.Models
{
    public class IncomingGood
    {
        public int Id { get; set; }

       //[Required]
        public int? WhId { get; set; }

       // [Required]
        public int? ProdId { get; set; }
    
        [Required]
        public double Qty { get; set; }
        public string UOM { get; set; }
        public string Note { get; set; }

        [Required]
        public DateTime CreatedDateTime { get; set; }
        [Required]
        public string CreatedById { get; set; }

        [ForeignKey("WhId")]
        public virtual Warehouse Warehouse { get; set; }

        [ForeignKey("ProdId")]
        public virtual ProdInfo ProdInfo { get; set; }
        [ForeignKey("CreatedById")]
        public virtual ApplicationUser ApplicationUser { get; set; }



  

    }
}