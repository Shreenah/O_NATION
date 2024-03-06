using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using System.Models;
using System.Diagnostics.SymbolStore;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.DataTransferObject;

namespace System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public AccountController(UserManager<User> userManager, IMapper mapper, IConfiguration config)
        {
            _userManager = userManager;
            _mapper = mapper;
            _config = config;

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO registerUser)
        {
            if (ModelState.IsValid)
            {
                User user = _mapper.Map<User>(registerUser);


                var result = await _userManager.CreateAsync(user, registerUser.Password);
                if (result.Succeeded)
                {
                    return Ok("Account Added Success");
                }
                return BadRequest(result.Errors.ToList());
            }
            return BadRequest(ModelState);

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginUser)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(loginUser.UserName);
                if (user != null)
                {
                    bool found = await _userManager.CheckPasswordAsync(user, loginUser.Password);
                    if (found)
                    {
                        //token claims
                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                        var roles = await _userManager.GetRolesAsync(user);
                        foreach (var role in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role));
                        }

                        SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SecretKey"]));
                        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                        //create token 

                        JwtSecurityToken token = new JwtSecurityToken(
                            issuer: _config["JWT:issuer"],
                            audience: _config["JWT:issuer"],
                            claims: claims,
                            expires: DateTime.Now.AddDays(30),
                            signingCredentials: signingCredentials
                            );
                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        });



                    }

                }
                return Unauthorized();//401
            }
            return Unauthorized();//401
        }
    }
}

