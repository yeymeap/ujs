using System.Text.Json;
using Microsoft.Data.Sqlite;

string dbPath = "C:/Bence/sje/2/nysz/dba/QuizDB_backup.db"; // <-- Update path!
string questionsJson = File.ReadAllText("questions.json");
string answersJson = File.ReadAllText("answers.json");

var questionsDoc = JsonDocument.Parse(questionsJson);
var answersDoc = JsonDocument.Parse(answersJson);
var correctAnswers = answersDoc.RootElement.GetProperty("correct_answers");

using var conn = new SqliteConnection($"Data Source={dbPath}");
conn.Open();

int index = 0;
foreach (var q in questionsDoc.RootElement.EnumerateArray())
{
    string questionText = q.GetProperty("question").GetString();
    string imagePath = "";
    if (q.TryGetProperty("image", out var imgProp))
    {
        imagePath = imgProp.GetString();
    }

    var insertQ = conn.CreateCommand();
    insertQ.CommandText = "INSERT INTO Questions (QuestionText, Image) VALUES ($text, $image)";
    insertQ.Parameters.AddWithValue("$text", questionText);
    insertQ.Parameters.AddWithValue("$image", imagePath);
    insertQ.ExecuteNonQuery();

    var getIdCmd = conn.CreateCommand();
    getIdCmd.CommandText = "SELECT last_insert_rowid();";
    long qid = (long)(getIdCmd.ExecuteScalar() ?? 0);

    var answers = q.GetProperty("answers").EnumerateArray().ToArray();
    string correct = correctAnswers[index].GetString(); // e.g., "b"
    int correctIndex = "abc".IndexOf(correct);

    for (int i = 0; i < answers.Length; i++)
    {
        var insertA = conn.CreateCommand();
        insertA.CommandText = "INSERT INTO Answers (QuestionId, AnswerText, IsCorrect) VALUES ($qid, $text, $isCorrect)";
        insertA.Parameters.AddWithValue("$qid", qid);
        insertA.Parameters.AddWithValue("$text", answers[i].GetString());
        insertA.Parameters.AddWithValue("$isCorrect", i == correctIndex ? 1 : 0);
        insertA.ExecuteNonQuery();
    }

    index++;
}

Console.WriteLine("Done.");
