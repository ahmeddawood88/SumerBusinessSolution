﻿using SumerBusinessSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SumerBusinessSolution.Hubs;
namespace SumerBusinessSolution.Transactions
{
    public interface IInventoryTrans
    {
        // Task<bool> CreateIncomingGoods(int WhId, int ProdId, double Qty, string Note);
        Task<string> CreateIncomingGoods(int NewWhId, List<IncomingGood> IG);
        void CreateProdAtIG(List<ProdInfo> NewProd);
        Task<bool> DeleteIncomingGoods(int IgId);
        Task<string> CreateInvTransfer(int? FromWhId, int? ToWhId, List<InvTransfer> InvTrans);
        Task<string> CreateInvTransferRequest(int? FromWhId, int? ToWhId, string Note, List<InvTransfer> InvTrans, IHubContext<NotificationHub> hubContext);

        // Task<string> CreateInvTransferRequest(int? FromWhId, int? ToWhId, string Note, List<InvTransfer> InvTrans);
        Task<string> ApproveInvTransferRequest(int ReqId);
        Task<string> RejectInvTransferRequest(int ReqId);
        Task<string> DeleteInvTransferRequestHeader(int ReqId);
        Task<string> DeleteInvTransferRequestLine(int LineId);
        Task<bool> CheckProdCodeExist(string ProdCode);
        Task<bool> UpdateProdStkQty(int StkId, double Qty);
        Task<IEnumerable<InvTransferHeader>> GetPendingTransferRequests();
        bool CreateProdInWh(int ProdId, int WhId, double OpenQty);

    }
}
