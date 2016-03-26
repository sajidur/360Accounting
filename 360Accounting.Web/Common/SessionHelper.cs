﻿using _360Accounting.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _360Accounting.Web
{
    public class SessionHelper
    {
        private const string Session_DocumentDate = "DocumentDate";
        private const string Session_Calendar = "Calendar";
        private const string Session_Receipt = "Receipt";
        private const string Session_Bank = "Bank";
        private const string Session_PrecisionLimit = "PrecisionLimit";
        private const string Session_SOBId = "SOBId";
        private const string Session_BankAccount = "BankAccount";
        private const string Session_JV = "JV";
        private const string Session_Tax = "Tax";
        private const string Session_Invoice = "Invoice";
        private const string Session_Remittance = "Remittance";
        private const string Sesson_Payment = "Payment";
        private const string Sesson_PayableInvoice = "PayableInvoice";

        public static PayableInvoiceModel PayableInvoice
        {
            get
            {
                return HttpContext.Current.Session[Sesson_PayableInvoice] == null ? null :
                    (PayableInvoiceModel)HttpContext.Current.Session[Sesson_PayableInvoice];
            }
            set
            {
                HttpContext.Current.Session[Sesson_PayableInvoice] = value;
            }
        }

        public static ReceiptModel Receipt
        {
            get
            {
                return HttpContext.Current.Session[Session_Receipt] == null ? null :
                    (ReceiptModel)HttpContext.Current.Session[Session_Receipt];
            }
            set
            {
                HttpContext.Current.Session[Session_Receipt] = value;
            }
        }

        public static BankAccountModel BankAccount
        {
            get
            {
                return HttpContext.Current.Session[Session_BankAccount] == null ? null :
                    (BankAccountModel)HttpContext.Current.Session[Session_BankAccount];
            }
            set
            {
                HttpContext.Current.Session[Session_BankAccount] = value;
            }
        }

        public static BankModel Bank
        {
            get
            {
                return HttpContext.Current.Session[Session_Bank] == null ? null :
                    (BankModel)HttpContext.Current.Session[Session_Bank];
            }
            set
            {
                HttpContext.Current.Session[Session_Bank] = value;
            }
        }

        public static RemittanceModel Remittance
        {
            get
            {
                return HttpContext.Current.Session[Session_Remittance] == null ? null :
                    (RemittanceModel)HttpContext.Current.Session[Session_Remittance];
            }
            set
            {
                HttpContext.Current.Session[Session_Remittance] = value;
            }
        }
        
        public static InvoiceModel Invoice
        {
            get
            {
                return HttpContext.Current.Session[Session_Invoice] == null ? null :
                    (InvoiceModel)HttpContext.Current.Session[Session_Invoice];
            }
            set
            {
                HttpContext.Current.Session[Session_Invoice] = value;
            }
        }

        public static TaxModel Tax
        {
            get
            {
                return HttpContext.Current.Session[Session_Tax] == null ? null :
                    (TaxModel)HttpContext.Current.Session[Session_Tax];
            }
            set
            {
                HttpContext.Current.Session[Session_Tax] = value;
            }
        }

        public static GLHeaderModel JV
        {
            get
            {
                return HttpContext.Current.Session[Session_JV] == null ? null :
                    (GLHeaderModel)HttpContext.Current.Session[Session_JV];
            }
            set
            {
                HttpContext.Current.Session[Session_JV] = value;
            }
        }

        public static PaymentViewModel Payment
        {
            get
            {
                return HttpContext.Current.Session[Sesson_Payment] == null ? null :
                    (PaymentViewModel)HttpContext.Current.Session[Sesson_Payment];
            }
            set
            {
                HttpContext.Current.Session[Sesson_Payment] = value;
            }
        }

        public static DateTime DocumentDate
        {
            get
            {
                return Convert.ToDateTime(HttpContext.Current.Session[Session_DocumentDate].ToString());
            }
            set
            {
                HttpContext.Current.Session[Session_DocumentDate] = value;
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

        public static long CodeCombinitionId
        {
            get
            {
                return Convert.ToInt64(HttpContext.Current.Session["CodeCombinitionId"].ToString());
            }
            set
            {
                HttpContext.Current.Session["CodeCombinitionId"] = value;
            }
        }

        public static long VendorId
        {
            get
            {
                return Convert.ToInt64(HttpContext.Current.Session["VendorId"].ToString());
            }
            set
            {
                HttpContext.Current.Session["VendorId"] = value;
            }
        }

        //TODO: this is temporary because of the issue 40 in task list.
        public static int PrecisionLimit
        {
            get
            {
                return Convert.ToInt32(HttpContext.Current.Session["PrecisionLimit"].ToString());
            }
            set
            {
                HttpContext.Current.Session["PrecisionLimit"] = value;
            }
        }

        //TODO: I am using it in JV to check the GL Date in GLHeader and Account in GL Lines..?
        public static CalendarViewModel Calendar
        {
            get
            {
                return HttpContext.Current.Session[Session_Calendar] == null ? null :
                    (CalendarViewModel)HttpContext.Current.Session[Session_Calendar];
            }
            set
            {
                HttpContext.Current.Session[Session_Calendar] = value;
            }
        }

        
    }
}