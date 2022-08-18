using Microsoft.AspNetCore.Mvc;
using ProjetHotel.Infrastructure;
using ProjetHotel.Models;
using ProjetHotelBLL.Services;
using System.Diagnostics;

namespace ProjetHotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SessionManager _sessionManager;


        private HotelService hotelService;




        public HomeController(ILogger<HomeController> logger, HotelService hotelService, SessionManager sessionManager )
        {
            _logger = logger;
            this.hotelService = hotelService;
            _sessionManager = sessionManager;


        }

        public IActionResult Index()
        {
            IEnumerable<Hotel> hotel = hotelService.GetAll()
                                                       .Select(b => b.ToModel())
                                                       .OrderBy(b => b.Nom);
            return View(hotel);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}