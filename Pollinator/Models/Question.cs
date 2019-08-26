using System.Collections.Generic;

namespace Pollinator.Models
{
    public class Question
    {
        public int QuestionId {get; set;}
        public string Description {get; set;}
        public ICollection<QuizQuestion> Quizzes {get;}
    }
}