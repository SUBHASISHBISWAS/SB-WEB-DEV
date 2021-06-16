using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using WebApiContrib.Formatting.Jsonp;
using System.Web.Http.Cors;

namespace SB_APIBasics
{
    public class CustomFormatter : JsonMediaTypeFormatter
    {
        public CustomFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }

        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, 
            MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
            headers.ContentType = new MediaTypeHeaderValue("application/json");
        }

    }

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.Filters.Add(new BasicAuthenticationAttribute());

            //config.Filters.Add(new RequireHTTPSAttribute());


            /*
            var jsonpFormatter = new JsonpMediaTypeFormatter(config.Formatters.JsonFormatter);
            config.Formatters.Insert(0, jsonpFormatter);
            */

            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);


            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Add(new CustomFormatter());
            
            //config.Formatters.Remove(config.Formatters.XmlFormatter);

            /*
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = 
                Formatting.Indented;
            
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
            */
        }
    }
}
