using System.ComponentModel.DataAnnotations;

namespace QuizApp.Questions_and_Answers
{
    public class Quizzes
    {
        public int Id { get; set; }
        //Multi Quizzes can be created by User
        public int UsersId { get; set; }
        public Users Users { get; set; } = null;

        //1 Quizzes can have multiple responses from user
        public ICollection<UserResponses> QuestionId { get; } = new List<UserResponses>();
        //1 Quizz can have multiple questions
        public ICollection<Questions> QuizId { get; } = new List<Questions>();

        //one to one relationship between quizz and question
        //public Questions? QuestionId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; } 
    }
}
