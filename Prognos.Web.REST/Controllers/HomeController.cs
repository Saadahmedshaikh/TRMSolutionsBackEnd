using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace Prognos.Web.REST.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        [HttpGet]
        [Route("common/getorgunitid/{id}")]
        public string getOrgUnitId(string id)
        {
            using (var db = new PrognosDBContext())
            {
                var orgunitid = db.OrgUnit.Single(ou => ou.OrgNamePrm == id);
                return orgunitid.ToString();
            }
        }
    }
}
