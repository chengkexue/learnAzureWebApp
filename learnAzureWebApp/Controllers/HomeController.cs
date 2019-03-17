using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace learnAzureWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //AzureSQLHelp.execute("SELECT [AddressID],[AddressLine1],[AddressLine2],[City],[StateProvinceID],[PostalCode],[SpatialLocation],[rowguid],[ModifiedDate] FROM [Person].[Address]");
            AzureAdventureWorks2012Entities db = new AzureAdventureWorks2012Entities();
            List<Product> products = db.Product.ToList();
            int i = 0;
            foreach(Product product in products)
            {
                if (i >= 5) break;

                Response.Write("product id:" + product.ProductID + ", product name:" + product.Name + "<br>");
                i++;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}