//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserNotificationType
    {
        public int UserNotificationTypeID { get; set; }
        public string NotificationCategory { get; set; }
        public string UserRole { get; set; }
        public int Level { get; set; }
        public Nullable<System.Guid> OrgRoleID { get; set; }
    }
}
