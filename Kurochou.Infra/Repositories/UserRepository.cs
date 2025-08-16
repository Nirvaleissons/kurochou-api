using Dapper;
using Kurochou.Domain.Interface.Repository;
using Kurochou.Domain.Model;
using System.Data;

namespace Kurochou.Infra.Repositories;

public class UserRepository(IDbConnection conn) : Repository<User>(conn), IUserRepository
{
        private readonly IDbConnection _conn = conn;
        
        public async Task<User?> GetByUsernameAsync(string username)
        {
                const string sql = @"
                    SELECT
                        username,
                        password_hash,
                        role
                    FROM users
                    WHERE username = @Username";
                
                return await _conn.QueryFirstOrDefaultAsync<User>(sql, new { Username = username }); 
        }
}