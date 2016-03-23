﻿using _360Accounting.Core;
using _360Accounting.Core.Entities;
using _360Accounting.Data.Repositories;
using _360Accounting.Service;
using _360Accounting.Web.Models;
using _360Accounting.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace _360Accounting.Web.Controllers
{
    [Authorize]
    public class WithholdingController : Controller
    {
        public ActionResult Index(WithholdingListModel model)
        {
            if (model.SetOfBooks == null)
            {
                model.SetOfBooks = SetOfBookHelper.GetSetOfBooks()
                    .Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }).ToList();
            }
            model.SOBId = model.SOBId > 0 ? model.SOBId : model.SetOfBooks != null ? model.SetOfBooks.Count() > 0 ? Convert.ToInt64(model.SetOfBooks[0].Value.ToString()) : 0 : 0;

            if (model.CodeCombinition == null)
            {
                model.CodeCombinition = CodeCombinationHelper.GetCodeCombinations(model.SOBId, AuthenticationHelper.User.CompanyId)
                    .Select(x => new SelectListItem
                    {
                        Text = x.Id.ToString(),
                        Value = x.Id.ToString()
                    }).ToList();
            }
            model.CodeCombinitionId = model.CodeCombinitionId > 0 ? model.CodeCombinitionId : model.CodeCombinition != null ? model.CodeCombinition.Count() > 0 ? Convert.ToInt64(model.CodeCombinition[0].Value.ToString()) : 0 : 0;

            if (model.Vendor == null)
            {
                model.Vendor = VendorHelper.GetAll()
                    .Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }).ToList();
            }
            model.VendorId = model.VendorId > 0 ? model.VendorId : model.Vendor != null ? model.Vendor.Count() > 0 ? Convert.ToInt64(model.Vendor[0].Value.ToString()) : 0 : 0;

            SessionHelper.SOBId = model.SOBId;
            SessionHelper.VendorId = model.VendorId;
            SessionHelper.CodeCombinitionId = model.CodeCombinitionId;

            return View(model);
        }

        public ActionResult CreatePartial()
        {
            return PartialView("_List", WithholdingHelper.GetWithholdings(SessionHelper.SOBId, SessionHelper.CodeCombinitionId, SessionHelper.VendorId));
        }

        public ActionResult GetWithholdings(long sobId, long codeCombinitionId, long vendorId)
        {
            SessionHelper.SOBId = sobId;
            SessionHelper.CodeCombinitionId = codeCombinitionId;
            SessionHelper.VendorId = vendorId;
            return PartialView("_List", WithholdingHelper.GetWithholdings(sobId, codeCombinitionId, vendorId));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddNewInline(WithholdingModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.VendorId = SessionHelper.VendorId;
                    model.SOBId = SessionHelper.SOBId; 
                    model.CodeCombinitionId = SessionHelper.CodeCombinitionId;

                    WithholdingHelper.Save(model);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_List", WithholdingHelper.GetWithholdings(model.SOBId, model.CodeCombinitionId, model.VendorId));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateInline(WithholdingModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.VendorId = SessionHelper.VendorId;
                    model.SOBId = SessionHelper.SOBId;
                    model.CodeCombinitionId = SessionHelper.CodeCombinitionId;

                    WithholdingHelper.Save(model);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_List", WithholdingHelper.GetWithholdings(model.SOBId, model.CodeCombinitionId, model.VendorId));
        }

        public ActionResult DeleteInline(WithholdingModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    WithholdingHelper.Delete(model.Id.ToString());
                    return PartialView("_List", WithholdingHelper.GetWithholdings(model.SOBId, model.CodeCombinitionId, model.VendorId));
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_List", WithholdingHelper.GetWithholdings(model.SOBId, model.CodeCombinitionId, model.VendorId));
        }
    }
}