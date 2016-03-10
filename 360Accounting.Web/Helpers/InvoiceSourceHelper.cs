﻿using _360Accounting.Core;
using _360Accounting.Core.Entities;
using _360Accounting.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _360Accounting.Web
{
    public static class InvoiceSourceHelper
    {
        private static IInvoiceSourceService service;

        static InvoiceSourceHelper()
        {
            service = IoC.Resolve<IInvoiceSourceService>("InvoiceSourceService");
        }

        public static string SaveInvoiceSource(InvoiceSourceViewModel model)
    {
            if (model.Id > 0)
            {
                return service.Update(Mappers.GetEntityByModel(model));
            }
            else
            {
                return service.Insert(Mappers.GetEntityByModel(model));
            }
        }

        public static List<InvoiceSourceViewModel> InvoiceList(long sobId)
        {
            List<InvoiceSourceViewModel> modelList = service
                .GetAll(AuthenticationHelper.User.CompanyId, sobId)
                .Select(x => new InvoiceSourceViewModel(x)).ToList();
            return modelList;
        }

        public static void Delete(string id)
        {
            service.Delete(id, AuthenticationHelper.User.CompanyId);
        }

        public static InvoiceSourceViewModel GetInvoiceSource(string id)
        {
            InvoiceSourceViewModel invoiceSource = new InvoiceSourceViewModel
                (service.GetSingle(id, AuthenticationHelper.User.CompanyId));
            return invoiceSource;
        }
    }
}