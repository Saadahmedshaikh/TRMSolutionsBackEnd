using NLog;
using System;
using System.Collections.Generic;


namespace PMS.Common.Logging
{
    public class ActivityLogger
    {
        private static ActivityLogger mInstance = null;

        public Logger logger;
        public LogLevel CurrentLogLevel { get; set; }
        public static ActivityLogger Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = new ActivityLogger();
                }

                return mInstance;
            }
        }

        public ActivityLogger()
        {
            //CurrentLogLevel = LogLevel.Info;
            string logLevel = string.Empty;
            IList<NLog.Config.LoggingRule> lstLoggingRules = LogManager.Configuration.LoggingRules;
            if (lstLoggingRules != null)
            {
                NLog.Config.LoggingRule loggingRule = lstLoggingRules[0];

                CurrentLogLevel = loggingRule.Levels[0];
            }

            //this.DefaultActType = myUnit.ActionType.GetByID("action_undefined");
            ////this.DefaultLogType = myUnit.LogType.GetByID("logtype_undefined");

            //this.DefaultActType = myUnit.ActionTypeRepository.GetByID("action_undefined");
            //this.DefaultLogType = myUnit.LogTypeRepository.GetByID("logtype_undefined");

            logger = LogManager.GetLogger("PMSWeb");
        }

        public void ActivityLog(LogLevel level, string message, string action, string primaryKeyVals, string changedColumn, string userId, string machineName, string eventOrigin, string description, ActionType actionType, int result, Exception ex = null)
        {
            ActivityLogEvent logEvent = new ActivityLogEvent();

            logger.Log(logEvent.GetLogEvent(level, "PMSWeb", message, "", action, primaryKeyVals, changedColumn, "", DateTime.Now, userId, DateTime.Now, machineName, result, eventOrigin, description, actionType, ex));
        }

        public void SystemLog(LogLevel level, string message, string action, string entityId, string userId, string machineName, string eventOrigin, string description, int result, Exception ex = null)
        {
            ActivityLogEvent logEvent = new ActivityLogEvent();

            logger.Log(logEvent.GetLogEvent(level, "PMSWeb", message, entityId, action, "", "", userId, DateTime.Now, userId, DateTime.Now, machineName, result, eventOrigin, description, ActionType.Undefined, ex));
        }
        public void SystemLog(LogLevel level, string message, string action, string eventOrigin, string description, int result, Exception ex = null)
        {
            ActivityLogEvent logEvent = new ActivityLogEvent();

            logger.Log(logEvent.GetLogEvent(level, "PMSWeb", message, "", action, "", "", "", DateTime.Now, "", DateTime.Now, "", result, eventOrigin, description, ActionType.Undefined, ex));
        }

    }
}
