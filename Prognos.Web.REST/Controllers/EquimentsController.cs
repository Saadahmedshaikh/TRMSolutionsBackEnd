using DAL;
using Extension.Equipment;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Prognos.Web.REST.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EquimentsController : ApiController
    {
        EquipmentManager equipmentmanager = new EquipmentManager();
        [HttpPost]
        [Route("Category/Update")]
        public HttpResponseMessage updateCategory(EquipmentCategory category)
        {
            try
            {
                using(var db = new TRMDbContext())
                {
                    EquipmentCategory cat = db.EquipmentCategory.Where(ec => ec.EquipmentCategoryID == category.EquipmentCategoryID).First();
                    cat.EquipmentCategoryImage = category.EquipmentCategoryImage;
                    cat.EquipmentCategoryName = category.EquipmentCategoryName;
                    cat.EquipmentCategoryDescription = category.EquipmentCategoryDescription;
                    db.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, category);
                    return message;
                }
            }catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpPost]
        [Route("Equipment/UpdateEquipment")]
        public HttpResponseMessage updateEquipment(Equipment equipment)
        {
            try
            {
                using (var db=new TRMDbContext()){

                    Equipment equip = db.Equipment.Where(eq => eq.EquipmentID == equipment.EquipmentID).First();
                    equip.EquipmentName = equipment.EquipmentName;
                    equip.EquipmentAccuracy = equipment.EquipmentAccuracy;
                    equip.EquipmentType = equipment.EquipmentType;
                    equip.AssetID = equipment.AssetID;
                    equip.EquipmentCustodian = equipment.EquipmentCustodian;
                    equip.EquipmentModel = equipment.EquipmentModel;
                    equip.EquipmentMake = equipment.EquipmentMake;
                    equip.EquipmentFamilyName = equipment.EquipmentFamilyName;
                    equip.EquipmentRange = equipment.EquipmentRange;
                    equip.EquipmentCategoryID = equipment.EquipmentCategoryID;
                    equip.EquipmentLocation = equipment.EquipmentLocation;
                    equip.EquipmentOthers = equipment.EquipmentOthers;
                    db.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, equipment);
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        
        [HttpPost]
        [Route("Equipment/AddNew")]
        public HttpResponseMessage addEquipment(Equipment equipment)
        {
            try
            {

                Guid eid = Guid.NewGuid();
                equipment.EquipmentID = eid;
                using (var db = new TRMDbContext())
                {
                    db.Equipment.Add(equipment);
                    db.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, equipment);
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        [HttpPost]
        [Route("Category/AddNew")]
        public HttpResponseMessage addCategory(EquipmentCategory category)
        {

            try
            {
                
                
                using (var db = new TRMDbContext())
                {
                    var name = new SqlParameter("@name",category.EquipmentCategoryName);
                    var desc = new SqlParameter("@description", category.EquipmentCategoryDescription);
                    var image = new SqlParameter("@image", category.EquipmentCategoryImage);
                    var temp = db.Database.SqlQuery<Guid?>("sp_insertcategory @name,@description,@image",name,desc,image).ToList();

                    var message = Request.CreateResponse(HttpStatusCode.Created,temp);
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }


        [HttpPost]
        [Route("Schedule/AddNew")]
        public HttpResponseMessage addSchedule(EquipmentSchedule schedule)
        {
            try
            {

                Guid sid = Guid.NewGuid();
                schedule.EquipmentScheduleID = sid;
                using (var db = new TRMDbContext())
                {
                    db.EquipmentSchedule.Add(schedule);
                    db.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, schedule);
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }



        [HttpGet]
        [Route("Equipment/getequipment")]
        public string GetEquipments()
        {

            return JsonConvert.SerializeObject(equipmentmanager.getAllEquipments(), Formatting.None);
        }
        [HttpGet]
        [Route("Equipment/getequipment/{id}")]
        public string GetEquipmentDetails(string id)
        {
            return JsonConvert.SerializeObject(equipmentmanager.getDetailsOfEquipment(id), Formatting.None);
        }

        [HttpGet]
        [Route("Equipment/scheduleEquipment/{id}")]
        public string scheduleEquipment(string id)
        {
            return JsonConvert.SerializeObject(equipmentmanager.scheduleEquipment(id), Formatting.None);
        }

        [HttpGet]
        [Route("Equipment/Specification/{id}")]
        public string equipmentSpecification(string id)
        {
            return JsonConvert.SerializeObject(equipmentmanager.equipmentSpecification(id), Formatting.None);
        }

        [HttpGet]
        [Route("Equipment/AssetGroup/{id}")]
        public string getAssetGroupName(string id)
        {
            return equipmentmanager.getAssetGroupName(id);
        }


        [HttpGet]
        [Route("Equipment/getAllAssetGroupName")]
        public string getAllAssetGroupName()
        {
            return JsonConvert.SerializeObject(equipmentmanager.getAllAssetGroupName(), Formatting.None);
        }
        [HttpGet]
        [Route("Equipment/getAllCategories")]
        public string getAllCategories()
        {
            return JsonConvert.SerializeObject(equipmentmanager.getAllCategories(), Formatting.None);
        }
        [HttpGet]
        [Route("Equipment/countEquipments")]
        public string countEquipments()
        {
            return equipmentmanager.countEquipments();
        }

        [HttpGet]
        [Route("Equipment/getCategory/{id}")]
        public string getCategory(string id)
        {
            return JsonConvert.SerializeObject(equipmentmanager.getCategory(id), Formatting.None);
        }
        

    }
}