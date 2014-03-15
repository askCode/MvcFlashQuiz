using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlashQuiz_2ndAttempt.Models
{
    public class Quiz
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "required")]
        [Display(Name = "Quiz Title")]
        public string QuizName { get; set; }

        [Required(ErrorMessage = "required")]
        [Display(Name = "Quiz Topic")]
        public string QuizTopic { get; set; }
        public string UserName { get; set; }

        //Todo remove virtual and use eager loading : http://msdn.microsoft.com/en-us/data/jj574232
        public virtual ICollection<QuizQuestion> QuizQuestions { get; set; }
    }
}