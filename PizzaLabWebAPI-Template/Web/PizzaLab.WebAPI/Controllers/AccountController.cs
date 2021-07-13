namespace PizzaLab.WebAPI.Controllers
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.JsonWebTokens;
    using Microsoft.IdentityModel.Tokens;
    using PizzaLab.WebAPI.Infrastructure.Helpers;
    using PizzaLab.WebAPI.ViewModels;
    using PizzaLab.WebAPI.ViewModels.Account.InputModels;
    using PizzaLab.WebAPI.ViewModels.Account.ViewModels;
    using PizzaLabWebAPI.Data.Models;

    using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    public class AccountController : ApiController
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly JWTSettings jwtSettings;
        private readonly IMapper mapper;

        public AccountController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IOptions<JWTSettings> jwtSettings,
            IMapper mapper)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.jwtSettings = jwtSettings.Value;
            this.mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<object> Login([FromBody]LoginInputModel model)
        {
            var user = this.userManager.Users.SingleOrDefault(r => r.Email == model.Email);

            if (user is null)
            {
                return this.BadRequest(new BadRequestViewModel
                {
                    Message = "Incorrect e-mail or password.",
                });
            }

            var result = await this.signInManager.PasswordSignInAsync(user.UserName, model.Password, false, false);

            if (result.Succeeded)
            {
                return new AuthenticationViewModel
                {
                    Message = "You have successfully loggged in.",
                    Token = this.GenerateJwtToken(model.Email, user),
                };
            }

            return this.BadRequest(new BadRequestViewModel
            {
                Message = "Incorrect e-mail or password.",
            });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<object> Register([FromBody] RegisterInputModel model)
        {
            var user = this.mapper.Map<ApplicationUser>(model);

            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await this.signInManager.SignInAsync(user, false);

                return new AuthenticationViewModel
                {
                    Message = "You habe successfully registered.",
                    Token = this.GenerateJwtToken(model.Email, user),
                };
            }

            return this.BadRequest(new BadRequestViewModel
            {
                Message = "Somethin went wrong. Check your form and try again.",
            });
        }

        private string GenerateJwtToken(string email, ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.NameId, user.Id),
                    new Claim("IsAdmin", this.userManager.IsInRoleAsync(user, "Administrator").GetAwaiter().GetResult().ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
