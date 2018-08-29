using AXADemo.Config;
using AXADemo.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AXADemo.Modules
{
    /// <summary>
    /// Singleton Class for Application consuming data
    /// </summary>
    public class DataManager
    {
        private static DataManager Instance;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Initialize the alone Instance of class
        /// </summary>
        public static void InitInstance()
        {
            lock (typeof(DataManager))
            {
                Instance = new DataManager();
                log.Debug("DataManager Instance Initialized");
            }
        }

        /// <summary>
        /// Obtain class
        /// </summary>
        /// <returns>Singleton DataMAnager class</returns>
        public static DataManager GetInstance()
        {
            return Instance;
        }

        private DataManager()
        {
            LoadClients();
            LoadPolicies();
        }

        /// <summary>
        /// List of clients
        /// </summary>
        public List<Client> Clients
        {
            get;
            private set;
        }

        /// <summary>
        /// List of policies
        /// </summary>
        public List<Policy> Policies
        {
            get;
            private set;
        }

        private async Task<T> LoadArrayData<T>(string pathRemoteData, string propName)
        {
            HttpClient httpClient = new HttpClient();
            Uri uri = new Uri(pathRemoteData);
            HttpResponseMessage response = await httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {

                var jsonString = await response.Content.ReadAsStringAsync();
                JObject jsonResponse = JObject.Parse(jsonString);
                JArray objResponse = (JArray)jsonResponse[propName];
                return JsonConvert.DeserializeObject<T>(objResponse.ToString());
            }
            else
            {
                return default(T);
            }
        }


        private async void LoadClients()
        {
            log.Debug("begin");
            Clients = await LoadArrayData<List<Client>>(AXADemoConfig.GetInstance().ClientsServicePath, "clients");
            log.Debug(string.Format("Num. Clients reported = {0}", Clients.Count));
            log.Debug("end");
        }

        private async void LoadPolicies()
        {
            log.Debug("begin");
            Policies = await LoadArrayData<List<Policy>>(AXADemoConfig.GetInstance().PoliciesServicePath, "policies");
            log.Debug(string.Format("Num. Policies reported = {0}", Policies.Count));
            log.Debug("end");
        }
    }
}