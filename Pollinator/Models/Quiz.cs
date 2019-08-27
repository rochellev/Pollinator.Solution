using System.Collections.Generic;
namespace Pollinator.Models
{
    public class Quiz
    {
        public int QuizId {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public int AuthorId {get; set;}
<<<<<<< HEAD
        public virtual ICollection<QuizQuestion> Questions {get;set;}
        public virtual ApplicationUser User {get; set;}

        public Quiz()
        {
            this.Questions = new HashSet<QuizQuestion>();
        }
=======
        public string QuestionText {get;set;}
        public string AnswerA {get; set;}
        public string AnswerB {get; set;}
>>>>>>> eb2d6fa9c90b577951a3966370953e4ff3396b89
    }
}