using AntManZooApi.DTOs;
using AntManZooApi.Helpers;
using AntManZooApi.Repositories;
using AntManZooClassLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AntManZooApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IRepository<Staff> _staffRepository;
        private readonly AppSettings _settings;
        private readonly string _securityKey = "clé super secrète";
        public AuthenticationController(IRepository<Staff> staffRepository,
            IOptions<AppSettings> appSettings)
        {
            _staffRepository = staffRepository;
            _settings = appSettings.Value;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] Staff staff)
        {
            if (await _staffRepository.Get(u => u.Email == staff.Email) != null)
                return BadRequest("L'adresse mail est déjà utilisée");

            staff.Password = EncryptPassword(staff.Password);
            // pour restreindre la création d'admins : isAdmin = false

            if (await _staffRepository.Add(staff) > 0)
                return Ok("Personnel ajouté");
            return BadRequest("Something went wrong...");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO login)
        {
            login.Password = EncryptPassword(login.Password);

            var user = await _staffRepository.Get(u => u.Email == login.Email && u.Password == login.Password);

            if (user == null) return BadRequest("Authentification invalide!");

            //JWT
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            SigningCredentials signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_settings.SecretKey!)),
                SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: _settings.ValidIssuer,
                audience: _settings.ValidAudience,
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddDays(7)
                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Ok(new
            {
                Token = token,
                Message = "Authentification validée !",
                User = user
            });
        }

        // possible d'ajouter les actions de crud des users ici ou dans un controlleur UserController

        [NonAction]
        private string EncryptPassword(string? password)
        // il serait plus adapté de mettre ce genre de méthode dans un service dédié au chiffrage
        {
            if (string.IsNullOrEmpty(password)) return "";
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(password + _securityKey));
        }
    }
}
