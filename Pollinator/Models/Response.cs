using System.Collections.Generic;

namespace Pollinator.Models
{
    public class Response
    {
        public int ResponseId { get; set; }
        public int QuizId { get; set; }
        public int UserId { get; set; }
        public string AnswerChoice { get; set; }
        public virtual Quiz Quiz { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}