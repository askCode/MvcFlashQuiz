using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlashQuiz_2ndAttempt.Models
{
    public class TakeQuizModel
    {
        public string Question { get; set; }
        public string Correct { get; set; }
        public string Wrong1 { get; set; }
        public string Wrong2 { get; set; }
        public string Wrong3 { get; set; }
    }
}