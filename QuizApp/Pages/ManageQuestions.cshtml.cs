using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizApp.Data;
using QuizApp.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace QuizApp.Pages
{
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class ManageQuestionsModel : PageModel
    {
        private readonly AppDbContext _context;
        public List<Question> Questions { get; set; }

        public ManageQuestionsModel(AppDbContext context)
        {
            _context = context;
        }
        public async Task OnGetAsync()
        {
            Questions = await _context.Questions.ToListAsync() ?? new List<Question>();
        }
        public async Task<IActionResult> OnPostAddQuestionAsync(string questionText)
        {
            try
            {
                if (_context.Database.GetDbConnection().State != ConnectionState.Open)
                {
                    Console.WriteLine("Database connection is not open.");
                }
                if (string.IsNullOrEmpty(questionText))
                {
                    // Handle the case where the question text is empty.
                    ModelState.AddModelError("questionText", "Question text cannot be empty.");
                    return Page();
                }

                var question = new Question { Text = questionText };

                _context.Questions.Add(question);
                await _context.SaveChangesAsync();

                await OnGetAsync();
                return RedirectToPage("./ManageQuestions");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                return Page();
            }
        }
    }
}
