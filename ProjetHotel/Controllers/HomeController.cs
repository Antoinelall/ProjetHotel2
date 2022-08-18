using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetHotel.Infrastructure;
using ProjetHotel.Models;
using ProjetHotel.Models.Mapper;
using ProjetHotelBLL.Services;
using System.Diagnostics;

namespace ProjetHotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SessionManager _sessionManager;



        private HotelService hotelService;
        private ReservationService reservationService;




        public HomeController(ILogger<HomeController> logger, HotelService hotelService, SessionManager sessionManager, ReservationService reservationService)
        {
            _logger = logger;
            this.hotelService = hotelService;
            _sessionManager = sessionManager;
            this.reservationService = reservationService;


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

        public IActionResult MesReservation()
        {
            int? idClient = _sessionManager.User?.IdClient;

            if (idClient is null)
            {
                return RedirectToAction("Login", "Client");
            }


            IEnumerable<Reservation> reservation = reservationService.GetByIdClient((int)idClient)
                                                       .Select(c => c.ToModel())
                                                       .OrderBy(c => c.DateDepart);
            return View(reservation);
        }

        public IActionResult Delete(int id)
        {
            //Console.WriteLine(id);
            //if(id == 1)
            //{
            //    RedirectToAction("Index");
            //}
            bool deleted = reservationService.Delete(id);
            //if (deleted)
            //{
                return RedirectToAction("MesReservation", "Home");

            //}
            //else
            //{
            //    Console.WriteLine($"Deleted: {deleted}");
            //    return RedirectToAction("Index");

            //}
        }
    }
}