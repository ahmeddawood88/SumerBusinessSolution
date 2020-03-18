﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sumer.Utility;
using SumerBusinessSolution.Data;
using SumerBusinessSolution.Models;
using SumerBusinessSolution.Transactions;

namespace SumerBusinessSolution
{
    public class NewCreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        private readonly ISalesTrans _SalesTrans;
        //private readonly IServiceScopeFactory _serviceScopeFactory;
        public NewCreateModel(ApplicationDbContext db, ISalesTrans SalesTrans)
        {
            _db = db;
            _SalesTrans = SalesTrans;
        }

        [TempData]
        public string StatusMessage { get; set; }


        [BindProperty]
        public BillHeader BillHeader { get; set; }

        //[BindProperty]



        [BindProperty]
        public string ProdCode { get; set; }

        [BindProperty]
        public IList<Warehouse> WarehouseList { get; set; }

        [BindProperty]
        public IList<Customer> Customer { get; set; }

        public List<BillItems> Bi { get; set; }

        public ActionResult OnGet()
        {

            //  public IList<BillItems> Bi = new List<BillItems> { new BillItems { ProdId = 0, Qty = 0, UnitPrice = 0, TotalAmt = 0, Note = "" };
            Bi = new List<BillItems> { new BillItems { ProdId = 0, Qty = 0, UnitPrice = 0, TotalAmt = 0, Note = "" } };

            //var Bi0 = new BillItems { ProdId = 0, Qty = 0, UnitPrice = 0, TotalAmt = 0, Note = "" };
            //var Bi1 = new BillItems { ProdId = 0, Qty = 0, UnitPrice = 0, TotalAmt = 0, Note = "" };
            //var Bi2 = new BillItems { ProdId = 0, Qty = 0, UnitPrice = 0, TotalAmt = 0, Note = "" };

            //Bi.Add(Bi0);
            //Bi.Add(Bi1);
            //Bi.Add(Bi2);
            // Bi = new List<BillItems> { new BillItems { ProdId = 0, Qty = 0, UnitPrice = 0, TotalAmt = 0, Note = "" } };



            WarehouseList = _db.Warehouse.ToList();
            Customer = _db.Customer.Where(cus => cus.Status == SD.ActiveCustomer).ToList();

            return Page();
        }
        public ActionResult OnPost(List<BillItems> Bi)
        {

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

            //int x = Bi.Count();

            //Bi[0].UnitPrice =  500;

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
 