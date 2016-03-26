﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Accounting.Core.Entities
{
    public class Warehouse : EntityBase
    {
        [Key]
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public long SOBId { get; set; }
        public string WarehouseName { get; set; }
        public string Status { get; set; }
    }
}
