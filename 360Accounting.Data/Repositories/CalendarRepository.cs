﻿using _360Accounting.Core.Entities;
using _360Accounting.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Accounting.Data.Repositories
{
    public class CalendarRepository : Repository, ICalendarRepository
    {
        public IEnumerable<Calendar> GetAll(long companyId, long sobId, string searchText, bool paging, int page, string sort, string sortDir)
        {
            IEnumerable<Calendar> calendarList = this.Context.Calendars
                .Where(x => x.CompanyId == companyId &&
                    x.SOBId == sobId);
            calendarList = sortDir.ToUpper() == "ASC" ? calendarList.OrderBy(x => x.SOBId) : calendarList.OrderByDescending(x => x.SOBId);
            if (!paging)
            {
                return calendarList.Select(x => new Calendar
                {
                    Adjusting = x.Adjusting,
                    CompanyId = x.CompanyId,
                    CreateBy = x.CreateBy,
                    CreateDate = x.CreateDate,
                    EndDate = x.EndDate,
                    Id = x.Id,
                    PeriodName = x.PeriodName,
                    PeriodQuarter = x.PeriodQuarter,
                    PeriodYear = x.PeriodYear,
                    SeqNumber = x.SeqNumber,
                    SOBId = x.SOBId,
                    StartDate = x.StartDate,
                    UpdateBy = x.UpdateBy,
                    UpdateDate = x.UpdateDate
                }).ToList();
            }
            else
            {
                var recordCount = calendarList.Count();
                return calendarList.Select(x => new Calendar
                {
                    Adjusting = x.Adjusting,
                    CompanyId = x.CompanyId,
                    CreateBy = x.CreateBy,
                    CreateDate = x.CreateDate,
                    EndDate = x.EndDate,
                    Id = x.Id,
                    PeriodName = x.PeriodName,
                    PeriodQuarter = x.PeriodQuarter,
                    PeriodYear = x.PeriodYear,
                    SeqNumber = x.SeqNumber,                    
                    SOBId = x.SOBId,
                    StartDate = x.StartDate,
                    UpdateBy = x.UpdateBy,
                    UpdateDate = x.UpdateDate
                }).Skip((page - 1) * 20)
                    .Take(20);
            }
        }

        public Calendar GetSingle(string id)
        {
            Calendar calendar = this.GetAll()
                .FirstOrDefault(x => x.Id == Convert.ToInt64(id));
            return calendar;
        }

        public IEnumerable<Calendar> GetAll()
        {
            IEnumerable<Calendar> calendarList = this.Context
                .Calendars;
            return calendarList;
        }

        public string Insert(Calendar entity)
        {
            this.Context.Calendars.Add(entity);
            this.Commit();
            return entity.Id.ToString();
        }

        public string Update(Calendar entity)
        {
            this.Context.Calendars.Attach(entity);
            this.Context.Entry(entity).State = EntityState.Modified;
            this.Commit();
            return entity.Id.ToString();
        }

        public void Delete(string id)
        {
            this.Context.Calendars.Remove(this.GetSingle(id));
            this.Commit();
        }

        public int Count()
        {
            return this.GetAll().Count();
        }

        public int Commit()
        {
            return this.Context.SaveChanges();
        }
    }
}
