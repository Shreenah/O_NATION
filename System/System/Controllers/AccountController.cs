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
using Microsoft.EntityFrameworkCore;
using ontion.Models;
using System.Repository;

namespace System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly O_NATIONContext _context;
        private readonly SignInManager<User> _signInManager;

        //public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //}

        //public AccountController(O_NATIONContext context)
        //{
        //    _context = context;
        //}
       
        public AccountController(UserManager<User> userManager, IMapper mapper, IConfiguration config, SignInManager<User> signInManager, O_NATIONContext context)
        {
            _context = context;

            _userManager = userManager;
            _mapper = mapper;
            _config = config;
           _signInManager = signInManager;

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

        //[ApiController]
        //[Route("api/[controller]")]
        //public class ProfileController : ControllerBase
        //{
        //    private readonly IProfileRepository _profileRepository;

        //    public ProfileController(IProfileRepository profileRepository)
        //    {
        //        _profileRepository = p3rofileRepository;
        //    }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<User>> GetProfile(int id)
        //{
        //    var profile = await UserRepository.GetProfileById(id);
        //    if (profile == null)
        //    {
        //        return NotFound();
        //    }
        //    return profile;
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateProfile(int id, UserProfile profile)
        //{
        //    if (id != profile.UserId)
        //    {
        //        return BadRequest();
        //    }

        //    var existingProfile = await UserRepository.GetProfileById(id);
        //    if (existingProfile == null)
        //    {
        //        return NotFound();
        //    }

        //    existingProfile.UserName= profile.UserName;
        //    existingProfile.UserEmails = profile.UserEmails;
        //    existingProfile.UserPhones = profile.UserPhones;

        //    // Update other fields as needed

        //    await UserRepository.UpdateUser(existingProfile);
        //    return NoContent();
        //}
       
    }

}
    

