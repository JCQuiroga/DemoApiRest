using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using DemoApiRest.Extensiones;
using DemoApiRest.Models;

namespace DemoApiRest
{
    public static class WebApiConfig
    {
        //faltan metodos.

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.MessageHandlers.Add(new Loghandler());
            // Web API routes
            config.MapHttpAttributeRoutes();

            //Copiamos esto del controller con OData que hemos creado.
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Usuario>("Usuarios");
            builder.EntitySet<Mensaje>("Mensaje");

            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
