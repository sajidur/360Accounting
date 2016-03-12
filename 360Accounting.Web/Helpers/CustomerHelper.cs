﻿using _360Accounting.Core;
using _360Accounting.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _360Accounting.Web
{
    public static class CustomerHelper
    {
        private static ICustomerService service;

        static CustomerHelper()
        {
            service = IoC.Resolve<ICustomerService>("CustomerService");
        }

        public static string SaveCustomer(CustomerModel model)
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

        public static CustomerModel GetCustomer(string id)
        {
            return new CustomerModel(service.GetSingle(id, AuthenticationHelper.User.CompanyId));
        }

        public static void DeleteCustomer(string id)
        {
            service.Delete(id, AuthenticationHelper.User.CompanyId);
        }

        public static List<CustomerModel> GetCustomers()
        {
            return service.GetAll(AuthenticationHelper.User.CompanyId)
                .Select(a => new CustomerModel(a)).ToList();
        }
    }
}