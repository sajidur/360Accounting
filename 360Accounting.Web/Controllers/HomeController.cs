﻿using _360Accounting.Core.IService;
using _360Accounting.Data.Repositories;
using _360Accounting.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _360Accounting.Web.Controllers
{
    public class HomeController : Controller
    {
        private ICompanyService service;

        public HomeController()
        {
            service = new CompanyService(new CompanyRepository());
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}