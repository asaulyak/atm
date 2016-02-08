using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;

namespace ATM_App
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                null,
                routeTemplate: "api/cards/{cardNumber}",
                defaults: new { controller = "Atm", action = "ValidateCardNumber" }
            );

            config.Routes.MapHttpRoute(
                null,
                routeTemplate: "api/cards/{cardNumber}/pin",
                defaults: new { controller = "Atm", action = "ValidatePin" }
            );

            config.Routes.MapHttpRoute(
                null,
                routeTemplate: "api/session/{sessionId}/balance",
                defaults: new { controller = "Atm", action = "GetBalance" }
            );

            config.Routes.MapHttpRoute(
                null,
                routeTemplate: "api/session/{sessionId}/close",
                defaults: new { controller = "Atm", action = "LogOut" }
            );

            config.Routes.MapHttpRoute(
                null,
                routeTemplate: "api/session/{sessionId}/withdraw",
                defaults: new { controller = "Atm", action = "WithdrawMoney" }
            );

            config.Routes.MapHttpRoute(
                null,
                routeTemplate: "api/operations/{operationId}",
                defaults: new { controller = "Atm", action = "GetOperation" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}


