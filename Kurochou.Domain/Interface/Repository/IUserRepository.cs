using Kurochou.Domain.Model;

namespace Kurochou.Domain.Interface.Repository;

public interface IUserRepository : IRepository<User>
{
        Task<User?> GetByUsernameAsync(string username);
}