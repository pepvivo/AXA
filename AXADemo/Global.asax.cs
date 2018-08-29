using AXADemo.Modules;
using System.Web.Http;
using System.Web.Mvc;

namespace AXADemo
{
    /// <summary>
    /// Main Web Api Application 
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Initial Method
        /// </summary>
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();

            log.Debug("begin");

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            DataManager.InitInstance();

            log.Debug("end");
        }
    }
}
