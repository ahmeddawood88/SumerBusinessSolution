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

namespace SumerBusinessSolution.Pages.Inventory.Transactions
{
    [Authorize]
    public class ProdTransModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public IList<InvTransaction> InvTransList { get; set; }

        public ProdTransModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGet(int ProdId, int WhId , int? TransId)
        {
            if(TransId == null) // In this case it will be used by ProdInWhQty and WhProdQty Reports
            {
                InvTransList = await _db.InvTransaction.Include(tr => tr.ProdInfo).Include(tr => tr.Warehouse).Include(tr => tr.ApplicationUser)
              .Where(tr => tr.ProdId == ProdId & tr.WhId == WhId).ToListAsync();
            }
            else if(TransId != null) // in this case it will be used by InvTransactions Report
            {
                InvTransList = await _db.InvTransaction.Include(tr => tr.ProdInfo).Include(tr => tr.Warehouse).Include(tr => tr.ApplicationUser)
            .Where(tr => tr.Id == TransId).ToListAsync();
            }
          
            
            return Page();
        }
    }
}