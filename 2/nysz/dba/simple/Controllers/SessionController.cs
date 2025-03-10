using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

[Route("Session")]
public class SessionController : Controller
{
    [HttpPost("Login")]
    public IActionResult Login([FromForm] string UserName, [FromForm] string UserPassword)
    {
        using var connection = new SqliteConnection("Data Source=chinook.db");
        connection.Open();

        using var cmd = connection.CreateCommand();
        cmd.CommandText = "SELECT COUNT(*) FROM user WHERE UserName = @UserName AND UserPassword = @UserPassword";
        cmd.Parameters.AddWithValue("@UserName", UserName);
        cmd.Parameters.AddWithValue("@UserPassword", UserPassword);

        Int64 count = (Int64)cmd.ExecuteScalar();

        if (count > 0)
        {
            return Ok(new { message = "Login successful", user = UserName });
        }
        else
        {
            return Unauthorized(new { message = "Invalid credentials" });
        }
    }
}
