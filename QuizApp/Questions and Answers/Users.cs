using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.Questions_and_Answers
{
    public class Users
    {
        public int Id { get; set; }
        //1 Users can create multi quizzes
        public ICollection<Quizzes> CreatedBy { get; } =new List<Quizzes>();
        //1 Users can have many responses
        public ICollection<UserResponses> ResponseId { get; } = new List<UserResponses>();

        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
    }
}
