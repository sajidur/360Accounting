﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _360Accounting.Web.Models
{
    public class CompanyListModel
    {
        public IEnumerable<CompanyModel> Companies { get; set; }
    }
}