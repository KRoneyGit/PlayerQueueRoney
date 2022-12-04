using Microsoft.AspNetCore.Mvc;
using PlayerQueueRoney.Models;
using System.Diagnostics;

namespace PlayerQueueRoney.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        PlayerQueue model = new PlayerQueue();
        
        //Player kevin = new Player("Kevin");
        //Player kassi = new Player("Kassi");
        //Player quinn = new Player("Quinn");
        //Player dwayne = new Player("Dwayne");
        //Player whitty = new Player("Whitty");
        [HttpGet]
        public IActionResult Index()
        {
            //model.addPlayer(kevin);
            //model.addPlayer(kassi);
            //model.addPlayer(quinn);
            //model.addPlayer(dwayne);
            //model.addPlayer(whitty);
            ViewBag.currentPlayers = model.currentQueue();
            
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(PlayerQueue viewModel)
        {
            if (ModelState.IsValid)
            {
                Player toAdd = new Player(viewModel.name);
                model.addPlayer(toAdd);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}