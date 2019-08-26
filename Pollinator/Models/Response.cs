using System.Collections.Generic;

namespace Pollinator.Models
{
    public class Response
    {
        public int ResponseId {get;set;}
        public string Description {get;set;}
        public int UserId {get;set;}
        public ICollection<QuizResponse> Quizzes {get;set;}
    }
}