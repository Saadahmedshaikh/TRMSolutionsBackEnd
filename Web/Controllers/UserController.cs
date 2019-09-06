
using DataAccessLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            PrognosDBContext prognosdbcontext = new PrognosDBContext();
            //string temp = JsonConvert.SerializeObject(prognosdbcontext.usp_ListAllSchedules("144","hot") , Formatting.None);
            return Content("try");

            //var temp = reh[0].RigEquipmentID.ToString();
            //Equipment equipment = prognosdbcontext.Equipment.Single(eq => eq.EquipmentID== new Guid("19EC63B4-17DB-4562-8065-00C028E2D335"));
            //var temp = equipment.EquipmentName.ToString();
           // string temp = JsonConvert.SerializeObject(prognosdbcontext.support_GetRigUserList(), Formatting.None);
            //return Content(temp);
        }
        [ActionName("find")]
        public string GetOrg(string id)
        {
            PrognosDBContext prognosdbcontext = new PrognosDBContext();
            OrgUnit org = prognosdbcontext.OrgUnit.Single(ou => ou.OrgNamePrm == id);

            var temp = org.OrgUnitID;
            IQueryable<RigStatusLog> query = prognosdbcontext.RigStatusLog.Where(rs => rs.OrgUnitID == temp);
            //var result = query.RigActivityStartDate.ToString();
            string result = JsonConvert.SerializeObject(query.ToArray());
            return result;


        }
    }
}