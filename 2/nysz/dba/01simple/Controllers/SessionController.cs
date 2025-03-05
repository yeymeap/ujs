using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
[Route("Controller")]
public class SessionController : Controller
{
    [HttpPost]
    [Route("Action")]
    public HttpRequest Login([FromForm] string UserName, [FromForm] string UserPassword)
    {
        using var connection = new SqliteConnection("Data Source=C:/Users/Student/Documents/b1/chinook.db");
        connection.Open();
        using var cmd = connection.CreateCommand();
        cmd.CommandText = "SELECT count(*) FROM user WHERE UserName=@UserName AND UserPassword=@UserPassword";
        cmd.Parameters.AddWithValue("UserName", UserName);
        cmd.Parameters.AddWithValue("UserPassword", UserPassword);
        using var reader = cmd.ExecuteReader();
        Int64 count = (long)cmd.ExecuteScalar();
        if (count > 0)
        {
            return new OkResult();
        }
        else
        {
            return new UnauthorizedResult();
        }
    }
}