﻿using System.Net.Http.Headers;
using System.Web.Http;
namespace BookShop.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "BooksApi",
                routeTemplate: "Books/{action}/{filter}",
                defaults: new
                {
                    filter = "",
                    controller = "UpdateBooksGrid",
                    action = "PostBooks",
                }
            );
        }
    }
}