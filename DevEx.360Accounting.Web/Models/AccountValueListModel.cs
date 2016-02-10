﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevEx_360Accounting_Web.Models
{
    public class AccountValueListModel
    {
        private string sortColumn = "Segments";
        private string sortDirection = "ASC";

        #region Properties

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

        [Display(Name = "Set Of Books")]
        public List<SelectListItem> SetOfBooks { get; set; }

        public long SOBId { get; set; }

        public List<SelectListItem> Segments { get; set; }

        public string Segment { get; set; }

        public List<AccountValueViewModel> AccountValues { get; set; }

        #endregion
    }
}