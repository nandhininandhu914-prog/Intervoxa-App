using Intervoxa_application.Data;
using Intervoxa_application.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Intervoxa_application.Service
{
    public class InterviewerService:IinterviewerService
    {
        private readonly AppDbContext db;

        public InterviewerService(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<List<InterviewModel>> Getall()
        {
            var interviewer = await db.Interviews.ToListAsync();

            return interviewer;
        }

        public async Task<InterviewModel> Add(InterviewerDto dto)
        {
            var existingUser = await db.Users
                .FirstOrDefaultAsync(x => x.Email == dto.Email);

            if (existingUser != null)
            {
                throw new Exception("Email already exists.");
            }

            var user = new UserModel
            {
                Name = dto.InterviewerName,
                Email = dto.Email,
                Password = dto.Password,
                Role = "Interviewer"
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync(); // Generates UserId

            
            var inter = new InterviewModel
            {
                InterviewerName = dto.InterviewerName,
                Department = dto.Department,
                Experience = dto.Experience,
                Designation = dto.Designation,
                UserId = user.UserId
            };

            await db.Interviews.AddAsync(inter);
            await db.SaveChangesAsync();

            return inter;
        }

        public async Task<InterviewModel> GetByID(int id)
        {
            return await db.Interviews.FirstOrDefaultAsync(x => x.InterviewId == id);
        }

        public async Task<InterviewModel> Update(int id, InterviewerDto dto)
        {
            var inter = await db.Interviews
                .FirstOrDefaultAsync(x => x.InterviewId == id);

            if (inter == null)
            {
                return null;
            }

           inter.InterviewerName= dto.InterviewerName;
           inter.Department= dto.Department;
           inter.Experience= dto.Experience;
           inter.Designation= dto.Designation;


            await db.SaveChangesAsync();

            return inter;
        }

        public async Task<bool> Delete(int id)
        {
            var inter = await db.Interviews
                .FirstOrDefaultAsync(
                    x => x.InterviewId == id);

            if (inter == null)
            {
                return false;
            }

            db.Interviews.Remove(inter);

            await db.SaveChangesAsync();

            return true;
        }

    }
}
