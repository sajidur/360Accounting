﻿using _360Accounting.Core;
using _360Accounting.Core.Entities;
using _360Accounting.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _360Accounting.Web
{
    public static class SetOfBookHelper
    {
        private static ISetOfBookService service;

        static SetOfBookHelper()
        {
            service = IoC.Resolve<ISetOfBookService>("SetOfBookService");
        }

        private static SetOfBook getEntityByModel(SetOfBookModel model)
        {
            if (model == null) return null;

            return new SetOfBook
            {
                CompanyId = AuthenticationHelper.CompanyId.Value,
                Id = model.Id,
                Name = model.Name
            };
        }

        public static List<SetOfBookModel> GetSetOfBooks()
        {
            return service.GetByCompanyId(AuthenticationHelper.CompanyId.Value)
                .Select(x => new SetOfBookModel(x)).ToList();                
        }

        public static SetOfBookModel GetSetOfBook(string id)
        {
            SetOfBookModel model = new SetOfBookModel(service.GetSingle(id, AuthenticationHelper.CompanyId.Value));
            return model;                
        }

        public static SetOfBook GetSetOfBookByName(string sobName)
        {
            return service.GetSetOfBook(AuthenticationHelper.CompanyId.Value, sobName);                
        }

        public static string Insert(SetOfBookModel model)
        {
            return service.Insert(getEntityByModel(model));
        }

        public static string Update(SetOfBookModel model)
        {
            return service.Update(getEntityByModel(model));
        }

        public static void Delete(string id)
        {
            service.Delete(id, AuthenticationHelper.CompanyId.Value);
        }

        public static List<SelectListItem> GetSetOfBookList()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            if (GetSetOfBooks().Count > 0)
            {
                list = GetSetOfBooks().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();
            }
            return list;
        }
    }
}