using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;

namespace WebApplication1.Controllers
{
    public class CustomFileController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Download(string customName, string customContent, string customFileName)
        {
            string fileContent = $"Custom Name: {customName}\nCustom Content: {customContent}";
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "CustomFiles");


            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(directoryPath, customFileName + ".txt");


            System.IO.File.WriteAllText(filePath, fileContent, Encoding.UTF8);

            return PhysicalFile(filePath, "text/plain", customFileName + ".txt");
        }
    }
}











