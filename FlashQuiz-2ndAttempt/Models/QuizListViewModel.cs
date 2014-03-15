using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlashQuiz_2ndAttempt.Models
{
    public class QuizListViewModel
    {
        public int Id { get; set; }
        public string QuizName { get; set; }
        public string QuizTopic { get; set; }
        public string CreatedBy { get; set; }
        public int NumberOfQuestions { get; set; }
    }
}