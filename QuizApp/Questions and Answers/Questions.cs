using System.ComponentModel.DataAnnotations;

namespace QuizApp.Questions_and_Answers
{
    public class Questions
    {
        public int Id { get; set; }
        //Multi questions came from 1 quizz
        public int QuizzesId { get; set; }
        public Quizzes Quizzes { get; set; } = null;

        //1 Questions can have multi answer respones from user
        public ICollection<UserResponses> AnswerId { get; } = new List<UserResponses>();

        //1 Questions will have many answers to choose in database
        public ICollection<Answers> QuestionId { get; } = new List<Answers>();

        //1 Question only have 1 correct answer
        public int AnswersId { get; set; }
        public Answers Answers { get; set; } = null;

        public string Content { get; set; }
    }
}
