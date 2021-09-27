using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace GatewayPagamento.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.Add(config.Formatters.JsonFormatter);

            config.Formatters.JsonFormatter
                .SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}