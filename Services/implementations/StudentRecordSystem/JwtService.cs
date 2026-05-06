
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace StudentRecordSystem.Services
{
    public class JwtService (IConfiguration configuration)
    {

        //Token has 
        //issuer 
        //audience 
        //claim  = data; [ ] 
        //sign in key : validates the backend created the token 
        //expiere : when does the token expires 

        private readonly string secretkey = configuration["Jwt: SecretKey"]!; 
        
        public string GenerateToken()
        {
            //this is needed for signin credentials 
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretkey)); 
            //this is needed before creating the signin credentials
            var signingCredentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256); 
           var tokenObj = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: [],
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddMinutes(
                    Convert.ToDouble(configuration["Jwt:ExpiresInMinutes"])
                )
            );

            string token = new JwtSecurityTokenHandler().WriteToken(tokenObj); 
            return token; 
        
        }
}
}