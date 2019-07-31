using PMS.Common.BusinessProcess;
using PMS.Common.Enums;

namespace PMS.Common
{
    public interface IProcessMsgRsp
    {
        void OnProcessed(int ChannelID, MessageType MessageType, IProcessMessage TranMessage, IProcessMessage ResponseMsg);
    }
}
