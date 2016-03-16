﻿using _360Accounting.Core.IService;
using _360Accounting.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _360Accounting.Core.IRepository;

namespace _360Accounting.Service
{
    public class VendorService : IVendorService
    {
        #region Declaration

        private IVendorRepository repository;

        #endregion

        #region Constructor

        public VendorService(IVendorRepository repo)
        {
            this.repository = repo;
        }

        #endregion

        #region Methods

        public Vendor GetSingle(string id, long companyId)
        {
            return this.repository.GetSingle(id, companyId);
        }

        public IEnumerable<Vendor> GetAll(long companyId)
        {
            return this.repository.GetAll(companyId);
        }

        public string Insert(Vendor entity)
        {
            return this.repository.Insert(entity);
        }

        public string Update(Vendor entity)
        {
            return this.repository.Update(entity);
        }

        public void Delete(string id, long companyId)
        {
            this.repository.Delete(id, companyId);
        }

        public int Count(long companyId)
        {
            return this.repository.Count(companyId);
        }
   
        public IEnumerable<VendorSiteView> GetAllSites(long vendorId, long companyId)
        {
            return this.repository.GetAllSites(vendorId, companyId);
        }
    
        public long Insert(VendorSite entity)
        {
            return this.repository.Insert(entity);
        }

        public long Update(VendorSite entity)
        {
            return this.repository.Update(entity);
        }

        public void DeleteSite(long id, long companyId)
        {
            this.repository.DeleteSite(id, companyId);
        }

        public VendorSite GetSingle(long id)
        {
            return this.repository.GetSingle(id);
        }

        #endregion
    }
}