using System.Web.Http;

namespace AXADemo
{
    /// <summary>
    /// Static Class for Web Api Configuration
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Static nethod for register configuration
        /// </summary>
        /// <param name="config">HttpConfiguration configuration data</param>
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();


            // All parameters are required, or it won't match.
            // So it will only match URLs 4 segments in length
            // starting with /api.
            config.Routes.MapHttpRoute(
                name: "ApiByName",
                routeTemplate: "api/{controller}/{action}/{id}"
            );

            // Controller is required, id is optional.
            // So it will match any URL starting with
            // /api that is 2 or 3 segments in length.
            config.Routes.MapHttpRoute(
                name: "ApiById",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Remove XmlFormatter for returning json format (is default)
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
