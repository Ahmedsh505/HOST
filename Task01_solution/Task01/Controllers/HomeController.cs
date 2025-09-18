using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Task01.Models;

namespace Task01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Default Index action - returns Index view
        public IActionResult Index()
        {
            return View();
        }

        // Privacy action - returns Privacy view
        public IActionResult Privacy()
        {
            return View();
        }

        // Play action - returns the disco tic-tac-toe game
        // Route: /Home/Play
        public IActionResult Play()
        {
            return View();
        }

        // Calc action - returns calculator view
        // Route: /Home/Calc
        public IActionResult Calc()
        {
            return View();
        }

        // Helper method to show content based on demo pattern
        // Route: /Home/ShowMsg
        public ContentResult ShowMsg()
        {
            ContentResult result = new ContentResult();
            result.Content = "Welcome to Ahmed's Disco Club!";
            return result;
        }

        // Helper method to show specific view based on demo pattern
        // Route: /Home/ShowView
        public ViewResult ShowView()
        {
            ViewResult result = new ViewResult();
            result.ViewName = "Play"; // Shows the disco game
            return result;
        }

        // Mixed functionality based on demo pattern
        // Route: /Home/ShowMix?id=4
        // If id is even, shows Play view; if odd, shows content message
        public IActionResult ShowMix(int id)
        {
            if (id % 2 == 0)
            {
                return View("Play"); // Even numbers show the game
            }
            else
            {
                return Content("Let's Play Tic Tac Toe at Ahmed's Club!");
            }
        }

        // Game helper method - can be used to return different game views
        // Route: /Home/GameView?gameName=TicTacToe
        public IActionResult GameView(string gameName = "Play")
        {
            // Validate game name and return appropriate view
            switch (gameName.ToLower())
            {
                case "tictactoe":
                case "play":
                    return View("Play");
                case "calc":
                case "calculator":
                    return View("Calc");
                default:
                    return View("Index");
            }
        }

        // Action to handle game state - following MVC pattern
        // Route: /Home/GameStatus?status=win
        public IActionResult GameStatus(string status)
        {
            ViewBag.GameStatus = status;
            ViewBag.Message = status switch
            {
                "win" => "🎉 Congratulations! You won at Ahmed's Disco Club! 🎉",
                "lose" => "🤖 AI wins this round! Try again! 🤖",
                "tie" => "🤝 It's a tie! Great game! 🤝",
                _ => "Let's start playing!"
            };
            return View("Play");
        }

        // Action to reset game - RESTful approach
        // Route: /Home/ResetGame
        public IActionResult ResetGame()
        {
            // In a real app, you might clear session data here
            TempData["GameMessage"] = "🎲 New game started! Good luck! 🎲";
            return RedirectToAction("Play");
        }

        // Action to show club information
        // Route: /Home/ClubInfo
        public IActionResult ClubInfo()
        {
            ViewBag.ClubName = "Ahmed's Disco Club";
            ViewBag.ClubDescription = "Where gaming meets the dance floor!";
            ViewBag.Features = new string[]
            {
                "🎮 Classic Games with Modern Twist",
                "🕺 Disco-themed Gaming Experience",
                "🎉 Animated Celebrations",
                "🤖 Smart AI Opponents",
                "📱 Responsive Design"
            };
            return View("Play");
        }

        // Generic view helper method following the demo pattern
        public ViewResult ShowCustomView(string viewName)
        {
            ViewResult result = new ViewResult();
            result.ViewName = viewName ?? "Index";
            return result;
        }

        // Content helper method following the demo pattern
        public ContentResult ShowCustomContent(string message)
        {
            ContentResult result = new ContentResult();
            result.Content = message ?? "Welcome to Ahmed's Disco Club!";
            return result;
        }

        // Error handling - default MVC template
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}