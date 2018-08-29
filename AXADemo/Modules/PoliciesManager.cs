using AXADemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AXADemo.Modules
{
    /// <summary>
    /// Class for managing Policies
    /// </summary>
    public class PoliciesManager
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Obtain a list of Policies searched by client Name
        /// </summary>
        /// <param name="clientName">Name of client</param>
        /// <returns></returns>
        public List<Policy> GetByClientName( string clientName)
        {
            log.Debug("begin");
            List<Client> clients = DataManager.GetInstance().Clients;
            List<Policy> policies = DataManager.GetInstance().Policies;

            var policiesByClientName = from cli in clients
                                       join pol in policies
                                       on cli.Id equals pol.ClientId
                                       where cli.Name == clientName
                                       select pol;

            log.Debug("end");
            return policiesByClientName.ToList();
        }

        /// <summary>
        /// Obtain Client register searched by policy Id
        /// </summary>
        /// <param name="policyId">Id of Policy</param>
        /// <returns></returns>
        public Client GetClient(string policyId)
        {
            log.Debug("begin");

            Policy policy = DataManager.GetInstance().Policies.FirstOrDefault( p => p.Id == policyId);

            log.Debug("end");

            return DataManager.GetInstance().Clients.FirstOrDefault(c => c.Id == policy.ClientId);
        }
    }
}