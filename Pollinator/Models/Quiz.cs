using System.Collections.Generic;
namespace Pollinator.Models
{
    public class Quiz
    {
        public int QuizId {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public int AuthorId {get; set;}
        public virtual ICollection<QuizQuestion> Questions {get;set;}
        public virtual ApplicationUser User {get; set;}

        public Quiz()
        {
            this.Questions = new HashSet<QuizQuestion>();
        }
    }
}