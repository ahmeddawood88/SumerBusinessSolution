﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SumerBusinessSolution.Data;
using SumerBusinessSolution.Models;
using SumerBusinessSolution.Utility;

namespace SumerBusinessSolution.Inventory.Warehouses
{
  
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)                                               
        {
            _db = db;
        }
        [BindProperty]
        public WhType WhType { get; set; }

        public IList<Warehouse> Warehouse { get; set; }
        public void OnGet()
        {
            WhType = _db.WhType.FirstOrDefault();
            Warehouse = _db.Warehouse.Include(wh => wh.WhType).ToList();
           

        }
    }
}