

namespace PMS.Core
{
    class PMSCore
    {
        private static volatile bool IsStarted = false;

        private volatile static bool IsRunning = false;
        private static PMSCore _LogInstance = new PMSCore();

        //private static IBizMessageProcessor mProcessor = new BizMessageProcessor();
    }
}
