using Intervoxa_application.Data;
using Intervoxa_application.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Intervoxa_application.Service
{
    public class LoginService:ILoginService
    {
        private readonly AppDbContext db;
        private readonly IConfiguration config;

        public LoginService(AppDbContext db, IConfiguration config)
        {
            this.db = db;
            this.config = config;
        }

        public async Task<LoginResponseDto> Login(LoginDto loginDto)
        {
            var user=await db.Users.FirstOrDefaultAsync
                (x=>x.Email==loginDto.Email &&
                 x.Password==loginDto.Password 
                );


            if(user==null)
            {
                return null;
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Role,user.Role),
                new Claim("UserId",user.UserId.ToString())
            };

            var interviewer = await db.Interviews.FirstOrDefaultAsync(
               x => x.UserId == user.UserId
            );

            var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
            config["Jwt:Key"]));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler()
                .WriteToken(token);

            return new LoginResponseDto
            {
                Token = tokenString,
                UserId = user.UserId,
                Name = user.Name,
                InterviewId = interviewer ?.InterviewId,
                Role = user.Role
            };

        }


    }


}
