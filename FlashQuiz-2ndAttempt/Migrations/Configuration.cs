namespace FlashQuiz_2ndAttempt.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FlashQuiz_2ndAttempt.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<FlashQuiz_2ndAttempt.Models.FlashQuizDb2>
    {
        public Configuration()
        {
            //Change it to false if migrations are done manually
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FlashQuiz_2ndAttempt.Models.FlashQuizDb2 context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //The r=>r.QuizName tries to find a quiz with the same name and tries to update it
            //If it doesn't exist then it will be added
            context.Quizzes.AddOrUpdate(r => r.QuizName,
                new Quiz { QuizName = "Quiz One", QuizTopic = "History", UserName = "Obama" },
                new Quiz { QuizName = "Quiz Two", QuizTopic = "Politics", UserName = "Ajit" },
                new Quiz { QuizName = "Quiz Three", QuizTopic = "Art", UserName = "Mohan" },
                new Quiz
                {
                    QuizName = "Quiz Four",
                    QuizTopic = "Technology",
                    UserName = "Obama",
                    QuizQuestions = new List<QuizQuestion> 
                                        {
                                            new QuizQuestion 
                                            { Question ="Which star does the Earth revolve around?", Answer = "Sun", WrongAnswer1 = "Moon", WrongAnswer2 = "Jupiter", WrongAnswer3 ="Saturn" },
                                            new QuizQuestion 
                                            { Question ="Steve Jobs founded this company?", Answer = "Apple", WrongAnswer1 = "Microsoft", WrongAnswer2 = "Intel", WrongAnswer3 ="Disney" },
                                            new QuizQuestion 
                                            { Question ="This company invented the Walkman music player", Answer = "Sony", WrongAnswer1 = "Samsung", WrongAnswer2 = "Microsoft", WrongAnswer3 ="Nintendo" }
                }
                });

        }
    }
}
