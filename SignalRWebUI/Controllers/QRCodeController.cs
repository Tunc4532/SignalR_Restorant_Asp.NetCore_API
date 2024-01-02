using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace SignalRWebUI.Controllers
{
    public class QRCodeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string value)
        {

            using(MemoryStream memoryStream = new MemoryStream())
            {
                QRCodeGenerator createCRCode = new QRCodeGenerator();
                QRCodeGenerator.QRCode squarecode = createCRCode.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap image = squarecode.GetGraphic(10))
                {
                    image.Save(memoryStream, ImageFormat.Png);
                    ViewBag.QRCodeImage ="data:image/png;base64,"+Convert.ToBase64String(memoryStream.ToArray());
                }

            }
            return View();
        }
    }
}
