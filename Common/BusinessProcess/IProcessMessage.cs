using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Common.BusinessModels.Common;

namespace PMS.Common.BusinessProcess
{
    public abstract class IProcessMessage
    {
        public abstract Dictionary<string, string> MsgData { get; set; }
        public abstract NameValueCollection Headers { get; set; }
        public abstract bool IsSuccess { get; set; }
        public abstract string Message { get; set; }
        public abstract Dictionary<string, object> MsgObjArray { get; set; }
        public abstract string LoginId { get; set; }
        public virtual string MachineName
        {
            get
            {
                if (Headers == null)
                    return "";
                else
                    return Headers["IP"];
            }
        }
        public virtual string EntityId
        {
            get
            {
                if (Headers == null)
                    return "";
                else
                    return Headers[PMS.Common.Enums.Tag.EntityID];
            }
        }
        public abstract string EventOrigin { get; set; }
        public abstract string PermissionId { get; set; }
        public abstract UserActionType UserActionType { get; set; }
        public abstract PMSResponse PMSResponse { get; set; }


        public abstract Object MsgObjData { get; set; }
        public abstract string GetParams(string Key);
        public abstract void SetParam(string Key, string Value);
        public abstract void InitParamsDic(object obj);
        public abstract void InitParamsDic(NameValueCollection queryString);
        public abstract void PopulateProcessMsgDict(object obj);

    }
}
