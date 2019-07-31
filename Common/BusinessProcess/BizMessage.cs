using NLog;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Common.BusinessModels.Common;
using System.Reflection;
using PMS.Common.Logging;

namespace PMS.Common.BusinessProcess
{
    public class BizMessage : IProcessMessage
    {
        private string _loginId = string.Empty;
        private NameValueCollection _headers;

        public override Dictionary<string, string> MsgData
        {
            get;
            set;
        }

        public override bool IsSuccess { get; set; }
        public override string Message { get; set; }

        public override NameValueCollection Headers
        {
            get
            {
                return _headers;
            }
            set
            {
                _headers = value;
                if (_headers != null)
                {
                    string[] values = _headers.GetValues(Enums.Tag.UserID);

                    if (values != null && values.Length > 0)
                        _loginId = values[0];
                    values = _headers.GetValues("PermissionId");
                    if (values != null && values.Length > 0)
                        PermissionId = values[0];
                    values = _headers.GetValues("UserActionType");
                    if (values != null && values.Length > 0)
                        UserActionType = (UserActionType)Enum.Parse(typeof(UserActionType), values[0], true);
                }
            }
        }

        public override object MsgObjData
        {
            get;

            set;
        }

        public override Dictionary<string, object> MsgObjArray
        {
            get;
            set;
        }

        public override string LoginId
        {
            get
            {
                return _loginId;
            }
            set
            {
                _loginId = value;
            }
        }

        public override string EventOrigin
        {
            //get
            //{
            //    throw new NotImplementedException();
            //}

            //set
            //{
            //    throw new NotImplementedException();
            //}
            get;
            set;
        }

        public override string PermissionId
        {
            get;

            set;
        }

        public override UserActionType UserActionType
        {
            get;

            set;
        }

        public override PMSResponse PMSResponse
        {
            get;

            set;
        }
        public BizMessage()
        {
            MsgData = new Dictionary<string, string>();
        }

        public BizMessage(NameValueCollection headers)
        {
            MsgData = new Dictionary<string, string>();
            this.Headers = headers;
        }
        public BizMessage(System.Security.Principal.IIdentity Identity)
        {
            try
            {
                MsgData = new Dictionary<string, string>();
                var identity = Identity as System.Security.Claims.ClaimsIdentity;
                if (identity != null)
                {
                    this.Headers = new NameValueCollection();
                    foreach (System.Security.Claims.Claim claim in identity.Claims)
                    {
                        this.Headers.Add(claim.Type.ToString(), claim.Value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }
        public BizMessage(bool isSuccess, string message)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
        }

        public override void PopulateProcessMsgDict(object obj)
        {
            var type = obj.GetType();
            if (type.IsGenericType)
            {
                Dictionary<string, string> dKeyValue = new Dictionary<string, string>();
                dKeyValue = (Dictionary<string, string>)obj;
                foreach (var item in dKeyValue)
                {
                    this.MsgData.Add(item.Key, Convert.ToString(item.Value));
                }
            }
        }

        public override void InitParamsDic(object obj)
        {
            try
            {
                PropertyInfo[] piz = obj.GetType().GetProperties();

                foreach (PropertyInfo pi in piz)
                {
                    
                    this.MsgData.Add(pi.Name, Convert.ToString(pi.GetValue(obj)));
                }
            }
            catch (Exception ex)
            {
                ActivityLogger.Instance.SystemLog(LogLevel.Error, string.Format("Exception occurred in {0} ", MethodBase.GetCurrentMethod().Name), ActionType.CoreFunction.ToString(), this.GetType().FullName, string.Format("Exception: {0} | {1} | {2} ", ex.Message, ex.InnerException, ex.StackTrace), 0, ex);
            }
        }

        public override void InitParamsDic(NameValueCollection queryString)
        {
            try
            {
                foreach (KeyValuePair<string, string> item in queryString)
                {
                    this.MsgData.Add(item.Key, item.Value.ToString());
                }
            }
            catch (Exception ex)
            {
                ActivityLogger.Instance.SystemLog(LogLevel.Error, string.Format("Exception occurred in {0} ", MethodBase.GetCurrentMethod().Name), ActionType.CoreFunction.ToString(), this.GetType().FullName, string.Format("Exception: {0} | {1} | {2} ", ex.Message, ex.InnerException, ex.StackTrace), 0, ex);
            }
        }

        public BizMessage(Dictionary<string, string> MsgData, Object MsgObjData, Dictionary<string, object> MsgObjArray)
        {
            this.MsgData = MsgData;
            this.MsgObjData = MsgObjData;
            this.MsgObjArray = MsgObjArray;
        }

        //public BizMessage(Dictionary<string, string> MsgData, Object MsgObjData,NameValueCollection Headers)
        //{
        //    this.MsgData = MsgData;
        //    this.MsgObjData = MsgObjData;
        //    this.Headers = Headers;

        //}

        public override string GetParams(string Key)
        {
            throw new NotImplementedException();
        }

        public override void SetParam(string Key, string Value)
        {
            throw new NotImplementedException();
        }

    }
}
