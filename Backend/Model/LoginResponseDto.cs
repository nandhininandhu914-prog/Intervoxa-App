namespace Intervoxa_application.Model
{
    public class LoginResponseDto
    {
        public String Token {  get; set; }

        public int UserId {  get; set; }

        public int ? InterviewId {  get; set; }

        public string Name { get; set; }

        public string Role { get; set; }
    }
}
