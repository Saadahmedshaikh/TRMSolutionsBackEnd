
using PMS.Common;
using PMS.Common.BusinessProcess;
using PMS.Common.Enums;


namespace PMS.Core
{
    internal interface IBizMessageProcessor
    {
        void Init();

        IProcessMessage ProccessMessage(int ChannelID, MessageType MessageType, IProcessMessage msg);

        void ProccessMessageAsync(int ChannelID,
            MessageType MessageType, IProcessMessage msg, IProcessMsgRsp Callback);
    }
}
