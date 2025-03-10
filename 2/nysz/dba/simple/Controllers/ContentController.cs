using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;
[Route("[controller]")]
public class ContentController : Controller
{
    [HttpGet]
    [Route("[action]")]
    public string ParIntro()
    {
        return "Lorem Ipsum";
    }

    [HttpGet]
    [Route("[action]")]
    public string ParFirst()
    {
        return "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas purus enim, tincidunt ac auctor in, vehicula sit amet neque. Quisque quis risus porta libero egestas posuere at in nunc.Donec ornare placerat mauris, ac";
    }

    [HttpGet]
    [Route("[action]")]
    public string CurrentTime()
    {
        return DateTime.Now.ToString("o");
    }

    [HttpGet]
    [Route("[action]/{FirstName}/{LastName}")]
    public string Welcome(string FirstName, string LastName)
    {
        return $"Hello {LastName} {FirstName}";
    }

    [HttpPost]
    [Route("[action]")]
    public string WelcomePost([FromForm] string FirstName, [FromForm] string LastName)
    {
        Int64 Counter = 500000;
        var SessionID = Request.Cookies["SessionID"];
        if (null != SessionID)
        {
            Counter = Int64.Parse(SessionID);
        }
        var options = new CookieOptions();
        options.Expires = new DateTime(2304, 12, 31);
        Response.Cookies.Append("SessionID", $"{Counter + 1}", options);
        return $"Hello {LastName} {FirstName}";

    }

    [HttpGet]
    [Route("[action]")]
    public JsonResult GetAlbumNames()
    {
        using var connection = new SqliteConnection("Data Source=C:/Users/Student/Documents/b1/chinook.db");
        connection.Open();
        using var cmd = connection.CreateCommand();
        cmd.CommandText = "SELECT Title, AlbumID FROM albums";
        using var reader = cmd.ExecuteReader();
        var titles = new List<string>();
        while (reader.Read())
        {
            var title = reader.GetString(0);
            titles.Add(title);
            Console.WriteLine(reader.GetString(0));
            // GetString(0) - title
            // GetString(1) - id
        }
        return new JsonResult(titles);
    }

    [HttpGet]
    [Route("[action]")]
    public JsonResult GetArtistNames()
    {
        using var connection = new SqliteConnection("Data Source=C:/Users/Student/Documents/b1/chinook.db");
        connection.Open();
        using var cmd = connection.CreateCommand();
        cmd.CommandText = "SELECT Name, ArtistID FROM artists";
        using var reader = cmd.ExecuteReader();
        var titles = new List<string>();
        while (reader.Read())
        {
            var title = reader.GetString(0);
            titles.Add(title);
            Console.WriteLine(reader.GetString(0));
            // GetString(0) - title
            // GetString(1) - id
        }
        return new JsonResult(titles);
    }
    public class Album
    {
        public string Title { get; set; } = "N/A";
        public Int64 AlbumId { get; set; } = -1;
    }


    [HttpGet]
    [Route("[action]/{AlbumId}")]
    public JsonResult GetAlbumById(string AlbumId)
    {
        using var connection = new SqliteConnection("Data Source=C:/Users/Student/Documents/b1/chinook.db");
        connection.Open();
        using var cmd = connection.CreateCommand();
        cmd.CommandText = "SELECT Title, AlbumId FROM Artists WHERE AlbumId=@AlbumId";
        cmd.Parameters.AddWithValue("@AlbumId", AlbumId);
        using var reader = cmd.ExecuteReader();
        var Albums = new List<string>();
        while (reader.Read())
        {
            var title = reader.GetString(0);
            var albumId = reader.GetInt64(1);
            Albums.Add(title);
            Console.WriteLine(reader.GetString(0));
            // GetString(0) - title
            // GetString(1) - id
        }
        return new JsonResult(Albums);
    }



}