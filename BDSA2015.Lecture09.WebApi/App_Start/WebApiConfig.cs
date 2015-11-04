using BDSA2015.Lecture09.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace BDSA2015.Lecture09.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Customer>("Customer");
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: "api",
                model: builder.GetEdmModel());
        }
    }
}
