﻿using SumerBusinessSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SumerBusinessSolution.Transactions
{
    public interface ISalesTrans
    {
        Task<string> CreateBill(BillHeader Header, List<BillItems> BillItems);
        Task<string> MakePaymentOnBill(int HeaderId, double NewPaymentAmt);
    }
}
