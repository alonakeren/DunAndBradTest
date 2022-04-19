using System.Net.Http.Headers;
using System.Web.Http;

namespace DunBrad
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();

            config
                .Formatters
                .JsonFormatter
                .SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{action}/{id}/{Param}",
            defaults: new
            {
                id = RouteParameter.Optional,
                Param = RouteParameter.Optional
            }
         );
        }
    }
}


