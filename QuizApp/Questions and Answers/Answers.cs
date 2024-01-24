using System.ComponentModel.DataAnnotations;

namespace QuizApp.Questions_and_Answers
{
    public class Answers
    {
        public int Id { get; set; }
        //Multiple answers will be displayed on the screen for 1 questions
        public int QuestionsId { get; set; }
        public Questions Questions { get; set; } = null;

        //1 Question just have only 1 correct answer
        public ICollection<Questions> CorrectAnswerId { get; } = new List<Questions>();

        public string Content { get; set; }
    }
}
