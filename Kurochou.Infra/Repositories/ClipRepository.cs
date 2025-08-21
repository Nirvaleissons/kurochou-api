using Dapper;
using Kurochou.Domain.Interface.Repository;
using Kurochou.Domain.Model;
using System.Data;

namespace Kurochou.Infra.Repositories;

public class ClipRepository(IDbConnection conn) : Repository<Clip>(conn), IClipRepository
{
    private readonly IDbConnection _conn = conn;
    
}