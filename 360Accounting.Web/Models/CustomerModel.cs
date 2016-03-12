﻿using _360Accounting.Common;
using _360Accounting.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _360Accounting.Web.Models
{
    public class CustomerModel
    {
        public CustomerModel(Customer entity)
        {
            this.Address = entity.Address;
            this.ContactNo = entity.ContactNo;
            this.CustomerName = entity.CustomerName;
            this.EndDate = entity.EndDate;
            this.Id = entity.Id;
            this.StartDate = entity.StartDate;
        }

        public CustomerModel()
        {
            this.StartDate = Const.CurrentDate;
            this.EndDate = Const.EndDate;
        }

        public long Id { get; set; }
        
        public long CompanyId { get; set; }

        [Required]
        [Display(Name="Customer Name")]
        public string CustomerName { get; set; }

        public string Address { get; set; }

        [Display(Name = "Contact")]
        public string ContactNo { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
    }
}