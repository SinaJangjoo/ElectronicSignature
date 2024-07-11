using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicSignature.Controllers
{
    public class SignatureController : Controller
    {
        [HttpPost]
        public IActionResult SaveSignature(string img)
        {
            if (!string.IsNullOrEmpty(img))
            {
                var base64Data = img.Split(',')[1];
                var bytes = Convert.FromBase64String(base64Data);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "signatures", "signature.png");

                System.IO.File.WriteAllBytes(filePath, bytes);

                // Optionally, you can save the file path or image bytes to the database here

                return Content("Success");
            }
            return BadRequest("Invalid data");
        }

        public IActionResult Signature()
        {
            return View();
        }
    }
}
