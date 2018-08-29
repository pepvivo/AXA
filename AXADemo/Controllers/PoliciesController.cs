using AXADemo.Config;
using AXADemo.Models;
using AXADemo.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AXADemo.Controllers
{
    /// <summary>
    /// Policies Controler Class
    /// </summary>
    [Authorize]
    [RoutePrefix("api/policies")]
    public class PoliciesController : ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Obtain a specific Policy referenced by Client Name
        /// Only for Administrators
        /// </summary>
        /// <param name="clientName"></param>
        /// <returns>Policy's register associated to client name</returns>
        [HttpGet]
        [Route("getbyclientname/{clientName}")]
        //eg: GET api/policies/getbyClientname/{clientName}
        [Authorize(Roles = AXADemoConfig.ROLE_ADMIN)]
        [ResponseType(typeof(List<Policy>))]
        public IHttpActionResult GetByClientName(string clientName)
        {
            log.Debug("begin");
            PoliciesManager policiesmanager = new PoliciesManager();
            List<Policy> policies = policiesmanager.GetByClientName(clientName);

            if (policies == null || policies.Count == 0)
                return Ok(default(Policy));


            log.Debug("end");
            return Ok(policies);
        }

        /// <summary>
        /// Obtain the client associated to a specific policy id
        /// Only for Administrators
        /// </summary>
        /// <param name="policyId"></param>
        /// <returns>Policies' array</returns>
        [HttpGet]
        [Route("getclient/{policyId}")]
        //eg: GET api/policies/getclient/{policyId}
        [Authorize(Roles = AXADemoConfig.ROLE_ADMIN)]
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetClient(string policyId)
        {
            log.Debug("begin");
            PoliciesManager policiesmanager = new PoliciesManager();
            Client cli = policiesmanager.GetClient(policyId);

            if (cli == null)
                return Ok(default(Client));

            log.Debug("end");
            return Ok(cli);
        }
    }
}
