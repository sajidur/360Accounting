﻿using _360Accounting.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Accounting.Core.Interfaces
{
    public interface IJournalVoucherRepository : IRepository<JournalVoucher>
    {
        IEnumerable<JournalVoucher> GetAll(long companyId, string searchText, bool paging, int page, string sort, string sortDir);
    }
}