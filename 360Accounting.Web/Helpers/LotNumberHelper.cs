﻿using _360Accounting.Core;
using _360Accounting.Core.Entities;
using _360Accounting.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _360Accounting.Web
{
    public static class LotNumberHelper
    {
        private static ILotNumberService service;

        static LotNumberHelper()
        {
            service = IoC.Resolve<ILotNumberService>("LotNumberService");
        }

        #region Private Methods

        private static LotNumber GetLotEntityByMoveOrderModel(MoveOrderDetailModel model, int count)
        {
            if (model == null) return null;

            LotNumber entity = new LotNumber();
            if (count == 0)
            {
                entity.CreateBy = AuthenticationHelper.UserId;
                entity.CreateDate = DateTime.Now;
            }
            else
            {
                entity.CreateBy = model.CreateBy;
                entity.CreateDate = model.CreateDate;
            }

            entity.CompanyId = AuthenticationHelper.CompanyId.Value;
            entity.Id = model.Id;
            entity.ItemId = model.ItemId;
            entity.LotNo = model.LotNo;
            entity.SOBId = SessionHelper.SOBId;
            entity.SourceId = model.MoveOrderId;
            entity.SourceType = "Move Order";
            entity.UpdateBy = AuthenticationHelper.UserId;
            entity.UpdateDate = DateTime.Now;
            return entity;
        }

        private static SerialNumber GetSerialEntityByMoveOrderModel(MoveOrderDetailModel model, int count)
        {
            if (model == null) return null;

            SerialNumber entity = new SerialNumber();
            if (count == 0)
            {
                entity.CreateBy = AuthenticationHelper.UserId;
                entity.CreateDate = DateTime.Now;
            }
            else
            {
                entity.CreateBy = model.CreateBy;
                entity.CreateDate = model.CreateDate;
            }

            entity.Id = model.Id;
            entity.LotNo = model.LotNo;
            entity.SerialNo = model.SerialNo;
            entity.UpdateBy = AuthenticationHelper.UserId;
            entity.UpdateDate = DateTime.Now;
            return entity;
        }

        private static LotNumber GetLotEntityByMiscellaneousTransaction(MiscellaneousTransactionDetailModel model, int count)
        {
            if (model == null) return null;

            LotNumber entity = new LotNumber();
            if (count == 0)
            {
                entity.CreateBy = AuthenticationHelper.UserId;
                entity.CreateDate = DateTime.Now;
            }
            else
            {
                entity.CreateBy = model.CreateBy;
                entity.CreateDate = model.CreateDate;
            }

            entity.CompanyId = AuthenticationHelper.CompanyId.Value;
            entity.Id = model.Id;
            entity.ItemId = model.ItemId;
            entity.LotNo = model.LotNo;
            entity.SOBId = SessionHelper.SOBId;
            entity.SourceId = model.Id;
            entity.SourceType = "Miscellaneous Transaction";
            entity.UpdateBy = AuthenticationHelper.UserId;
            entity.UpdateDate = DateTime.Now;
            return entity;
        }

        private static SerialNumber GetSerialEntityByMiscellaneousTransaction(MiscellaneousTransactionDetailModel model, int count)
        {
            if (model == null) return null;

            SerialNumber entity = new SerialNumber();
            if (count == 0)
            {
                entity.CreateBy = AuthenticationHelper.UserId;
                entity.CreateDate = DateTime.Now;
            }
            else
            {
                entity.CreateBy = model.CreateBy;
                entity.CreateDate = model.CreateDate;
            }

            entity.Id = model.Id;
            entity.LotNo = model.LotNo;
            entity.SerialNo = model.SerialNo;
            entity.UpdateBy = AuthenticationHelper.UserId;
            entity.UpdateDate = DateTime.Now;
            return entity;
        }

        #endregion

        public static IEnumerable<LotNumber> CheckLotNumAvailability(string lotNum, long itemId, long sobId)
        {
            return service.CheckLotNumAvailability(AuthenticationHelper.User.CompanyId, lotNum, itemId, sobId);
        }

        public static IEnumerable<SerialNumber> CheckSerialNumAvailability(string lotNum, string serialNum)
        {
            return service.CheckSerialNumAvailability(AuthenticationHelper.User.CompanyId, lotNum, serialNum);
        }

        public static string Insert(MoveOrderDetailModel entity)
        {
            return service.Insert(GetLotEntityByMoveOrderModel(entity, 0));
        }

        public static string Insert(MiscellaneousTransactionDetailModel entity)
        {
            return service.Insert(GetLotEntityByMiscellaneousTransaction(entity, 0));
        }

        public static string Update(LotNumber entity)
        {
            return service.Update(entity);
        }

        public static void Delete(string id)
        {
            service.Delete(id, AuthenticationHelper.User.CompanyId);
        }

        public static string InsertSerialNumber(MoveOrderDetailModel entity)
        {
            return service.InsertSerialNum(GetSerialEntityByMoveOrderModel(entity, 0));
        }

        public static string InsertSerialNumber(MiscellaneousTransactionDetailModel entity)
        {
            return service.InsertSerialNum(GetSerialEntityByMiscellaneousTransaction(entity, 0));
        }

        public static string UpdateSerialNumber(SerialNumber entity)
        {
            return service.UpdateSerialNum(entity);
        }

        public static void DeleteSerialNumber(string id)
        {
            service.DeleteSerialNum(id, AuthenticationHelper.User.CompanyId);
        }
    }
}