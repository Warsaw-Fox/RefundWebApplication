using RefundWebApplication.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace RefundWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRespository imageRespository;
        private readonly Cloudinary cloudinary;

        public ImagesController(IImageRespository imageRespository, IConfiguration configuration)
        {
            this.imageRespository = imageRespository;
            Account account = new Account(
            configuration["Cloudinary:CloudName"],
            configuration["Cloudinary:ApiKey"],
            configuration["Cloudinary:ApiSecret"]
        );
            cloudinary = new Cloudinary(account);
        }


        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error != null)
            {
                return Problem("Something went wrong!", null, (int)HttpStatusCode.InternalServerError);
            }

            // Pobierz publiczny adres URL przesłanego obrazka z Cloudinary
            var imageURL = uploadResult.SecureUrl.AbsoluteUri;

            // Wyświetl URL w konsoli
            Console.WriteLine("Uploaded Image URL: " + imageURL);

            return new JsonResult(new { link = imageURL });
        }

    }
}
