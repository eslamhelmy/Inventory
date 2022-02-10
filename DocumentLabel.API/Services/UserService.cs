using DocumentLabel.Domain.Interfaces;
using Inventory.API.Dtos;

using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;
using DocumentLabel.Domain;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace DocumentLabel.API.Services
{
    public class UserService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public UserService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<ResponseDto<string>> Login(string username)
        {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "zhic.local"))
            {
#pragma warning disable CA1416 // Validate platform compatibility
                var adUser = UserPrincipal.FindByIdentity(pc, username);
#pragma warning restore CA1416 // Validate platform compatibility
                if (adUser == null)
                    return new FailureResponseDto<string>()
                    {
                        Message = "you are not registered on AD"
                    };

                var repository = _unitOfWork.AsyncRepository<User>();
                var user = await repository.GetAsync(x=> x.Username == username); 
                if (user == null)
                {
                    await repository.AddAsync(new User { Username = username });
                    await _unitOfWork.SaveChangesAsync();
                }

                //generate jwt token
                var authClaims = new List<Claim>
                                    {
                                    new Claim(ClaimTypes.Name, username),
                                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                    };
               
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:SecretKey")));
                var token = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("JWT:ValidIssuer"),
                audience: _configuration.GetValue<string>("JWT:ValidAudience"),
                expires: DateTime.Now.AddDays(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

                var issuedToken = new JwtSecurityTokenHandler().WriteToken(token);

                return await Task.FromResult(new SuccessResponseDto<string>()
                {
                    Data = issuedToken
                });
            }
        }
    }
}


//// validate the credentials
//bool IsValid = pc.ValidateCredentials(email, password);

//if (IsValid)
//{
//    return true;
//}
//return false;
