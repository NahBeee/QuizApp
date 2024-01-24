using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.Questions_and_Answers
{
    public class UserResponses
    {
        public int Id { get; set; }
        //Multi responses from user
        public int UsersId { get; set; }
        public Users Users { get; set; } = null;
        //Multi responses to quizzes questions
        public int QuizzesId { get; set; }
        public Quizzes Quizzes { get; set; } = null;

        //Muliplte response for single questions
        public int QuestionsId { get; set; }
        public Questions Questions { get; set; } = null;

        public int Timestamp { get; set; }
    }
}
