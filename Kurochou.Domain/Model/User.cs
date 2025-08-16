using Kurochou.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kurochou.Domain.Model;

[Table("users")]
public class User : BaseEntity
{
        public string Username { get; init; } = string.Empty;
        public string PasswordHash { get; init; } = string.Empty;
        public UserRole Role { get; init; }
}
