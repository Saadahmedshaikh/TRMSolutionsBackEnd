using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using System.Data.SqlClient;

namespace Extension.User
{
    public class UserManager
    {
        public string DeleteUser(string Id)
        {
            using (var db = new TRMDbContext())
            {

                CompanyUser emp = db.CompanyUser.Where(x => x.CompanyUserLoginID == Id).Single<CompanyUser>();
                db.CompanyUser.Remove(emp);
                db.SaveChanges();
                return "Record has successfully Deleted";
            }
        }
        public List<UserInfo> searchUsers(string id)
        {
            using(var db= new TRMDbContext())
            {
                string query = @"select 
cu.CompanyUserLoginID,
cu.CompanyUserPassword,
cu.CompanyUserName,
cu.CompanyUserEmail,
cu.CompanyUserPhone,
cu.CompanyUserStatus,
cm.CompanyName,
ur.UserRoleName
from CompanyUser cu inner join UserRole ur 
on cu.UserRoleID=ur.UserRoleID 
inner join Company cm 
on cm.CompanyID=cu.CompanyID
where ur.UserRoleName like '%'+@id+'%' OR 
cu.CompanyUserLoginID like '%'+@id+'%' OR 
cu.CompanyUserName like '%'+@id+'%' OR 
cu.CompanyUserEmail like '%'+@id+'%' OR
cm.CompanyName like '%'+@id+'%'  ";
                var IDparam = new SqlParameter("@id", id);
                var temp = db.Database.SqlQuery<UserInfo>(query, IDparam).ToList();
                return temp;
            }
        }
        public List<UserInfo> getAllUsers()
        {
            using (var db = new TRMDbContext())
            {
                string query = @"select us.CompanyUserLoginID,us.CompanyUserPassword,us.CompanyUserName
                  , us.CompanyUserEmail,us.CompanyUserPhone,us.CompanyUserStatus,(Select CompanyName from Company where CompanyID=us.CompanyID) as CompanyName,(Select UserRoleName from UserRole where UserRoleID=us.UserRoleId) as UserRoleName
                    from CompanyUser us ";
                var tem = db.Database.SqlQuery<UserInfo>(query).ToList();
                var temp = db.CompanyUser.Select(us => new UserInfo {
                   CompanyUserLoginID=us.CompanyUserLoginID,
                   CompanyUserPassword=us.CompanyUserPassword,
                   CompanyUserName=us.CompanyUserName,
                   CompanyUserEmail=us.CompanyUserEmail,
                   CompanyUserPhone=us.CompanyUserPhone,
                   CompanyUserStatus=us.CompanyUserStatus
                }).ToList();
                return tem;

            }
        }
        public List<CompanyInfo> getAllCompanies()
        {
            using(var db = new TRMDbContext())
            {
                var temp = db.Company.Select(cm => new CompanyInfo
                {
                    CompanyID = cm.CompanyID,
                    CompanyName = cm.CompanyName,
                     CompanyLocation= cm.CompanyLocation,
                     CompanyDescription=cm.CompanyDescription,
                     CompanyPhone=cm.CompanyPhone
                }).OrderBy(cm=>cm.CompanyName).ToList();
                return temp;
            }
        }
        public string countCountries()
        {
            using (var db = new TRMDbContext())
            {
                var temp = db.Company.Count();
                return temp.ToString();
            }
        }
        public string countUsers()
        {
            using (var db = new TRMDbContext())
            {
                var temp = db.CompanyUser.Count();
                return temp.ToString();
            }
        }
        public List<RoleInfo> getRoleNames()
        {
            using (var db = new TRMDbContext())
            {
                var temp = db.UserRole.Select(ur =>new RoleInfo {
                  UserRoleId=ur.UserRoleID.ToString(),
                  UserRoleName=ur.UserRoleName
                }).ToList();
                return temp;
            }
        }
    }
    public class RoleInfo
    {
        public string UserRoleId { get; set; }
        public string UserRoleName { get; set; }
    }
    
}
