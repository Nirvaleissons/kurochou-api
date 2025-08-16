namespace Kurochou.Domain.DTO.Auth.Response;

public record AuthResponseDto(string Token, int ExpiresInMinutes, string Role);
