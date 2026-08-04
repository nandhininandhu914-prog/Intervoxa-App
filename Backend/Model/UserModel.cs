using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Intervoxa_application.Model
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        public string Role {  get; set; }


        public ICollection<ScheduleModel> interviews { get; set; }=
            new List<ScheduleModel>();//one user can schedule many interview
    }
}
