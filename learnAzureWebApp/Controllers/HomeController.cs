using learnAzureWebApp.Helper;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace learnAzureWebApp.Controllers
{
    public class HomeController : Controller
    {
        static CloudBlobClient blobClient;
        const string blobContainerName = "textfilecontainer";
        //const string blobName = "myblob";
        static CloudBlobContainer blobContainer;
        //public ActionResult Index()
        public async Task<ActionResult> Index()
        {
            AzureAdventureWorks2012Entities db = new AzureAdventureWorks2012Entities();
            List<Product> products = db.Product.ToList();
            int i = 0;
            foreach (Product product in products)
            {
                if (i >= 5) break;

                Response.Write("product id:" + product.ProductID + ", product name:" + product.Name + "<br>");
                i++;
            }
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"].ToString());

            blobClient = storageAccount.CreateCloudBlobClient();
            blobContainer = blobClient.GetContainerReference(blobContainerName);
            await blobContainer.CreateIfNotExistsAsync();

            await blobContainer.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            string blobName = "HelloWorld-" + GetTimeStamp();
            string sourceFile = Server.MapPath(blobName + ".txt");


            string outText = "Server time:" + DateTime.Now.ToUniversalTime().ToString() + ", Server Name:" + Server.MachineName;
            // Write text to the file.
            System.IO.File.WriteAllText(sourceFile, outText);

            CloudBlockBlob cloudBlockBlob = blobContainer.GetBlockBlobReference(blobName);
            var mode = System.IO.FileMode.CreateNew;
            await cloudBlockBlob.UploadFromFileAsync(sourceFile);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            try
            {
                Convert.ToInt32("aaa");
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(string.Format("当前的时间{0}", DateTime.Now.ToString()), ex);
            }

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }
    }
}