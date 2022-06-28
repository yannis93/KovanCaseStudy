using System.IdentityModel.Tokens.Jwt;
using System.Text;
using HotChocolate;
using KovanCaseStudy.Api.Jwt;
using KovanCaseStudy.Domain.Aggregates.UserAggregate;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace KovanCaseStudy.Api.GraphQLCore;

public class Mutation
{
    private List<User> Users = new List<User>() {
            
            new User("1","admin","admin")
        };
    public string UserLogin([Service] IOptions<TokenSettings> tokenSettings, LoginInput login)
    {
        var currentUser = Users.FirstOrDefault(_ => _.Username.ToLower() == login.Username.ToLower() &&
                                                    _.Password == login.Password);

        if (currentUser != null)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Value.Key));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                issuer: tokenSettings.Value.Issuer,
                audience: tokenSettings.Value.Audience,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);

        }
        return "";
    }
}