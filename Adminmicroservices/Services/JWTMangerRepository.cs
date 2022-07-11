using Adminmicroservices.Models;
using Adminmicroservices.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Adminmicroservices.Services
{
    public class JWTMangerRepository : IJWTMangerRepository
    {
        Dictionary<string, string> adminRecords;


        private readonly FlightDBContext admindb;

        private readonly IConfiguration configuration;

        public JWTMangerRepository(IConfiguration _configuration, FlightDBContext _admindb)
        {
            configuration = _configuration;
            admindb = _admindb;
        }
        public Tokens Authenticate(AdminLoginViewModel users, bool IsRegister)
        {
            if (IsRegister)
            {
                if (admindb.TbAdmins.Any(x => x.UserName == users.UserName))
                {
                    return null;
                }

                TbAdmin adminTb = new TbAdmin();
                adminTb.UserName = users.UserName;
                adminTb.Password = users.Password;
                admindb.TbAdmins.Add(adminTb);
                admindb.SaveChanges();
            }
            adminRecords = admindb.TbAdmins.ToList().ToDictionary(x => x.UserName, x => x.Password);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
            if (!adminRecords.Any(x => x.Key == users.UserName && x.Value == users.Password))
            {
                return null;
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {   
                Subject = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Name,users.UserName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }
        public List<TbAdmin> FindAll()
        {
            return admindb.TbAdmins.ToList();
        }
    }
}


