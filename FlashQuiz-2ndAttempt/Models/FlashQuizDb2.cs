using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FlashQuiz_2ndAttempt.Models
{
    public class FlashQuizDb2 : DbContext
    {
        //Constructor to initialize the FlashQuizDb2 to connect to the
        //Database specified in the DefaultConnection string in Web.Config
        public FlashQuizDb2()
            : base("name=DefaultConnection")
        {

        }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }
    }
}