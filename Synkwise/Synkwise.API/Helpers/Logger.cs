[assembly: log4net.Config.XmlConfigurator(Watch = false)]
namespace Synkwise.API.Helpers
{
    public static class Logger
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Log(string errorMessage)
        {
            logger.Error(errorMessage);
        }
    }
}
