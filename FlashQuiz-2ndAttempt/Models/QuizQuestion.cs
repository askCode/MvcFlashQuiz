using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlashQuiz_2ndAttempt.Models
{
    public class QuizQuestion
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "field is required")]
        [StringLength(500)]
        public string Question { get; set; }

        [Required(ErrorMessage = "required")]
        [StringLength(500)]
        public string Answer { get; set; }

        [Required(ErrorMessage = "required")]
        [StringLength(500)]
        [Display(Name= "Wrong Answer 1")]
        public string WrongAnswer1 { get; set; }

        [Required(ErrorMessage="required")]
        [StringLength(500)]
        [Display(Name = "Wrong Answer 2")]
        public string WrongAnswer2 { get; set; }

        [Required(ErrorMessage = "required")]
        [StringLength(500)]
        [Display(Name = "Wrong Answer 3")]
        public string WrongAnswer3 { get; set; }

        public int QuizId { get; set; }

    }
}