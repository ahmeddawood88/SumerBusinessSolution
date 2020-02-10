﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sumer.Utility;
using SumerBusinessSolution.Data;
using SumerBusinessSolution.Models;
using SumerBusinessSolution.Transactions;

namespace SumerBusinessSolution.Pages.Inventory.TransferRequests
{
   // [Authorize(Roles =SD.StoreEndUser)]
   [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly IInventoryTrans _InveTrans;

        public CreateModel(ApplicationDbContext db, IInventoryTrans InveTrans)
        {
            _db = db;
            _InveTrans = InveTrans;
        }
        

        //public InvTransfer InvTransfer { get; set; }
        //public Warehouse Warehouse { get; set; }
        public IList<Warehouse> Warehouselist { get; set; }

        [Required]
        [BindProperty]
        [Display(Name = "رمز المنتج")]
        public string ProdCode { get; set; }
        [BindProperty]
        [Display(Name = "من المخزن ")]

        public int FromWhId { get; set; }
        [BindProperty]
        [Display(Name = "الى المخزن ")]

        public int ToWhId { get; set; }

        [Required]
        [BindProperty]
        [Display(Name = "الكميه")]
        public double Qty { get; set; }
        [BindProperty]
        [Display(Name = "الملاحظات")]
        public string Note { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public void OnGet()
        {
            Warehouselist = _db.Warehouse.ToList();
        }

        public JsonResult OnGetSearchNow(string term)
        {
            //   ProdInfo = _db.ProdInfo.Where(w => w.Id == ProdId).ToList();
            if (term == null)
            {
                return new JsonResult("Not Found");
            }
            IQueryable<string> lstProdCode = from P in _db.ProdInfo
                                             where (P.ProdCode.Contains(term))
                                             select P.ProdCode;
            return new JsonResult(lstProdCode);
        }

        public IActionResult OnPost()
        {
            int ProdId;
            try
            {
                ProdId = _db.ProdInfo.FirstOrDefault(pro => pro.ProdCode == ProdCode).Id;
            }
            catch
            {
                StatusMessage = "Error! Product code can not be found";
                return RedirectToPage("/inventory/transferrequests/create");
            }

            StatusMessage = _InveTrans.CreateInvTransferRequest(ProdId, FromWhId, ToWhId, Qty, Note).GetAwaiter().GetResult();

            //if (invTransfer == true)
            //{
            //    StatusMessage = "New goods have been transfered successfully.";
            //}
            //else
            //{
            //    StatusMessage = "Error! New goods have not been transfered.";
            //}
            return RedirectToPage("/inventory/transferrequests/create");
        }
    }
}