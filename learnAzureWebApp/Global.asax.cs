using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using log4net;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

namespace learnAzureWebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        

        //public static readonly log4net.ILog Logger = log4net.LogManager.GetLogger("AzureExceptionAppender");
        //private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            log4net.Config.XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));
            TelemetryConfiguration.Active.InstrumentationKey = WebConfigurationManager.AppSettings["ikey"];
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            TelemetryClient telemetry = new TelemetryClient();

            ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Exception ex = Server.GetLastError();

            Logger.Error(ex.ToString(), ex);
            telemetry.TrackException(ex);
        }
    }
}
