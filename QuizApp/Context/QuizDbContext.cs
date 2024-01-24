using Microsoft.EntityFrameworkCore;
using QuizApp.Questions_and_Answers;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System;

namespace QuizApp.Context
{
    public class QuizDbContext : DbContext
    {
        public DbSet<Answers> Answers { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Quizzes> Quizzes { get; set; }
        public DbSet<UserResponses> UserResponses { get; set; }
        public DbSet<Users> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = master; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Answers>().HasData(
                new Answers {Id=1, Content = "This is first correct answer", QuestionsId= 1},
                new Answers {Id=2, Content = "This is second correct answer", QuestionsId = 1 },
                new Answers {Id=3, Content = "This is third correct answer", QuestionsId = 1 },
                new Answers {Id=4, Content = "This is fourth correct answer", QuestionsId = 1 }
                ) ;
            modelBuilder.Entity<Answers>()
                .HasOne(e => e.Questions)
                .WithMany(e => e.QuestionId)
                .HasForeignKey(e => e.QuestionsId)
                .IsRequired();
            modelBuilder.Entity<Answers>()
                .HasMany(e => e.CorrectAnswerId)
                .WithOne(e => e.Answers)
                .HasForeignKey(e => e.AnswersId)
                .IsRequired();


            modelBuilder.Entity<Questions>().HasData(
                new Questions { Id = 1, Content = "What is the first answer?", AnswersId = 1 },
                new Questions { Id = 2, Content = "What is the second answer?", AnswersId = 2 },
                new Questions { Id = 3, Content = "What is the third answer?", AnswersId = 3 },
                new Questions { Id = 4, Content = "What is the fourth answer?", AnswersId = 4 }
                );
            modelBuilder.Entity<Questions>()
                .HasOne(e => e.Quizzes)
                .WithMany(e => e.QuizId)
                .HasForeignKey(e => e.QuizzesId)
                .IsRequired();
            modelBuilder.Entity<Questions>()
                .HasMany(e => e.AnswerId)
                .WithOne(e => e.Questions)
                .HasForeignKey(e => e.QuestionsId)
                .IsRequired();
            modelBuilder.Entity<Questions>()
                .HasMany(e => e.QuestionId)
                .WithOne(e => e.Questions)
                .HasForeignKey(e => e.QuestionsId)
                .IsRequired();
            modelBuilder.Entity<Questions>()
                .HasOne(e => e.Answers)
                .WithMany(e => e.CorrectAnswerId)
                .HasForeignKey(e => e.AnswersId)
                .IsRequired();
            //one-to-one
            //modelBuilder.Entity<Questions>()
                //HasOne(e => e.Quizzes)
                //.WithOne(e => e.QuesionId)
                //.HasForeignKey<Quizzes>(e => e.QuizId)
                //.IsRequired();


            modelBuilder.Entity<Quizzes>()
                .HasData(new Quizzes { Id = 1, Description = "Quiz 1", Title="Quiz 1", UsersId =1});
            modelBuilder.Entity<Quizzes>()
                .HasOne(e => e.Users)
                .WithMany(e => e.CreatedBy)
                .HasForeignKey(e => e.UsersId)
                .IsRequired();
            modelBuilder.Entity<Quizzes>()
                .HasMany(e => e.QuestionId)
                .WithOne(e => e.Quizzes)
                .HasForeignKey(e => e.QuizzesId)
                .IsRequired();
            modelBuilder.Entity<Quizzes>()
                .HasMany(e => e.QuizId)
                .WithOne(e => e.Quizzes)
                .HasForeignKey(e => e.QuizzesId)
                .IsRequired();
            //one-to-one
            //modelBuilder.Entity<Quizzes>()
                //.HasOne(e => e.QuestionId)
                //.WithOne(e => e.Quizzes)
                //.HasForeignKey<Quizzes>(e => e.QuizId)
                //.IsRequired();


            modelBuilder.Entity<UserResponses>().HasData(
                new UserResponses { Id = 1, QuizzesId = 1, Timestamp = 1 }) ;
            modelBuilder.Entity<UserResponses>()
                .HasOne(e => e.Users)
                .WithMany(e => e.ResponseId)
                .HasForeignKey(e => e.UsersId)
                .IsRequired();
            modelBuilder.Entity<UserResponses>()
                .HasOne(e => e.Quizzes)
                .WithMany(e => e.QuestionId)
                .HasForeignKey(e => e.QuizzesId)
                .IsRequired();
            modelBuilder.Entity<UserResponses>()
                .HasOne(e => e.Questions)
                .WithMany(e => e.AnswerId)
                .HasForeignKey(e => e.QuestionsId)
                .IsRequired();

            modelBuilder.Entity<Users>()
                .HasData(new Users { Id = 1, Email = "user1@gmail.com", PasswordHash = "SHA", Username = "user1"});
            modelBuilder.Entity<Users>()
                .HasMany(e => e.CreatedBy)
                .WithOne(e => e.Users)
                .HasForeignKey(e => e.UsersId)
                .IsRequired();
            modelBuilder.Entity<Users>()
                .HasMany(e => e.ResponseId)
                .WithOne(e => e.Users)
                .HasForeignKey(e => e.UsersId)
                .IsRequired();

        }
    }
}
