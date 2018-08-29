using AXADemo.Config;
using AXADemo.Models;
using AXADemo.Modules;
using System.Web.Http;
using System.Web.Http.Description;

namespace AXADemo.Controllers
{
    /// <summary>
    /// Clients Controler Class
    /// </summary>
    [Authorize]
    [RoutePrefix("api/clients")]
    public class ClientsController : ApiController
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Obtain a specific Client associated to Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Client's register associated to id</returns>
        [HttpGet]
        [Route("{id}")]
        //eg: GET api/clients/{id}
        [Authorize(Roles = AXADemoConfig.ROLE_USER_ADMIN)]
        [ResponseType(typeof(Client))]
        public IHttpActionResult Get(string id)
        {
            log.Debug("begin");
            ClientsManager clientsmanager = new ClientsManager();
            Client cli = clientsmanager.GetById(id);
/*
            if (cli == null)
                return Ok(default(Client));
*/
            log.Debug("end");
            return Ok(cli);
        }


        /// <summary>
        /// Obtain an specific Client associated to a name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Client's register associated to a name</returns>
        [HttpGet]
        [Route("getbyname/{name}")]
        //eg: GET api/clients/getbyname/{name}
        [Authorize(Roles = AXADemoConfig.ROLE_USER_ADMIN)]
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetByName(string name)
        {
            log.Debug("begin");
            ClientsManager clientsmanager = new ClientsManager();
            Client cli = clientsmanager.GetByName(name);

            if (cli == null)
                return NotFound();

            log.Debug("end");
            return Ok(cli);
        }

    }
}
