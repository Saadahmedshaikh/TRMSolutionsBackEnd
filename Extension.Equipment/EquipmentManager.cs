using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Classes;
using System.Data.SqlClient;
using System.Data;
using System.Web.Http.Cors;
using DAL;

namespace Extension.Equipment
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EquipmentManager
    {

        public List<EquipList> getAllEquipments()
        {
            using (var db = new TRMDbContext())
            {
                string query = "select (Select EquipmentCategoryName from EquipmentCategory where EquipmentCategoryID=eq.EquipmentCategoryID) as EquipmentCategoryName,* from Equipment eq order by eq.EquipmentName";
                var temp = db.Database.SqlQuery<EquipList>(query).ToList();
                    
                    
                 /*   Equipment.Select(eq => new EquipList
                {
                    EquipmentName = eq.EquipmentName,
                    FamilyName = eq.FamilyName,
                    Make = eq.Make,
                    Model = eq.Model,
                    Sequence = eq.SequenceNo.ToString()

                }).OrderBy(eq => eq.EquipmentName).ToList();*/
                return temp;
            }
        }

        public List<sp_getDetailsOfEquipment_Result> getDetailsOfEquipment(string EquipmentId)
        {
            using (var db = new TRMDbContext())
            {
                string query = @"select eq.EquipmentName	,eq.EquipmentType	,eq.EquipmentModel	,eq.EquipmentMake	,eq.EquipmentRange	,eq.EquipmentAccuracy	,eq.EquipmentOthers	,eq.EquipmentCustodian	,eq.EquipmentLocation	,eq.EquipmentFamilyName	,eq.AssetID	,eq.CreatedOn	,eq.CreatedBy,
eq.EquipmentCategoryID
,(Select EquipmentCategoryName from EquipmentCategory where EquipmentCategoryID=eq.EquipmentCategoryID) as 'EquipmentCategoryName'	
,eq.CompanyID
,(Select CompanyName  from Company  where CompanyID =eq.CompanyID) as 'CompanyName'
from Equipment eq 
where eq.EquipmentID=@equipID";
                var Eid = new SqlParameter("@equipID", EquipmentId);

                var temp=db.Database.SqlQuery<sp_getDetailsOfEquipment_Result>("sp_getDetailsOfEquipment @equipID", Eid).ToList();
                return temp; 
            }
        }

        public List<EquipSchedule> scheduleEquipment(string EquipmentId)
        {
            using (var db = new TRMDbContext())
            {
               // var query = db.EquipmentSchedule.Where(es => es.EquipmentID == new Guid(EquipmentId)).ToList();
                string query = @"select 
                                es.EquipmentScheduleID,
                                es.EquipmentScheduleName,
                                es.EquipmentScheduleType,
                                es.EquipmentScheduleBasis,	
                                es.Interval,	
                                es.Margin,	
                                es.Leverage
                                from EquipmentSchedule es 
                                where es.EquipmentID=@param1 ";
               var temp = db.Database.SqlQuery<EquipSchedule>(query, new SqlParameter("param1", EquipmentId)).ToList();
                return temp;
               
            }

        }

        public List<Specs> equipmentSpecification(string EquipmentId)
        {
            using (var db = new PrognosDBContext())
            {
                var query = @"select cs.SpecificationName,es.EquipmentSpecificationValue from
                            EquipmentSpecification es inner join
                            CategorySpecification cs on
                            es.CategorySpecificationID=cs.CategorySpecificationID
                            where es.EquipmentID=@EquipmentId and cs.SpecificationName != 'delete'";
                var temp = db.Database.SqlQuery<Specs>(query, new SqlParameter("EquipmentId", EquipmentId)).ToList();
                return temp;
            }
        }
        public string getAssetGroupName(string AssetId)
        {
            using (var db=new PrognosDBContext())
            {
                
                var a = db.Equipment.Where(eq => eq.EquipmentID == new Guid(AssetId)).Select(eqq => eqq.AssetGroupID).FirstOrDefault();
                var temp = db.AssetGroup.Where(ag => ag.AssetGroupID == a).Select(ag => ag.AssetGroupName).FirstOrDefault();
               // var temp = db.Equipment.Join(db.AssetGroup, eq => eq.AssetGroupID, ag => ag.AssetGroupID, (eq, ag) =>
                 //      new { Equipment = eq, AssetGroup = ag }).Where(ee => ee.Equipment.EquipmentID == new Guid(AssetId)).Select(s => s.AssetGroup.AssetGroupName).FirstOrDefault();
                return temp.ToString();
            }
        }
        public List<string> getAllAssetGroupName()
        {
            using (var db = new PrognosDBContext())
            {


                var temp = db.AssetGroup.Select(ag => ag.AssetGroupName).ToList();
                // var temp = db.Equipment.Join(db.AssetGroup, eq => eq.AssetGroupID, ag => ag.AssetGroupID, (eq, ag) =>
                //      new { Equipment = eq, AssetGroup = ag }).Where(ee => ee.Equipment.EquipmentID == new Guid(AssetId)).Select(s => s.AssetGroup.AssetGroupName).FirstOrDefault();
                return temp;
            }
        }
        public List<Category> getAllCategories()
        {
            using (var db = new TRMDbContext())
            {

                var temp = db.EquipmentCategory.Select(cat => new Category
                {
                    EquipmentCategoryID = cat.EquipmentCategoryID,
                    EquipmentCategoryName = cat.EquipmentCategoryName
                }).OrderBy(cat => cat.EquipmentCategoryName).ToList();
                
                return temp;
            }
        }
        public string countEquipments()
        {
            using (var db= new TRMDbContext())
            {
                var temp = db.Equipment.Count();
                return temp.ToString();
            }
        }
        public class EquipList
        {
            public Guid EquipmentID { get; set; }
            public string EquipmentName { get; set; }
            public string EquipmentType { get; set; }
            public string EquipmentModel { get; set; }
            public string EquipmentMake { get; set; }
            public string EquipmentRange { get; set; }
            public string EquipmentAccuracy { get; set; }
            public string EquipmentOthers { get; set; }
            public string EquipmentCustodian { get; set; }
            public string EquipmentLocation { get; set; }
            public string EquipmentFamilyName { get; set; }
            public string EquipmentCategoryName { get; set; }
            
        }
        public class Specs
        {
            public string SpecificationName { get; set; }
            public string EquipmentSpecificationValue { get; set; }
        }
        public class Category
        {
            public Guid EquipmentCategoryID { get; set; }
            public string EquipmentCategoryName { get; set; }

        }
    }
}
