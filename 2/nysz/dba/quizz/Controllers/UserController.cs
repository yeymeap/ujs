using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System.IO;

[Route("[controller]")]
public class UserController : Controller
{

    private readonly string _dbPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "QuizDB.db"));
    private string _connstring => $"Data Source={_dbPath}";

    [HttpPost("register")]
    public IActionResult Register([FromForm] string username, [FromForm] string password)
    {
        if (string.IsNullOrEmpty(password) || password.Length < 8)
        {
            return Content("Regisztráció nem sikerült. Jelszó minimum 8 karakternek kell lennie.");
        }

        string salt = PasswordSalt.GetSalt();
        string hashedPassword = PasswordSalt.HashPassword(password, salt);

        using (var connection = new SqliteConnection(_connstring))
        {

            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"INSERT INTO Users (Username, Password) 
                                    VALUES ($username, $password);";

            command.Parameters.AddWithValue("$username", username);
            command.Parameters.AddWithValue("$password", hashedPassword);

            Console.WriteLine("DB Path: " + _dbPath); // debug

            try
            {
                command.ExecuteNonQuery();
                return Content("Sikeres regisztráció!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // debug
                return Content("Nem sikerült regisztrálni." + ex.Message);

            }
        }
    }

    [HttpPost("login")]
    public IActionResult Login([FromForm] string username, [FromForm] string password)
    {
        using (var connection = new SqliteConnection(_connstring))
        {
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"SELECT Password FROM Users WHERE Username = $username;";
            command.Parameters.AddWithValue("$username", username);

            var storedHash = command.ExecuteScalar() as string;

            if (storedHash == null)
            {
                return Content("Hibás felhasználónév.");
            }

            bool valid = PasswordSalt.VerifyPassword(password, storedHash);

            if (valid)
            {
                var cookieValue = Guid.NewGuid().ToString();

                Response.Cookies.Append("loggedInUser", username, new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(1),
                    HttpOnly = true,
                    Secure = false
                });

                var insertSessionCmd = connection.CreateCommand();
                insertSessionCmd.CommandText = @"
                INSERT INTO UserSessions (Username, CookieValue, LoginTime) 
                VALUES ($username, $cookieValue, $loginTime);
            ";
                insertSessionCmd.Parameters.AddWithValue("$username", username);
                insertSessionCmd.Parameters.AddWithValue("$cookieValue", cookieValue);
                insertSessionCmd.Parameters.AddWithValue("$loginTime", DateTime.UtcNow);
                insertSessionCmd.ExecuteNonQuery();

                return Content("success");
            }
            else
            {
                return Content("Hibás jelszó.");
            }
        }

    }
    [HttpPost("logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("loggedInUser");
        return Content("logged-out");
    }


    [HttpGet("check")]
    public IActionResult CheckLogin()
    {
        var user = Request.Cookies["loggedInUser"];
        if (string.IsNullOrEmpty(user))
        {
            return Content("not-logged-in");
        }

        return Content(user);
    }

    [HttpGet("results")]
    public IActionResult GetQuizResults()
    {
        var username = Request.Cookies["loggedInUser"];
        if (string.IsNullOrEmpty(username))
        {
            return Unauthorized("Bejelentkezve kell lenned a kvíz előzmények megtekintéséhez");
        }

        var results = new List<object>();

        using var conn = new SqliteConnection(_connstring);
        conn.Open();

        var cmd = conn.CreateCommand();
        cmd.CommandText = @"
        SELECT Score, SubmittedAt
        FROM QuizResults
        WHERE Username = $username
        ORDER BY SubmittedAt DESC;";
        cmd.Parameters.AddWithValue("$username", username);

        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            results.Add(new
            {
                score = reader.GetInt32(0),
                submittedAt = reader.GetString(1)

            });
            Console.WriteLine($"username: '{username}' score: '{reader.GetInt32(0)}' submit: '{reader.GetString(1)}'"); // debug

        }

        if (results.Count == 0)
        {
            Console.WriteLine($"Checking quiz results for username: '{username}'"); // debug
        }

        return Json(results);
    }


}
