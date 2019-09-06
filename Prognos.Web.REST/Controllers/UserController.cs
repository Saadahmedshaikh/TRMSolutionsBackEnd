using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Extension.User;
using Newtonsoft.Json;
using DAL;
using System.IO;

namespace Prognos.Web.REST.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        UserManager user = new UserManager();
        [HttpGet]
        [Route("User/getall")]
        public string getAllUsers()
        {
            return JsonConvert.SerializeObject(user.getAllUsers(), Formatting.None);

        }

        [HttpGet]
        [Route("User/search/{id}")]
        public string searchUsers(string id)
        {
            return JsonConvert.SerializeObject(user.searchUsers(id), Formatting.None);

        }

        [HttpDelete]
        [Route("User/delete/{id}")]
        public string DeleteEmploye(string id)
        {
            return user.DeleteUser(id);
        }


        [HttpGet]
        [Route("Company/getall")]
        public string getAllCompanies()
        {
            return JsonConvert.SerializeObject(user.getAllCompanies(), Formatting.None);

        }

        [HttpPost]
        [Route("Country/Add")]
        public HttpResponseMessage addCompany(Company company)
        {
            try
            {

                Guid cid = Guid.NewGuid();
                company.CompanyID = cid;

                using (var db = new TRMDbContext())
                {
                    db.Company.Add(company);
                    db.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, company);
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }


        }

        [HttpPost]
        [Route("User/Add")]
        public HttpResponseMessage addUser(CompanyUser user)
        {
            try
            {


                using (var db = new TRMDbContext())
                {
                    db.CompanyUser.Add(user);
                    db.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, user);
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.ToString());
                // var message = Request.CreateResponse(HttpStatusCode.Created, ex);
                //return message;
            }


        }
        [HttpGet]
        [Route("Country/Count")]
        public string countCompanies()
        {
            return user.countCountries();
        }
        [HttpGet]
        [Route("User/Count")]
        public string countUsers()
        {
            return user.countUsers();
        }

        [HttpGet]
        [Route("Roles/getRoleNames")]
        public string getRoleNames()
        {
            return JsonConvert.SerializeObject(user.getRoleNames(), Formatting.None);
        }
        [HttpGet]
        [Route("Roles/move")]
        public void move()
        {
            
            string path = @"C:\Users\E242438\Desktop\dateissue.png";

            string path2 = @"C:\Users\E242438\Desktop\abc\dateissue.png";

            if (!File.Exists(path))
            {
                // This statement ensures that the file is created,
                // but the handle is not kept.
               using (FileStream fs = File.Create(path)) { }
            }

            // Ensure that the target does not exist.
            if (File.Exists(path2))
                File.Delete(path2);

            // Move the file.
            File.Move(path, path2);


        }
    }
}
