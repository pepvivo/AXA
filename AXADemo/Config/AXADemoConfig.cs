using System;
using System.Configuration;

namespace AXADemo.Config
{
    /// <summary>
    /// Singleton Class for web configuration
    /// </summary>
    public class AXADemoConfig
    {
        private static AXADemoConfig Instance;

        private const string CLIENTS_SERVICE_PATH_DEF = "http://www.mocky.io/v2/5808862710000087232b75ac";
        private const string POLICIES_SERVICE_PATH_DEF = "http://www.mocky.io/v2/580891a4100000e8242b75c5";

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Role for administrators
        /// </summary>
        public const string ROLE_ADMIN = "admin";
        
        /// <summary>
            /// Role for users and administrators
        /// </summary>
        public const string ROLE_USER_ADMIN = "admin, user";

        /// <summary>
        /// Obtain class
        /// </summary>
        /// <returns>Singleton configuration class</returns>
        public static AXADemoConfig GetInstance()
        {
            lock (typeof(AXADemoConfig))
            {
                if (Instance == null)
                    Instance = new AXADemoConfig();

            }

            return Instance;
        }

        private AXADemoConfig() 
        {
            log.Debug("begin");

            Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/");

            if (rootWebConfig.AppSettings.Settings.Count > 0)
            {
                var Setting = rootWebConfig.AppSettings.Settings["ClientsServicePath"];
                ClientsServicePath = Setting != null ? Setting.Value.ToString() : CLIENTS_SERVICE_PATH_DEF;
                log.Debug(string.Format("ClientsServicePath setting initialized to=", ClientsServicePath));

                Setting = rootWebConfig.AppSettings.Settings["PoliciesServicePath"];
                PoliciesServicePath = Setting != null ? Setting.Value.ToString() : POLICIES_SERVICE_PATH_DEF;
                log.Debug(string.Format("PoliciesServicePath setting initialized to=", PoliciesServicePath));

                Setting = rootWebConfig.AppSettings.Settings["UsersPassword"];
                UsersPassword = Setting != null ? Setting.Value.ToString() : "password";
                log.Debug(string.Format("UsersPassword setting initialized to=", UsersPassword));

            }

            log.Debug("end");
        }

        /// <summary>
        /// General users password for this demo
        /// </summary>
        public string UsersPassword
        {
            get;
            private set;
        }

        /// <summary>
        /// String Property representing Clients Service Path
        /// </summary>
        public String ClientsServicePath
        {
            get;
            private set;
        }

        /// <summary>
        /// String Property representing Policies Service Path
        /// </summary>
        public String PoliciesServicePath
        {
            get;
            private set;
        }

    }
}