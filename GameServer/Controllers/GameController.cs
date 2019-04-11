using Microsoft.AspNetCore.Mvc;


namespace GameServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private Game game;

        public GameController()
        {
            game = new Game();
        }

        // GET: api/Game
        [HttpGet]
        public ActionResult<Game> GetGame()
        {
            return game;
        }
    }
}