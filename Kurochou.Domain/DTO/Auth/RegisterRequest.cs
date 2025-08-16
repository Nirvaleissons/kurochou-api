namespace Kurochou.Domain.DTO.Auth;

public record RegisterRequest(string Username, string Password, int Role);