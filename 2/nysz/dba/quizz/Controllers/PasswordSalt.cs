using System.Security.Cryptography;
using System.Text;

public static class PasswordSalt
{
    private static readonly string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    public static string GetSalt(int length = 4)
    {
        var sb = new StringBuilder();
        var rnd = new Random();
        for (int i = 0; i < length; i++)
        {
            sb.Append(chars[rnd.Next(chars.Length)]);
        }
        return sb.ToString();
    }

    public static string HashPassword(string password, string salt)
    {
        using (var sha256 = SHA256.Create())
        {
            var combined = password + salt;
            var bytes = Encoding.UTF8.GetBytes(combined);
            var hash = sha256.ComputeHash(bytes);
            return BitConverter.ToString(hash).Replace("-", "") + salt;
        }
    }

    public static bool VerifyPassword(string inputPassword, string storedHash)
    {
        if (storedHash.Length <= 4) return false;

        var salt = storedHash[^4..];
        var hashOfInput = HashPassword(inputPassword, salt);
        return hashOfInput == storedHash;
    }
}
