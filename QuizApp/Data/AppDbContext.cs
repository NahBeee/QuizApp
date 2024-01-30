using Microsoft.EntityFrameworkCore;
using QuizApp.Models;
namespace QuizApp.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;Database=QuizApp;User=root;Password=11819981412Minnah@;Convert Zero Datetime=true;");
        }
    }
}
