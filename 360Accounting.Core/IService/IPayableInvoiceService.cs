﻿using _360Accounting.Core.Entities;
using _360Accounting.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Accounting.Core
{
    public interface IPayableInvoiceService : IService<PayableInvoice>
    {
        IEnumerable<PayableInvoice> GetAll(long companyId, long sobId,
            long periodId);

        PayableInvoice GetSingle(long companyId, long sobId, long periodId);
    }
}