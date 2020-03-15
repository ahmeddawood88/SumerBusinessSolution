﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SumerBusinessSolution.Data;
using SumerBusinessSolution.Models;
using SumerBusinessSolution.Transactions;

namespace SumerBusinessSolution.Pages.Sales.Billings
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        private readonly ISalesTrans _SalesTrans;
        //private readonly IServiceScopeFactory _serviceScopeFactory;
        public CreateModel(ApplicationDbContext db, ISalesTrans SalesTrans)
        {
            _db = db;
            _SalesTrans = SalesTrans;
        }

        [TempData]
        public string StatusMessage { get; set; }


        [BindProperty]
        public BillHeader BillHeader { get; set; }

        //[BindProperty]
        public IList<BillItems> Bi = new List<BillItems> { new BillItems { ProdId = 0, Qty = 0, UnitPrice = 0, TotalAmt = 0, Note = "" }
};

        [BindProperty]
        public string ProdCode { get; set; }

        [BindProperty]
        public IList<Warehouse> WarehouseList { get; set; }

        [BindProperty]
        public IList<Customer> Customer { get; set; }



        public ActionResult OnGet()
        {
            var Bi0 = new BillItems { ProdId = 0, Qty = 0, UnitPrice = 0, TotalAmt = 0, Note = "" };
            var Bi1 = new BillItems { ProdId = 0, Qty = 0, UnitPrice = 0, TotalAmt = 0, Note = "" };
            var Bi2 = new BillItems { ProdId = 0, Qty = 0, UnitPrice = 0, TotalAmt = 0, Note = "" };

            Bi.Add(Bi0);
            Bi.Add(Bi1);
            Bi.Add(Bi2);
            // Bi = new List<BillItems> { new BillItems { ProdId = 0, Qty = 0, UnitPrice = 0, TotalAmt = 0, Note = "" } };



            WarehouseList = _db.Warehouse.ToList();
            Customer = _db.Customer.ToList();

            return Page();
        }
        public ActionResult OnPost(List<BillItems> Bi)
        {
          
            // int ProdId;

            // if (ModelState.IsValid)
            //  {
            //using (_db dc = new MyDatabaseEntities())
            //{
            //foreach (var i in ci)
            //{
            //    if(i == null)
            //    {
            //        break;
            //    }
            //    ProdId = _db.ProdInfo.FirstOrDefault(pro => pro.ProdCode == i.ProdInfo.ProdCode).Id;
            //    // _db.IncomingGood.Add(i);

            //}

            StatusMessage = _SalesTrans.CreateBill(BillHeader, Bi).GetAwaiter().GetResult();


            //_db.SaveChanges();
    
            ModelState.Clear();

            // }
            // }
            return RedirectToPage("/Sales/Billings/Create");
        }

        public JsonResult OnGetSearchNow(string term)
        {
            if (term == null)
            {
                return new JsonResult("Not Found");
            }
            IQueryable<string> lstProdCode = from P in _db.ProdInfo
                                             where (P.ProdCode.Contains(term))
                                             select P.ProdCode;

            int x = Bi.Count();
        
            Bi[0].UnitPrice =  500;
          
            return new JsonResult(lstProdCode);

        }

        public JsonResult OnGetProdUnitPrice(string term)
        {
            if (term == null)
            {
                return new JsonResult("Not Found");
            }
            IQueryable<double> unitPrice = from P in _db.ProdInfo
                                             where (P.ProdCode.Contains(term))
                                             select P.RetailPrice;
            return new JsonResult(unitPrice);

        }
    }
}
