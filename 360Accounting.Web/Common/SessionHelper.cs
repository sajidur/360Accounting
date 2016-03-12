﻿using _360Accounting.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _360Accounting.Web
{
    public class SessionHelper
    {
        private const string SESSION_JV = "SESSION_JV";

        ////used in jv
        //public static long CurrencyId
        //{
        //    get
        //    {
        //        return Convert.ToInt64(HttpContext.Current.Session["CurrencyId"].ToString());
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session["CurrencyId"] = value;
        //    }
        //}

        ////used in jv
        //public static long PeriodId
        //{
        //    get
        //    {
        //        return Convert.ToInt64(HttpContext.Current.Session["PeriodId"].ToString());
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session["PeriodId"] = value;
        //    }
        //}

        //used in customer sites

        public static GLHeaderModel JV
        {
            get
            {
                return HttpContext.Current.Session[SESSION_JV] == null ? null :
                    (GLHeaderModel)HttpContext.Current.Session[SESSION_JV];
            }
            set
            {
                HttpContext.Current.Session[SESSION_JV] = value;
            }
        }

        public static long SOBId
        {
            get
            {
                return Convert.ToInt64(HttpContext.Current.Session["SOBId"].ToString());
            }
            set
            {
                HttpContext.Current.Session["SOBId"] = value;
            }
        }

        //TODO: this is temporary because of the issue 40 in task list.
        public static int PrecisionLimit
        {
            get
            {
                return Convert.ToInt32(HttpContext.Current.Session["PrecissionLimit"].ToString());
            }
            set
            {
                HttpContext.Current.Session["PrecissionLimit"] = value;
            }
        }

        //public static JournalVoucherViewModel JournalVoucher
        //{
        //    get
        //    {
        //        return HttpContext.Current.Session["JournalVoucher"] == null ? new JournalVoucherViewModel()
        //            : (JournalVoucherViewModel)HttpContext.Current.Session["JournalVoucher"];
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session["JournalVoucher"] = value;
        //    }
        //}

        //TODO: I am using it in JV to check the GL Date in GLHeader and Account in GL Lines..?
        public static CalendarViewModel Calendar
        {
            get
            {
                return HttpContext.Current.Session["Calendar"] == null ? new CalendarViewModel()
                    : (CalendarViewModel)HttpContext.Current.Session["Calendar"];
            }
            set
            {
                HttpContext.Current.Session["Calendar"] = value;
            }
        }
    }
}