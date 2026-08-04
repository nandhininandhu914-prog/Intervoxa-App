using System.ComponentModel.DataAnnotations;

namespace Intervoxa_application.Model
{
    public class CandidateModel
    {
        [Key]
        public int CandidateId { get; set; }

        [Required]
        public string CandidateName { get; set; }

        [Required]
        public string Email {  get; set; }

        [Required]
        public String MobileNo { get; set; }

        [Required]
        public int Experience {  get; set; }

        [Required]
        public string Position { get; set; }

        public string ? CurrentCompany { get; set; }

        public ICollection<ScheduleModel> InterviewModel { get; set; }=
            new List<ScheduleModel>();//one candidate can attend many interviews rounds



    }
}
