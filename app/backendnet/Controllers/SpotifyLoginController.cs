using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Web;

namespace backendnet.Controllers
{
    public class SpotifyLoginController : Controller
    {
        [Route("/SpotifyLogin")]
        [HttpGet]
        public IActionResult Index()
        {
            var loginRequest = new LoginRequest(
                new Uri("https://localhost:7106/"), "52865c00bb394a53a7247529b643415f"
                ,
                LoginRequest.ResponseType.Code
            )
            {
                Scope = new[] { Scopes.PlaylistReadPrivate, Scopes.PlaylistReadCollaborative }
            };
            var uri = loginRequest.ToUri();
            return Redirect(uri.ToString());
        }
    }
}
