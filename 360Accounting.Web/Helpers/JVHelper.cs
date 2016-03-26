﻿using _360Accounting.Core;
using _360Accounting.Core.Entities;
using _360Accounting.Web.Models;
using _360Accounting.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace _360Accounting.Web
{
    public static class JVHelper
    {
        private static IGLHeaderService service;
        private static IGLLineService lineService;


        static JVHelper()
        {
            service = IoC.Resolve<IGLHeaderService>("GLHeaderService");
            lineService = IoC.Resolve<IGLLineService>("GLLineService");
        }

        public static GLHeaderModel GetVoucher(string id)
        {
            GLHeaderModel jvHeader = new GLHeaderModel(service.GetSingle(id, AuthenticationHelper.User.CompanyId));
            jvHeader.GlLines = getGLLinesByHeaderId(id);

            return jvHeader;
        }

        public static GLHeaderModel GetGLHeaders(string id)
        {
            return new GLHeaderModel(service.GetSingle(id, AuthenticationHelper.User.CompanyId));
        }

        public static IList<GLHeaderModel> GetGLHeaders(long sobId, long periodId, long currencyId)
        {
            IList<GLHeaderModel> modelList = service
                .GetAll(AuthenticationHelper.User.CompanyId, sobId, periodId, currencyId).ToList()
                .Select(x => new GLHeaderModel(x)).ToList();
            return modelList;
        }

        public static IList<GLLinesModel> GetGLLines([Optional]string headerId)
        {
            if (headerId == null)
                return getGLLines();
            else
                return getGLLinesByHeaderId(headerId);
        }

        public static string GetDocNo(long companyId, long periodId, long sobId, long currencyId)
        {
            var currentDocument = service.GetSingle(companyId, periodId, sobId, currencyId);
            string newDocNo = "";
            if (currentDocument != null)
            {
                int outVal;
                bool isNumeric = int.TryParse(currentDocument.DocumentNo, out outVal);
                if (isNumeric && currentDocument.DocumentNo.Length == 8)
                {
                    newDocNo = (int.Parse(currentDocument.DocumentNo) + 1).ToString();
                    return newDocNo;
                }
            }

            //Create New DocNum..
            string yearDigit = SessionHelper.JV.GLDate.ToString("yy");
            string monthDigit = SessionHelper.JV.GLDate.ToString("MM");
            string docNo = int.Parse("1").ToString().PadLeft(4, '0');

            return yearDigit + monthDigit + docNo;
        }

        public static void Update(GLHeaderModel jv)
        {
            GLHeader entity = Mappers.GetEntityByModel(jv);

            string result = string.Empty;
            if (entity.IsValid())
            {
                if (jv.Id > 0)
                    result = service.Update(entity);
                else
                    result = service.Insert(entity);

                if (!string.IsNullOrEmpty(result))
                {
                    var savedLines = getGLLinesByHeaderId(result);
                    if (savedLines.Count() > jv.GlLines.Count())
                    {
                        var tobeDeleted = savedLines.Take(savedLines.Count() - jv.GlLines.Count());
                        foreach (var item in tobeDeleted)
                        {
                            lineService.Delete(item.Id.ToString(), AuthenticationHelper.User.CompanyId);
                        }
                        savedLines = getGLLinesByHeaderId(result);
                    }

                    foreach (var line in jv.GlLines)
                    {
                        GLLines lineEntity = Mappers.GetEntityByModel(line, jv.ConversionRate);
                        if (lineEntity.IsValid())
                        {
                            lineEntity.HeaderId = Convert.ToInt64(result);
                            if (savedLines.Count() > 0)
                            {
                                lineEntity.Id = savedLines.FirstOrDefault().Id;
                                savedLines.Remove(savedLines.FirstOrDefault(rec => rec.Id == lineEntity.Id));
                                lineService.Update(lineEntity);
                            }
                            else
                                lineService.Insert(lineEntity);
                        }
                    }
                }
            }
        }

        public static void UpdateGLLine(GLLinesModel model)
        {
            GLHeaderModel header = SessionHelper.JV;
            header.GlLines.FirstOrDefault(x => x.Id == model.Id).AccountedCr = model.AccountedCr;
            header.GlLines.FirstOrDefault(x => x.Id == model.Id).AccountedDr = model.AccountedDr;
            header.GlLines.FirstOrDefault(x => x.Id == model.Id).CodeCombinationId = model.CodeCombinationId;
            header.GlLines.FirstOrDefault(x => x.Id == model.Id).Description = model.Description;
            header.GlLines.FirstOrDefault(x => x.Id == model.Id).EnteredCr = model.EnteredCr;
            header.GlLines.FirstOrDefault(x => x.Id == model.Id).EnteredDr = model.EnteredDr;
            header.GlLines.FirstOrDefault(x => x.Id == model.Id).Quantity = model.Quantity;
            header.GlLines.FirstOrDefault(x => x.Id == model.Id).TaxRateCode = model.TaxRateCode;
        }

        public static void DeleteGLLine(GLLinesModel model)
        {
            GLHeaderModel header = SessionHelper.JV;
            GLLinesModel glLine = header.GlLines.FirstOrDefault(x => x.Id == model.Id);
            header.GlLines.Remove(glLine);
        }

        public static void Insert(GLLinesModel model)
        {
            GLHeaderModel header = SessionHelper.JV;
            header.GlLines.Add(model);
        }

        public static void Delete(string id)
        {
            service.Delete(id, AuthenticationHelper.User.CompanyId);
        }

        #region Private Methods
        private static IList<GLLinesModel> getGLLines()
        {
            return SessionHelper.JV.GlLines;
        }

        private static IList<GLLinesModel> getGLLinesByHeaderId(string headerId)
        {
            IList<GLLinesModel> modelList = lineService.GetAll
                (AuthenticationHelper.User.CompanyId, Convert.ToInt32(headerId)).
                Select(x => new GLLinesModel(x)).ToList();
            return modelList;
        }
        #endregion
    }
}