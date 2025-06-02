using AuthApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginForm form)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7093/api/account/verify", form);

            if (response.IsSuccessStatusCode)
            {
                return Ok("Login successful"); // eller returnera token senare
            }

            return Unauthorized("Invalid credentials");
        }
    }
}
