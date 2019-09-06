using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DataAccessLayer;
using Newtonsoft.Json;
using Extension.RigStatus;
using System.Web.Http.Cors;
using Extension.Equipment;

namespace Prognos.Web.REST.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RigStatusLogsController : ApiController
    {

        RigStatusManager rigstatusmanager = new RigStatusManager();
        private PrognosDBContext db = new PrognosDBContext();
        
        //Final
        [Route("RigStatusLog/GetRigStatusLog/{id}")]
        public string GetRigStatusLog(string id)
        {
            return JsonConvert.SerializeObject(rigstatusmanager.getStatusByRig(id), Formatting.None);

        }
        




        [HttpGet]
        [Route("RigStatusLog/loadrigsbyloginid/{id}")]
        public string loadRigsByLoginID(string id)
        {
            return JsonConvert.SerializeObject(rigstatusmanager.loadRigsByLoginID(id), Formatting.None);
        }
    




       [HttpPost]
       [Route("RigStatusLog/updateStatus")]
        public HttpResponseMessage updateStatus(RigStatusLog status)
        {
            try { 
            var id = status.OrgUnitID;
            Guid rsid = Guid.NewGuid();
            status.RigStatusLogiID = rsid;
            
            using (var db = new PrognosDBContext())
            {
                db.RigStatusLog.Add(status);
                db.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, status);
                    return message;
            }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
          

        } 
        



       
        [HttpGet]
        [Route("RigStatusLog/allrigs")]
        public string allRigs()
        {
            return JsonConvert.SerializeObject(rigstatusmanager.allRigs(), Formatting.None); 
        }





        [HttpGet]
        [Route("RigStatusLog/countrigs")]
        public string countRigs()
        {
            return JsonConvert.SerializeObject(rigstatusmanager.countRigs(), Formatting.None);

        }

       


        

    }
}