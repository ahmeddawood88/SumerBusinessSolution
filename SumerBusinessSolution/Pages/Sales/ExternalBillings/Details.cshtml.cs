﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SumerBusinessSolution.Data;
using SumerBusinessSolution.Models;
using SumerBusinessSolution.Transactions;
using Microsoft.AspNetCore.Localization;
using System.ComponentModel.DataAnnotations;


namespace SumerBusinessSolution.Pages.Sales.ExternalBillings
{ 
    public class DetailsModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        private readonly ISalesTrans _SalesTrans;

        //private readonly IServiceScopeFactory _serviceScopeFactory;
        public DetailsModel(ApplicationDbContext db, ISalesTrans SalesTrans)
        {
            _db = db;
            _SalesTrans = SalesTrans;
        }
        [BindProperty]
        public ExternalBillHeader ExternalBillHeader { get; set; }

        [BindProperty]
        public ExternalBillItems ExternalBillItems { get; set; }

        public List<ExternalBillItems> ExternalBillItemsList { get; set; } 

        //[BindProperty]
        //public string CompanyName { get; set; }

        //[BindProperty]
        //public double PaidAmt { get; set; }


        //[BindProperty]
        //public int HeaderId { get; set; }

        public async Task<ActionResult> OnGet(int BhId)
        {
            //BillHeader = await _db.BillHeader.Include(h => h.Customer)
            //   .FirstOrDefaultAsync(h => h.Id == BhId);



            ExternalBillItemsList = await _db.ExternalBillItems.Include(bill=> bill.ExternalBillHeader).Include(bill=> bill.ExternalBillHeader.Customer).Include(bill=> bill.ExternalBillHeader.ApplicationUser).Where(bill => bill.ExternalBillHeader.Id == BhId).ToListAsync();
            if(ExternalBillItemsList.Count() > 0)
            {
                ExternalBillHeader = ExternalBillItemsList[0].ExternalBillHeader;
            }



            return Page();
        }
        public void OnPost()
        {
            //StatusMessage = _SalesTrans.MakePaymentOnBill(HeaderId, NewPayment).GetAwaiter().GetResult();

           // return RedirectToPage("Index");
        }
    }
}