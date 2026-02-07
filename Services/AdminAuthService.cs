namespace SpringRidgeFlowers.Services;

public class AdminAuthService
{
    private readonly IConfiguration _configuration;

    public AdminAuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public bool ValidatePassword(string password)
    {
        var storedHash = _configuration["AdminConfig:PasswordHash"];
        if (string.IsNullOrEmpty(storedHash))
            return false;

        try
        {
            return BCrypt.Net.BCrypt.Verify(password, storedHash);
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Helper method to generate a password hash. Call this once to generate a hash,
    /// then store the result in appsettings.json under AdminConfig:PasswordHash.
    /// </summary>
    public static string GeneratePasswordHash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
    }
}
