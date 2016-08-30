using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;

namespace FiscaWebApiRestService.Tests.Controllers
{
    public static class Helper
    {
        public static void SetupControllerForTests(ApiController controller, HttpMethod httpMethod, String controllerName)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(httpMethod, "http://localhost:8334/api" + controllerName);
            var route = config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary
            {
                {"id", Guid.Empty},
                {"controller", "organization"}
            });
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            UrlHelper urlHelper = new UrlHelper(request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
            /// inject a fake helper
            controller.Url = urlHelper;
        }
    }
}
