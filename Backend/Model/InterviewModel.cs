using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intervoxa_application.Model
{
    public class InterviewModel
    {
        [Key]
        public int  InterviewId { get; set; }

        public string InterviewerName {  get; set; }

        public string Department {  get; set; }

        public int Experience {  get; set; }

        public string Designation {  get; set; }

        public int ? UserId {  get; set; }

        [ForeignKey("UserId")]
        public UserModel ? User { get; set; }
    }
}
