using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace learnAzureWebApp.Helper
{
    public class LogHelper
    {
        //public static readonly log4net.ILog logException = log4net.LogManager.GetLogger("AzureExceptionAppender");
        public static readonly log4net.ILog logException = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void WriteException(string info, Exception ex)
        {
            logException.Error(info, ex);
        }
    }
}