using Fit4You.Core.Domain;

namespace Fit4You.Core.Data.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        bool UserWithGivenEmailExists(string email);
        User GetByEmail(string username);
    }
}