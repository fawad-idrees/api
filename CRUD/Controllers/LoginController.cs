using CRUD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CRUD.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _configuration;  
        public LoginController( IConfiguration confg) {


            _configuration = confg;
        }
        private User AuthenciateUsers(User user) {

            User usr = null;
           // if (user.UserName == "admin" && user.Password=="12345") {
            
            usr=new User() { UserName="administrator"};
            
       //     }
            return usr;

        }


        private string GenerateToken(User Usr)
        {

            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var Credentials = new SigningCredentials(securitykey,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["JWT:Issuer"], _configuration["JWT:Audience"], null,
                expires: DateTime.Now.AddMinutes(12),
                signingCredentials: Credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [AllowAnonymous]
        [HttpPost]
        public  IActionResult   Login(User user)
        {

            IActionResult respone = Unauthorized();
            var usr = AuthenciateUsers(user);
            if (usr!=null)
            {
                var token = GenerateToken(usr);
                respone = Ok(new { token = token });


            }
            return respone;


        }

    }
}
