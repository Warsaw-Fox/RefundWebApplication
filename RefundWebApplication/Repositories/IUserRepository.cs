using Microsoft.AspNetCore.Identity;

namespace RefundWebApplication.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAll();
    }
}