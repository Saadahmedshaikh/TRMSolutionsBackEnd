using DataAccessLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension.RigStatus
{
    public class RigStatusManager
    {

        //FINAL
        public List<sp_loadrigstatus_Result> getStatusByRig(string OrgNamePrm)
        {
            using (var db = new PrognosDBContext())
            {
              //  var orgunitid = db.OrgUnit.Single(ou => ou.OrgNamePrm == OrgNamePrm);
               // var orgid = orgunitid.OrgUnitID.ToString();
                var orgunitIdParameter = new SqlParameter("@orgunitid", OrgNamePrm);
                var result = db.Database
                    .SqlQuery<sp_loadrigstatus_Result>("sp_loadrigstatus @orgunitid", orgunitIdParameter)
                    .ToList();
                return result;
               
            }

    
        }
        public List<sp_LoadRigsByLoginID_Result> loadRigsByLoginID(string loginid)
        {
            using (var db = new PrognosDBContext())
            {


                var loginparameter = new SqlParameter("@loginid", loginid);
                var result = db.Database
                    .SqlQuery<sp_LoadRigsByLoginID_Result>("sp_LoadRigsByLoginID @loginid", loginparameter)
                    .ToList();
                return result;
            }
        }
        //Try

            
            public void updateStatus(RigStatusLog status)
        {
            using (var db = new PrognosDBContext())
            {
                db.RigStatusLog.Add(status);

                db.SaveChanges();
            }
        }
        public List<sp_LoadRigsByLoginID_Result> countRigs()
        {
            using (var ctx = new PrognosDBContext())
            {
                string query = @"SELECT RD.RigName
	                            ,RD.OrgUnitID
	                            ,RD.ISCountryRig
	                            ,RD.RigType
	                            ,RD.MaxStaticHookLoad
	                            ,Country.OrgNamePrm AS CountryName
	                            ,Country.OrgUnitId AS CountryOrgUnitID
                            FROM RigDetails RD
                            INNER JOIN OrgUnit Rigs ON Rigs.HierarchyLevel = 4
	                            AND RD.OrgUnitID = Rigs.ORgUnitID
                            INNER JOIN ORgUnit Country ON Country.HierarchyLevel = 3
	                            AND Rigs.ParentOrgID = Country.OrgUnitID
                            WHERE RD.OrgUnitID IN (
		                            SELECT rigs.OrgUnitID
		                            FROM OrgUSerRole OUR
		                            INNER JOIN OrgUnit rigs ON OUR.ORgUnitID = rigs.OrgUnitID
		                            WHERE OUR.LogINID = 'E151092'
			                            AND rigs.hierarchylevel = 4
		                            )

                            UNION ALL

                            SELECT RD.RigName
	                            ,RD.OrgUnitID
	                            ,RD.ISCountryRig
	                            ,RD.RigType
	                            ,RD.MaxStaticHookLoad
	                            ,Country.OrgNamePrm AS CountryName
	                            ,Country.OrgUnitId AS CountryOrgUnitID
                            FROM RigDetails RD
                            INNER JOIN OrgUnit Rigs ON Rigs.HierarchyLevel = 4
	                            AND RD.OrgUnitID = Rigs.ORgUnitID
                            INNER JOIN ORgUnit Country ON Country.HierarchyLevel = 3
	                            AND Rigs.ParentOrgID = Country.OrgUnitID
                            WHERE RD.OrgUnitID IN (
		                            SELECT rigs.OrgUnitID
		                            FROM OrgUSerRole OUR
		                            INNER JOIN OrgUnit WDI ON OUR.ORgUnitID = WDI.OrgUnitID
			                            AND WDI.Hierarchylevel = 3
		                            INNER JOIN OrgUnit rigs ON rigs.ParentOrgId = WDI.ORgUnitID
			                            AND Rigs.Hierarchylevel = 4
		                            INNER JOIN RigDetails RD ON RD.OrgUnitID = rigs.OrgUnitID
		                            WHERE LogINID = 'E151092'
			                            AND rigs.hierarchylevel = 4
		                            )

                            UNION ALL

                            SELECT RD.RigName
	                            ,RD.OrgUnitID
	                            ,RD.ISCountryRig
	                            ,RD.RigType
	                            ,RD.MaxStaticHookLoad
	                            ,Country.OrgNamePrm AS CountryName
	                            ,Country.OrgUnitId AS CountryOrgUnitID
                            FROM RigDetails RD
                            INNER JOIN OrgUnit Rigs ON Rigs.HierarchyLevel = 4
	                            AND RD.OrgUnitID = Rigs.ORgUnitID
                            INNER JOIN ORgUnit Country ON Country.HierarchyLevel = 3
	                            AND Rigs.ParentOrgID = Country.OrgUnitID
                            WHERE RD.OrgUnitID IN (
		                            SELECT rigs.OrgUnitID
		                            FROM OrgUSerRole OUR
		                            INNER JOIN OrgUnit WDI ON OUR.ORgUnitID = WDI.OrgUnitID
		                            INNER JOIN OrgUnit area ON area.ParentOrgId = WDI.ORgUnitID
			                            AND area.Hierarchylevel = 3
		                            INNER JOIN OrgUnit rigs ON rigs.ParentOrgId = area.ORgUnitID
			                            AND Rigs.Hierarchylevel = 4
		                            INNER JOIN RigDetails RD ON RD.OrgUnitID = rigs.OrgUnitID
		                            WHERE LogINID = 'E151092'
			                            AND rigs.hierarchylevel = 4
		                            )

                            UNION ALL

                            SELECT RD.RigName
	                            ,RD.OrgUnitID
	                            ,RD.ISCountryRig
	                            ,RD.RigType
	                            ,RD.MaxStaticHookLoad
	                            ,Country.OrgNamePrm AS CountryName
	                            ,Country.OrgUnitId AS CountryOrgUnitID
                            FROM RigDetails RD
                            INNER JOIN OrgUnit Rigs ON Rigs.HierarchyLevel = 4
	                            AND RD.OrgUnitID = Rigs.ORgUnitID
                            INNER JOIN ORgUnit Country ON Country.HierarchyLevel = 3
	                            AND Rigs.ParentOrgID = Country.OrgUnitID
                            WHERE RD.OrgUnitID IN (
		                            SELECT rigs.OrgUnitID
		                            FROM OrgUSerRole OUR
		                            INNER JOIN OrgUnit WDI ON OUR.ORgUnitID = WDI.OrgUnitID
		                            INNER JOIN OrgUnit area ON area.ParentOrgId = WDI.ORgUnitID
			                            AND area.Hierarchylevel = 2
		                            INNER JOIN OrgUnit country ON country.ParentOrgId = area.ORgUnitID
			                            AND Country.Hierarchylevel = 3
		                            INNER JOIN OrgUnit rigs ON country.ParentOrgId = area.ORgUnitID
			                            AND Rigs.Hierarchylevel = 4
		                            INNER JOIN RigDetails RD ON RD.OrgUnitID = rigs.OrgUnitID
		                            WHERE LogINID = 'E151092'
			                            AND rigs.hierarchylevel = 4
		                            )
                            ORDER BY RigName";
                var result = ctx.Database
                         .SqlQuery<sp_LoadRigsByLoginID_Result>(query)
                         .ToList();

                return result;
            }
        }
        
        public IEnumerable<AutoCompleteData> allRigs()
        {
            using (var ctx = new PrognosDBContext())
            {
                //var orgs = ctx.Database.SqlQuery<OrgUnit>("select top 10 ou.OrgNamePrm,ou.OrgUnitID,ou.HierarchyLevel from OrgUnit ou").ToList();
                var org = ctx.OrgUnit.Where(hl => hl.HierarchyLevel == 4).Select(hl =>
                 new AutoCompleteData()
                 {
                     OrgNamePrm = hl.OrgNamePrm,
                     HierarchyLevel = (int)hl.HierarchyLevel,
                     OrgUnitId = hl.OrgUnitID
                 }).OrderBy(hl=>hl.OrgNamePrm).ToList();

                return org;
            }
        }

    }

    public class AutoCompleteData
    {
        public string OrgNamePrm { get; set; }
        public Guid OrgUnitId { get; set; }
        public int HierarchyLevel { get; set; }
        
    }
}
