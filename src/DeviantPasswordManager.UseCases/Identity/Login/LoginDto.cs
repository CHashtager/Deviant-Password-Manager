namespace DeviantPasswordManager.UseCases.Identity.Login;

public record LoginDto(string Token, string TokenType, int ExpiresIn);
