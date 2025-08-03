namespace Kurochou.Domain.DTO.Auth;

public record AuthResponseDTO(string Token, int ExpiresInMinutes, string Role);
