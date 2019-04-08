using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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