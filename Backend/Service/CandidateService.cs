using Intervoxa_application.Data;
using Intervoxa_application.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Intervoxa_application.Service
{
    public class CandidateService : ICandidateService
    {
        private readonly AppDbContext db;

        public CandidateService(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<List<CandidateModel>> Getcandidate()
        {
            var candidate = await db.Candidates.ToListAsync();

            return candidate;
        }

        public async Task<CandidateModel> Addcandidate(CandidateDto candidate)
        {
            var cand = new CandidateModel
            {
                CandidateName = candidate.CandidateName,
                Email = candidate.Email,
                MobileNo = candidate.MobileNo,
                Experience = candidate.Experience,
                Position = candidate.Position
            };

            await db.Candidates.AddAsync(cand);

            await db.SaveChangesAsync();

            return cand;
        }

        public async Task<CandidateModel> Getbyid(int id)
        {
             return await db.Candidates.FirstOrDefaultAsync(x=>x.CandidateId == id); 
        }

        public async Task<CandidateModel> Editcandidate(int id,CandidateDto dto)
        {
            var cand= await db.Candidates.FirstOrDefaultAsync(x=>x.CandidateId==id);

            if(cand==null)
            {
                return null;
            }

            cand.CandidateName = dto.CandidateName;
            cand.Email = dto.Email;
            cand.MobileNo= dto.MobileNo;
            cand.Experience = dto.Experience;
            cand.Position=dto.Position;

            
            await db.SaveChangesAsync();

            return cand;
        }

        public async Task<bool> Deletecandidate(int id)
        {
            var cand = await db.Candidates
                .FirstOrDefaultAsync(
                    x => x.CandidateId == id);

            if (cand == null)
            {
                return false;
            }

            db.Candidates.Remove(cand);

            await db.SaveChangesAsync();

            return true;
        }
    }
}
