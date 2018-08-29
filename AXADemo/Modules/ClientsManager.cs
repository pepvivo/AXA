using AXADemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AXADemo.Modules
{
    /// <summary>
    /// Class for managing Clients
    /// </summary>
    public class ClientsManager
    {
        /// <summary>
        /// Obtain Client associated to an Id
        /// </summary>
        /// <param name="id">Id of client</param>
        /// <returns>Client register</returns>
        public Client GetById(string id)
        {
            return DataManager.GetInstance().Clients.FirstOrDefault(c => c.Id == id);
        }


        /// <summary>
        /// Obtain Client associated to a name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Client register</returns>
        public Client GetByName(string name)
        {
            return DataManager.GetInstance().Clients.FirstOrDefault(c => c.Name == name);
        }

        /// <summary>
        /// Obtain role of client
        /// </summary>
        /// <param name="name">Name of client</param>
        /// <returns>Role Name</returns>
        public string GetRole(string name)
        {
            return GetByName(name).Role;
        }
    }
}