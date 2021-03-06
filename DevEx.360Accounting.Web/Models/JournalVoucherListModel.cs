﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevEx_360Accounting_Web.Models
{
    public class JournalVoucherListModel
    {
        private string sortColumn = "";
        private string sortDirection = "ASC";

        #region Properties
        [Display(Name = "Set Of Book")]
        public List<SelectListItem> SetOfBooks { get; set; }

        public long SOBId { get; set; }

        [Display(Name = "Period")]
        public List<SelectListItem> Periods { get; set; }

        public long PeriodId { get; set; }

        [Display(Name = "Currency")]
        public List<SelectListItem> Currencies { get; set; }

        public long CurrencyId { get; set; }

        public List<JournalVoucherViewModel> JournalVouchers { get; set; }

        public string SearchText { get; set; }

        public int? Page { get; set; }

        public int TotalRecords { get; set; }

        public string SortColumn
        {
            get { return this.sortColumn; }
            set { this.sortColumn = value; }
        }

        public string SortDirection
        {
            get { return this.sortDirection; }
            set { this.sortDirection = value; }
        }
        #endregion
    }
}