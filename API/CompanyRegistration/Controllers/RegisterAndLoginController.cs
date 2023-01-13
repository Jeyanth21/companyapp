using CompanyRegistration.Manager;
using CompanyRegistration.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

using System.Linq;
using Microsoft.Extensions.Configuration;

namespace CompanyRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]

    public class RegisterAndLoginController : ControllerBase
    {    
        public IConfiguration Configuration { get; }


        private readonly IRegister _register;
        private readonly ILogger<RegisterAndLoginController> logger;
        public RegisterAndLoginController(IRegister register, ILogger<RegisterAndLoginController> logger, IConfiguration configuration)
        {
            _register = register;
            this.logger = logger;
            this.Configuration = configuration;
        }
      
        [HttpPost("CreateUserDetails")]
        [MapToApiVersion ("1.0")]
        public IActionResult Create([FromBody] UserDetailsRequest request)
        {
            try
            {
                logger.LogInformation("Creating User Details");

                var result = _register.Create(request);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An error has occured");
            }                
        }

        [HttpPost("login")]
        [MapToApiVersion("1.0")]
        public IActionResult Get( [FromBody] Login user)
        {
            var userdetails = _register.Getlogin(user.Email, user.Password);
            try
            {
                if (userdetails != null)
                {

                    LoginUserDetails loginUserDetails = new LoginUserDetails();
                    loginUserDetails.Email = userdetails.Email;
                    loginUserDetails.UserName = userdetails.UserName;
                    loginUserDetails.Id = userdetails.Id;

                    //  var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                   var secretKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("TokenSecretKey")));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    string Role = "Default";
                    var tokenClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim("Role", Role),
                new Claim("userid", user.Email),
               new Claim("name", userdetails.UserName)
            };
                    var tokeOptions = new JwtSecurityToken(
                      // issuer: "http://localhost:61605",
                      issuer:Configuration.GetSection("TokenSettings")["Issuer"],
                        //audience: "http://localhost:61605",
                        audience: Configuration.GetSection("TokenSettings")["Audience"],
                        tokenClaims,
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: signinCredentials
                    );;
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    loginUserDetails.Token = tokenString;
                    //return loginUserDetails;
                    return Ok(loginUserDetails);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch(Exception ex)
            {
                  return StatusCode(500, "An error has occured");
            }            
        }
    }
}
