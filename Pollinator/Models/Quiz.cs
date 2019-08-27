using System.Collections.Generic;
namespace Pollinator.Models
{
    public class Quiz
    {
        public int QuizId {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public int AuthorId {get; set;}
        public string QuestionText {get;set;}
        public string AnswerA {get; set;}
        public string AnswerB {get; set;}
    }
}