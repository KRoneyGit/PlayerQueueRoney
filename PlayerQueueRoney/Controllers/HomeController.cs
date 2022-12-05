using Microsoft.AspNetCore.Mvc;
using PlayerQueueRoney.Models;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace PlayerQueueRoney.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IPlayerList model;

        public HomeController(ILogger<HomeController> logger, IPlayerList mdl)
        {
            _logger = logger;
            model = mdl;
        }
        

        [HttpGet]
        public IActionResult Index()
        {
            //check if any players are in allPlayers of model
            if (model.allPlayers.size > 0)
            {
                //creates a temporary PlayerHeap to sort and then creates a Player array to send heapSort to
                //it then assigns that value to a ViewBag value to use in the view
                PlayerHeap temp = model.allPlayers;
                Player[] sorted = temp.heapSort();
                ViewBag.TotalTurns = sorted;
            }
            //returns the view and passes model to it
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(PlayerList viewModel)
        {
            //check if modelState is valid before trying to add a player
            if (ModelState.IsValid)
            {
                //check if name property is null and if it contains only letters
                if (viewModel.name != null && viewModel.name.All(Char.IsLetter))
                {
                    //sets errorMessage to be blank because user input was correct
                    model.errorMessage = "";
                    //creates a temporary player to pass to addPlayer method, and then adds that player with method
                    Player toAdd = new Player(viewModel.name);
                    model.addPlayer(toAdd);
                }
                else
                {
                    //sets error message to tell user to only enter a name with only letters
                    model.errorMessage = "Please enter a name containing only letters";
                }
            }
            //redirects to index view as this is a single page app
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Next()
        {
            //check if modelState is valid before trying to add a player
            if (ModelState.IsValid)
            {
                //calls method to change player order in queue
                model.nextPlayer();
            }
            //redirects to index view as this is a single page app
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(PlayerList viewModel)
        {
            //check if modelState is valid before trying to add a player
            if (ModelState.IsValid)
            {
                //removes player from current queue
                model.removePlayer(viewModel.name);
            }
            //redirects to index view as this is a single page app
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