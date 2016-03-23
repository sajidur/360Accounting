﻿using _360Accounting.Core;
using _360Accounting.Core.Entities;
using _360Accounting.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Accounting.Service
{
    public class WithholdingService : IWithholdingService
    {
        private IWithholdingRepository repository;

        public WithholdingService(IWithholdingRepository repo)
        {
            this.repository = repo;
        }

        public Withholding GetSingle(string id, long companyId)
        {
            return this.repository.GetSingle(id,companyId);
        }

        public IEnumerable<Withholding> GetAll(long companyId)
        {
            return this.repository.GetAll(companyId);
        }

        public IEnumerable<Withholding> GetWithholdings(long companyId, long sobId, long codeCombinitionId, long vendorId)
        {
            return this.repository.GetWithholdings(companyId, sobId, codeCombinitionId, vendorId);
        }

        public string Insert(Withholding entity)
        {
            if (entity.IsValid())
                return this.repository.Insert(entity);
            else
                return "Entity is not in valid state";
        }

        public string Update(Withholding entity)
        {
            if (entity.IsValid())
                return this.repository.Update(entity);
            else
                return "Entity is not in valid state";
        }

        public void Delete(string id, long companyId)
        {
            this.repository.Delete(id,companyId);
        }

        public int Count( long companyId)
        {
            return this.repository.Count(companyId);
        }
    }
}