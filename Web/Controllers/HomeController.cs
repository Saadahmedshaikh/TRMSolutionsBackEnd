﻿

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            //PrognosDBContext prognosdbcontext = new PrognosDBContext();

            
            //var temp = reh[0].RigEquipmentID.ToString();
            //Equipment equipment = prognosdbcontext.Equipment.Single(eq => eq.EquipmentID== new Guid("19EC63B4-17DB-4562-8065-00C028E2D335"));
            //var temp = equipment.EquipmentName.ToString();
            //string temp = JsonConvert.SerializeObject(prognosdbcontext.support_GetRigUserList() , Formatting.None);
            return Content("go to /User/");
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