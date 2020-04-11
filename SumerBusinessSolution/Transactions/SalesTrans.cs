﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SumerBusinessSolution.Utility;
using SumerBusinessSolution.Data;
using SumerBusinessSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SumerBusinessSolution.Transactions
{
    public class SalesTrans : ISalesTrans
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SalesTrans(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }

        public InvStockQty InvStockQty { get; set; }
        public Warehouse StoreRoom { get; set; }
        
        // this function will create a bill for the first time
        public async Task<string> CreateBill(BillHeader Header, List<BillItems> BillItems)
        {
            try
            {
                StoreRoom = _db.Warehouse.Include(wh => wh.WhType).FirstOrDefault(wh => wh.WhType.Type == "StoreRoom"); 

                Header.CreatedById = GetLoggedInUserId();
                Header.CreatedDataTime = DateTime.Now;

                double TotalAmt = 0;

                // getting the unit price of each item in the bill items 
                foreach (BillItems item in BillItems)
                {
                    item.ProdId = _db.ProdInfo.FirstOrDefault(pr => pr.ProdCode == item.ProdInfo.ProdCode).Id;
                    // first check if qty enough in the store room before proceeding
                    bool CheckQty = CheckQtyInWh(item.ProdId??0, StoreRoom.Id, item.Qty);

                    if(CheckQty == false)
                    {
                        return "لا توجد كمية كافية للبيع";
                    }

                    TotalAmt += item.TotalAmt;
                }

                // price before discount
                Header.TotalAmt = TotalAmt;

                // incase there is a discount
                TotalAmt = TotalAmt - Header.Discount;
                Header.TotalNetAmt = TotalAmt;

                if(TotalAmt == Header.PaidAmt)
                {
                    Header.Status = SD.Completed;
                }
                else
                {
                    Header.Status = SD.OpenBill;
                }
                

                _db.BillHeader.Add(Header);

                await _db.SaveChangesAsync();

                // updatinga customer Acc 
                double DebtAmt = Header.TotalNetAmt - Header.PaidAmt;
                UpdateCustomerAcc(Header.CustId ?? 0, Header.PaidAmt, DebtAmt, "New");

                // add a new payment to bill payments table 
                AddBillPayment(Header.CustId ?? 0, Header.Id, Header.PaidAmt);


                // Creating Bill items
                foreach (BillItems item in BillItems)
                {
                    BillItems Bill = new BillItems
                    {
                        HeaderId = Header.Id,
                        ProdId = item.ProdId,
                        Qty = item.Qty,
                        UnitPrice = item.UnitPrice,
                        TotalAmt = item.UnitPrice * item.Qty,
                        Note = item.Note
                    };

                    // decrease stock qty of that item 
                    DecreaseStockQty(Bill.ProdId??0, StoreRoom.Id, Bill.Qty);

                    // create inv transaction 
                    CreateInvTransaction(Bill.ProdId??0, StoreRoom.Id, Bill.Qty ,SD.Sales);
                    _db.BillItems.Add(Bill);

                }
                
            
                await _db.SaveChangesAsync();


                return "تمت اضافة فاتورة مبيعات جديدة";
            }

            catch
            {
                return "حصل خطأ لم يتم اضافة الفاتورة";
            }
        }

      
    
        public async Task<string> MakePaymentOnBill(int HeaderId, double NewPaymentAmt)
        {
            try
            {
                BillHeader Header =  _db.BillHeader.FirstOrDefault(h => h.Id == HeaderId);

                CustAcc Acc = _db.CustAcc.FirstOrDefault(ac => ac.CustId == Header.CustId);
                
                // updating bill header will the payment
                Header.PaidAmt += NewPaymentAmt;

                // if the bill paid all, change status to completed
                if(Header.TotalNetAmt == Header.PaidAmt)
                {
                    Header.Status = SD.Completed;
                }

                // updating customer Acc
                //Acc.Paid += PaidAmt;
                //Acc.Debt -= PaidAmt;
                UpdateCustomerAcc(Header.CustId ?? 0, NewPaymentAmt, NewPaymentAmt, "Old");

                // add a new payment to bill payments table 
                AddBillPayment(Header.CustId??0, Header.Id, NewPaymentAmt);
 
                await _db.SaveChangesAsync();

                return "تمت عملية الدفع";
            }
            catch(Exception ex)
            {
                return "لم تتم عملية الدفع";
            }
        }

        
     
        public async Task<string> MakePaymentToAcc(int CustId, double NewPaymentAmt)
        {
            try
            { 
                CustAcc Acc = _db.CustAcc.FirstOrDefault(ac => ac.CustId == CustId);

            
                // updating customer Acc
                //Acc.Paid += PaidAmt;
                //Acc.Debt -= PaidAmt;
                UpdateCustomerAcc(CustId, NewPaymentAmt, NewPaymentAmt, "Old");
  
                await _db.SaveChangesAsync();

                return "تمت عملية الدفع";
            }
            catch (Exception ex)
            {
                return "لم تتم عملية الدفع";
            }
        }

        // this function will close a bill manually 
        public async Task<string> CloseBillManually(int HeaderId)
        {
            try
            {
                BillHeader Header = _db.BillHeader.FirstOrDefault(h => h.Id == HeaderId);
                Header.Status = SD.Completed;
                await _db.SaveChangesAsync();

                return "تم اغلاق الفاتورة بنجاح";
            }
           catch
            {
                return "حصل خطأ لم يتم اغلاق الفاتورة";
            }

        }

       


        // this function will update customer account manually, only for admin
        public async Task<string> UpdateCustomerAccManually(int CustId, double Payment, double Debt)
        {
            try
            {
                CustAcc Acc = _db.CustAcc.FirstOrDefault(ac => ac.CustId == CustId);

                if (Payment > 0)
                {
                    Acc.Paid = Payment;
                }

                if (Debt > 0)
                {
                    Acc.Debt = Debt;
                }


                await _db.SaveChangesAsync();

                return "تم تعديل الحساب";
            }
            catch
            {
                return "Error! حصل خطأ لم يتم تعديل الحساب";
            }

        }

     
        // External Billing

        // this function will create an external bill.. external bill is a bill issues for a customers
        // for purchasing items that do not belong to the company. basically it is supplied by another or a 
        // third party company. creating external bills will have no effect on Inventory at all

        public async Task<string> CreateExternalBill(ExternalBillHeader ExternalHeader, List<ExternalBillItems> ExternalBill)
        {
            try
            {
                StoreRoom = _db.Warehouse.Include(wh => wh.WhType).FirstOrDefault(wh => wh.WhType.Type == "StoreRoom");

                ExternalHeader.CreatedById = GetLoggedInUserId();
                ExternalHeader.CreatedDataTime = DateTime.Now;

                double TotalAmt = 0;

                // getting the unit price of each item in the bill items 
                foreach (ExternalBillItems item in ExternalBill)
                {

                    TotalAmt += item.TotalAmt;
                }

                // price before discount
                ExternalHeader.TotalAmt = TotalAmt;

                // in case there is a discount
                TotalAmt = TotalAmt - ExternalHeader.Discount;
                ExternalHeader.TotalNetAmt = TotalAmt;

                if (TotalAmt == ExternalHeader.PaidAmt)
                {
                    ExternalHeader.Status = SD.Completed;
                }
                else
                {
                    ExternalHeader.Status = SD.OpenBill;
                }


                _db.ExternalBillHeader.Add(ExternalHeader);

                await _db.SaveChangesAsync();

                // updatinga customer Acc 
                double DebtAmt = ExternalHeader.TotalNetAmt - ExternalHeader.PaidAmt;
                UpdateCustomerAcc(ExternalHeader.CustId ?? 0, ExternalHeader.PaidAmt, DebtAmt, "New");

                // add a new payment to bill payments table 
                // AddBillPayment(Header.CustId ?? 0, Header.Id, Header.PaidAmt);


                // Creating Bill items
                foreach (ExternalBillItems item in ExternalBill)
                {
                    ExternalBillItems Bill = new ExternalBillItems
                    {
                        HeaderId = ExternalHeader.Id,
                        ProdName = item.ProdName,
                        Qty = item.Qty,
                        UnitPrice = item.UnitPrice,
                        TotalAmt = item.UnitPrice * item.Qty,
                        Note = item.Note
                    };
                    _db.ExternalBillItems.Add(Bill);
                }


                await _db.SaveChangesAsync();


                return "تمت اضافة فاتورة مبيعات جديدة";
            }

            catch
            {
                return "حصل خطأ لم يتم اضافة الفاتورة";
            }
        }

        // this function will close an external bill manually 
        public async Task<string> CloseExternalBillManually(int ExternalHeaderId)
        {
            try
            {
                ExternalBillHeader ExternalHeader = _db.ExternalBillHeader.FirstOrDefault(h => h.Id == ExternalHeaderId);
                ExternalHeader.Status = SD.Completed;
                await _db.SaveChangesAsync();

                return "تم اغلاق الفاتورة بنجاح";
            }
            catch
            {
                return "حصل خطأ لم يتم اغلاق الفاتورة";
            }

        }

        // Make payment on external bills
        public async Task<string> MakePaymentOnExternalBill(int ExternalHeaderId, double NewPaymentAmt)
        {
            try
            {
                ExternalBillHeader ExternalHeader = _db.ExternalBillHeader.FirstOrDefault(h => h.Id == ExternalHeaderId);

                CustAcc Acc = _db.CustAcc.FirstOrDefault(ac => ac.CustId == ExternalHeader.CustId);

                // updating bill header will the payment
                ExternalHeader.PaidAmt += NewPaymentAmt;

                // if the bill paid all, change status to completed
                if (ExternalHeader.TotalNetAmt == ExternalHeader.PaidAmt)
                {
                    ExternalHeader.Status = SD.Completed;
                }

                // updating customer Acc
                //Acc.Paid += PaidAmt;
                //Acc.Debt -= PaidAmt;
                UpdateCustomerAcc(ExternalHeader.CustId ?? 0, NewPaymentAmt, NewPaymentAmt, "Old");

                // add a new payment to bill payments table 
                AddExternalBillPayment(ExternalHeader.CustId ?? 0, ExternalHeader.Id, NewPaymentAmt);
   
                await _db.SaveChangesAsync();

                return "تمت عملية الدفع";
            }
            catch (Exception ex)
            {
                return "لم تتم عملية الدفع";
            }
        }


        // Helping functions // 
        private string GetLoggedInUserId()
        {
            var ClaimId = (ClaimsIdentity)_httpContextAccessor.HttpContext.User.Identity;
            var Claim = ClaimId.FindFirst(ClaimTypes.NameIdentifier);
            string UserId = Claim.Value;
            return UserId;
        }



        // updating customer Accs 
        private void UpdateCustomerAcc(int CustId, double Paid, double Debt, string Status)
        {
            CustAcc Acc = _db.CustAcc.FirstOrDefault(cu => cu.CustId == CustId);

            Acc.Paid += Paid;

            // if new means new bill and will add more debit (in case customer didnt make full payment)
            if(Status == "New")
            {
                Acc.Debt += Debt;
            }
            else // this will be used when a customer makes a new payment on existing bill, so debt will be minus
            {
                if(Acc.Debt > 0)
                {
                    Acc.Debt -= Debt;

                }
                
            }
            
        }


        // checking item qty before sales 
        private bool CheckQtyInWh(int ProdId, int WhId, double Qty)
        {
            InvStockQty = _db.InvStockQty.FirstOrDefaultAsync(inv => inv.ProdId == ProdId & inv.WhId == WhId).GetAwaiter().GetResult();

            double StockQty = InvStockQty.Qty;

            if (StockQty >= Qty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // this function will update bill payment table
        private void AddBillPayment(int CustId, int BillHeaderId, double Paid)
        {
            BillPayment NewPayment = new BillPayment
            {
                CustId = CustId,
                BillHeaderId = BillHeaderId,
                PaidAmt = Paid,
                CreatedDateTime = DateTime.Now,
                CreatedById = GetLoggedInUserId()
            };
            _db.BillPayment.Add(NewPayment);
          
        }

        // this function will update External bill payment table
        private void AddExternalBillPayment(int CustId, int ExternalBillHeaderId, double Paid)
        {
            ExternalBillPayment NewPayment = new ExternalBillPayment
            {
                CustId = CustId,
                ExternalBillHeaderId = ExternalBillHeaderId,
                PaidAmt = Paid,
                CreatedDateTime = DateTime.Now,
                CreatedById = GetLoggedInUserId()
            };
            _db.ExternalBillPayment.Add(NewPayment);

        }


        // this function will decrease the stock qty
        private void DecreaseStockQty(int ProdId, int WhId, double Qty)
        {
            InvStockQty = _db.InvStockQty.FirstOrDefaultAsync(inv => inv.ProdId == ProdId & inv.WhId == WhId).GetAwaiter().GetResult();
            if (InvStockQty != null)
            {
                    InvStockQty.Qty -= Qty;
            }

        }

        // add a sale transaction inside invTransaction table 
        private void CreateInvTransaction(int ProdId, int? WhId, double Qty, string TransType)
        {
            InvTransaction InvTrans = new InvTransaction
            {
                ProdId = ProdId,
                WhId = WhId,
                Qty = Qty,
                TransType = TransType,
                CreatedById = GetLoggedInUserId(),
                CreatedDateTime = DateTime.Now
            };
            _db.InvTransaction.Add(InvTrans);
        }

    }
}
