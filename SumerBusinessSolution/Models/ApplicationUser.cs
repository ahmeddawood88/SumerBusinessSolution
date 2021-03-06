﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SumerBusinessSolution.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
       [Display(Name ="اسم الموظف")]
        public string FirstName { set; get; }
        [Required]
       [Display(Name = "الاسم الاخير")]
        public string LastName { set; get; }
       
    }
}
