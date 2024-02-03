using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace RefundWebApplication.Repositories
{
    public interface IImageRespository
    {
        Task<string> UploadAsync(IFormFile file);
    }
}
