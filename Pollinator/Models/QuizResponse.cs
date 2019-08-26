namespace Pollinator.Models
{
    public class QuizResponse
    {
        public int QuizResponseId {get; set;}
        public int QuizId {get; set;}
        public int ResponseId {get; set;}
        public Quiz Quiz {get; set;}
        public Response Response {get; set;}
    }
}