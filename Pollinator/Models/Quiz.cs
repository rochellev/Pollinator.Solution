using System.Collections.Generic;
namespace Pollinator.Models
{
    public class Quiz
    {
        public int QuizId {get; set;}
        public string QuestionText {get;set;}
        public string AnswerA {get; set;}
        public string AnswerB {get; set;}
        public virtual ICollection<Response> Responses { get; set; }
        public virtual ApplicationUser User {get; set;}

        public Quiz()
        {
            this.Responses = new HashSet<Response>();
        }
    }
}