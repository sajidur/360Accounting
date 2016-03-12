﻿using _360Accounting.Core.Entities;
using _360Accounting.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Accounting.Core
{
    public interface IGLHeaderService : IService<GLHeader>
    {
        GLHeader GetSingle(long CompanyId, long PeriodId, long SOBId, long CurrencyId);
        IEnumerable<GLHeader> GetAll(long companyId, long sobId, long periodId, long currencyId);

        List<TrialBalance> TrialBalance(long companyId, long sobId, long fromCodeCombinationId, long toCodeCombinationId, long periodId);

        List<UserwiseEntriesTrail> UserwiseEntriesTrail(long companyId, long sobId, DateTime fromDate, DateTime toDate, Guid? UserId);

        List<AuditTrail> AuditTrail(long companyId, long sobId, DateTime fromDate, DateTime toDate);

        List<Ledger> Ledger(long companyId, long sobId, long fromCodeCombinationId, long toCodeCombinationId, DateTime fromDate, DateTime toDate);
    }
}