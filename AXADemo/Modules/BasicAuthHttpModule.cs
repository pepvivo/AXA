using AXADemo.Config;
using AXADemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;

namespace AXADemo.Modules
{
    /// <summary>
    /// BasicAuthHttpModule Class
    /// </summary>
    public class BasicAuthHttpModule : IHttpModule
    {
        private const string Realm = "AXARealm";
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Initialization of BasicAuthHttpModule class
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            log.Debug("begin");
            // Register event handlers
            context.AuthenticateRequest += OnApplicationAuthenticateRequest;
            context.EndRequest += OnApplicationEndRequest;
            log.Debug("end");
        }


        private static void SetPrincipal(IPrincipal principal)
        {
            log.Debug("begin");
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }

            if (principal != null)
                log.Debug(string.Format("User logged {0} is authenticated {1}", principal.Identity.Name, principal.Identity.IsAuthenticated));

            log.Debug("end");
        }

        private static bool CheckPassword(string username, string password, Client client)
        {
            if (client == null || string.IsNullOrEmpty(username))
                return false;

            return username.Equals(client.Name) && password == AXADemoConfig.GetInstance().UsersPassword;
        }

        private static void AuthenticateUser(string credentials)
        {
            log.Debug("begin");
            try
            {
                var encoding = Encoding.GetEncoding("iso-8859-1");
                credentials = encoding.GetString(Convert.FromBase64String(credentials));

                int separator = credentials.IndexOf(':');
                string name = credentials.Substring(0, separator);
                string password = credentials.Substring(separator + 1);

                var clientManager = new ClientsManager();
                var client = clientManager.GetByName(name);

                if (client == null)
                {
                    // Invalid username 
                    SetPrincipal(null);
                    HttpContext.Current.Response.StatusCode = 401;
                    log.Warn(string.Format("Invalid username '{0}",name));

                }

                if (CheckPassword(name, password, client))
                {
                    var identity = new GenericIdentity(name);
                    SetPrincipal(new GenericPrincipal(identity, new[] { client.Role }));
                }
                else
                {
                    // Invalid username or password.
                    HttpContext.Current.Response.StatusCode = 401;
                    log.Warn(string.Format("Invalid username '{0}", name));
                }
            }
            catch (FormatException ex)
            {
                // Credentials were not formatted correctly.
                HttpContext.Current.Response.StatusCode = 401;
                log.Warn("Credentials were not formatted correctly", ex);
            }

            log.Debug("end");
        }

        private static void OnApplicationAuthenticateRequest(object sender, EventArgs e)
        {
            log.Debug("begin");
            var request = HttpContext.Current.Request;
            var authHeader = request.Headers["Authorization"];
            if (authHeader != null)
            {
                var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

                // RFC 2617 sec 1.2, "scheme" name is case-insensitive
                if (authHeaderVal.Scheme.Equals("basic",
                        StringComparison.OrdinalIgnoreCase) &&
                    authHeaderVal.Parameter != null)
                {
                    AuthenticateUser(authHeaderVal.Parameter);
                }
            }
            log.Debug("end");
        }

        // If the request was unauthorized, add the WWW-Authenticate header 
        // to the response.
        private static void OnApplicationEndRequest(object sender, EventArgs e)
        {
            log.Debug("begin");

            var response = HttpContext.Current.Response;
            if (response.StatusCode == 401)
            {
                response.Headers.Add("WWW-Authenticate",
                    string.Format("Basic realm=\"{0}\"", Realm));
            }

            log.Debug("end");
        }

        /// <summary>
        /// Dispose class
        /// </summary>
        public void Dispose()
        {
        }
    }

}