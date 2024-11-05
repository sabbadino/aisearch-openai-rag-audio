using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Web;

namespace backendnet.Controllers
{
    public class SpotifyLoginController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public SpotifyLoginController ( IHttpContextAccessor httpContextAccessor,IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }
        [Route("/SpotifyLogin")]
        [HttpGet]
        public IActionResult Index()
        {
            var loginRequest = new LoginRequest(
                new Uri("https://localhost:7106/"), _configuration["spotify_client_id"]
                ,
                LoginRequest.ResponseType.Code
               
           )
            {
                Scope = new[] { Scopes.PlaylistReadPrivate, Scopes.PlaylistReadCollaborative }
            };
            var uri = loginRequest.ToUri();
            return Redirect(uri.ToString());
        }


        [Route("/")]
        [HttpGet]
        public async Task CallBack()
        {
            var code = _httpContextAccessor.HttpContext.Request.Query["code"];
            var response = await new OAuthClient().RequestToken(
    new AuthorizationCodeTokenRequest(_configuration["spotify_client_id"], _configuration["spotify_client_secret"], code, new Uri("https://localhost:7106/"))
  );
            var config = SpotifyClientConfig
              .CreateDefault()
              .WithAuthenticator(new AuthorizationCodeAuthenticator("ClientId", "ClientSecret", response));

            var spotify = new SpotifyClient(config);
        }
    }
}
