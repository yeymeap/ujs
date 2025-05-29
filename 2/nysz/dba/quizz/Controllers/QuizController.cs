using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Linq;

[Route("Quiz")]
public class QuizController : Controller
{
    private readonly string _dbPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "QuizDB.db"));
    private string _connstring => $"Data Source={_dbPath}";

    [HttpGet("questions")]
    public IActionResult GetQuestions()
    {
        var questions = new List<object>();

        using var conn = new SqliteConnection(_connstring);
        conn.Open();

        var idCmd = conn.CreateCommand();
        idCmd.CommandText = "SELECT Id FROM Questions ORDER BY RANDOM() LIMIT 10";

        var questionIds = new List<int>();
        using (var reader = idCmd.ExecuteReader())
        {
            while (reader.Read())
            {
                questionIds.Add(reader.GetInt32(0));
            }
        }

        if (!questionIds.Any())
        {
            return Json(questions);
        }

        var cmd = conn.CreateCommand();
        cmd.CommandText = $@"
        SELECT 
            q.Id AS QuestionId,
            q.QuestionText,
            q.Image,
            a.Id AS AnswerId,
            a.AnswerText,
            a.IsCorrect
        FROM Questions q
        JOIN Answers a ON a.QuestionId = q.Id
        WHERE q.Id IN ({string.Join(",", questionIds)})
        ORDER BY q.Id, RANDOM();";

        using var reader2 = cmd.ExecuteReader();

        int? currentQId = null;
        string currentQText = "";
        string currentQImage = null;
        List<object> currentAnswers = new();

        while (reader2.Read())
        {
            int qid = reader2.GetInt32(0);
            string qtext = reader2.GetString(1);
            string qimage = reader2.IsDBNull(2) ? null : reader2.GetString(2);
            int aid = reader2.GetInt32(3);
            string atext = reader2.GetString(4);

            if (currentQId != null && currentQId != qid)
            {
                var shuffledAnswers = currentAnswers.OrderBy(a => Guid.NewGuid()).ToList();

                questions.Add(new
                {
                    questionId = currentQId,
                    questionText = currentQText,
                    image = currentQImage,
                    answers = currentAnswers
                });

                currentAnswers = new List<object>();
            }

            currentQId = qid;
            currentQText = qtext;

            if (!string.IsNullOrEmpty(qimage))
            {
                string folderPrefix = "";
                if (qimage.StartsWith("ateszt1"))
                    folderPrefix = "ateszt";
                else if (qimage.StartsWith("bteszt1") || qimage.StartsWith("bteszt2") || qimage.StartsWith("bteszt3") || qimage.StartsWith("bteszt4"))
                    folderPrefix = "bteszt";

                currentQImage = $"/img/{folderPrefix}/{qimage}";
            }
            else
            {
                currentQImage = null;
            }

            currentAnswers.Add(new
            {
                answerId = aid,
                answerText = atext
            });
        }


        if (currentQId != null)
        {
            var shuffledAnswers = currentAnswers.OrderBy(a => Guid.NewGuid()).ToList();

            questions.Add(new
            {
                questionId = currentQId,
                questionText = currentQText,
                image = currentQImage,
                answers = currentAnswers
            });
        }

        return Json(questions);
    }


    [HttpPost("submit")]
    public IActionResult Submit([FromBody] List<UserAnswer> userAnswers)
    {
        int correctCount = 0;

        using var conn = new SqliteConnection(_connstring);
        conn.Open();

        foreach (var ua in userAnswers)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT IsCorrect FROM Answers WHERE Id = $answerId;";
            cmd.Parameters.AddWithValue("$answerId", ua.answerId);

            var isCorrectObj = cmd.ExecuteScalar();
            if (isCorrectObj != null && Convert.ToInt32(isCorrectObj) == 1)
            {
                correctCount++;
            }
        }

        var username = Request.Cookies["loggedInUser"];
        if (!string.IsNullOrEmpty(username))
        {
            var insertCmd = conn.CreateCommand();
            insertCmd.CommandText = @"
            INSERT INTO QuizResults (Username, Score, SubmittedAt)
            VALUES ($username, $score, $submittedAt);";
            insertCmd.Parameters.AddWithValue("$username", username);
            insertCmd.Parameters.AddWithValue("$score", correctCount);
            insertCmd.Parameters.AddWithValue("$submittedAt", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
            insertCmd.ExecuteNonQuery();
        }

        return Ok(new { score = correctCount, total = userAnswers.Count });
    }

    public class UserAnswer
    {
        public int questionId { get; set; }
        public int answerId { get; set; }
    }
}
