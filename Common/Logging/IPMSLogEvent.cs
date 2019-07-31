
namespace PMS.Common.Logging
{

    public enum LogType
    {
        System = 2,
        Activity = 3
    }

    public enum ActionType
    {
        View = 1,
        Add = 2,
        Edit = 3,
        Delete = 4,
        Undefined = 5,
        RdvServiceCall = 6,
        CoreFunction = 7,
        NimbusServiceCall = 8,
        Processing = 9
    }
    /*
      public interface IVisionLogEvent
      {
          LogEventInfo GetLogEvent(LogLevel level, string loggerName, string message,
              string Entity,
              string Action,
              string PrimaryKeyVals,
              string ChangedColVals,
              string CreatedBy,
              DateTime CreatedOn,
              string UpdateBy,
              DateTime UpdatedOn,
              string MachineName,            
              int Result,
              string EventOrigin,
              string Description,
              ActionType actionType,Exception ex);
      }*/
}
