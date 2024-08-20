using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ReceptiNoviApp.Server.Data;
using ReceptiNoviApp.Shared;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Blazored.LocalStorage;
using ReceptiNoviApp.Client.Services.KorisnikServices;

namespace ReceptiNoviApp.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{

        

        public static Korisnik user = new Korisnik();
        private readonly DataContext Kontekst;
        public AuthController(DataContext kontekst)
        {
            Kontekst = kontekst;
        }

        [HttpPost("/api/Auth/register")]
        public async Task<ActionResult<Korisnik>> Register(KorisnikDTO request)
        {
            CreatePasswordHash(request.Password, out byte[] hash, out byte[] salt);

            user.Email = request.Email;
            user.Username = request.Username;
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            user.Role = "User";
            return Ok(user);
        }

        [HttpPost("/api/Auth/login")]

        public async Task<ActionResult<string>> Login(KorisnikDTO request)
        {
            user = Find(request);
            if (user.Username == "NEMA")
            {
                return BadRequest("User not found.");
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }
            string token = CreateToken(user);
            

            return Ok(token);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] hash, byte[] salt)
        {
            using (var hmac = new HMACSHA512(salt))
            {
                var compHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return compHash.SequenceEqual(hash);
            }
        }
        private string CreateToken(Korisnik user)
        {
            List<Claim> claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, Role(user))
                };
            
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("KLJUCTOKEN123456"));
            

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        private Korisnik Find(KorisnikDTO request)
        {
            Korisnik Nema = new Korisnik();
            Nema.Username = "NEMA";
            foreach (Korisnik k in Kontekst.Korisnici)
            {
                if (k.Username == request.Username)
                {
                    return k;
                }
            }
            return Nema;
        }

        private string Role(Korisnik korisnik)
        {
            if (korisnik.Role == "Admin")
                return korisnik.Role;
            else
                return korisnik.Role + korisnik.Id;
        }
    }

}
