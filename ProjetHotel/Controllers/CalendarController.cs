using Microsoft.AspNetCore.Mvc;
using ProjetHotel.Infrastructure;
using ProjetHotel.Models;
using ProjetHotelBLL.Services;
using ProjetHotel.Models.Mapper;
namespace ProjetHotel.Controllers
{
    public class CalendarController : Controller
    {
        private readonly SessionManager _sessionManager;
        private readonly ReservationService _reservationService;
        public CalendarController(SessionManager sessionManager, ReservationService reservationService)
        {
            _sessionManager = sessionManager;
            _reservationService = reservationService;
        }


        public IActionResult Calendar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calendar([FromForm]ReservationForm reservation)
        {
            // TODO : 
            // - Obtenir l'id la personne (session)

            if (_sessionManager.User == null)
            {
                return RedirectToAction("Login", "Client");
            }
            reservation.IdClient = _sessionManager.User.IdClient;

            // - Obtenir l'id de l'hotel
            int IdHotel;
            Int32.TryParse(ControllerContext.RouteData.Values["id"].ToString(),out IdHotel );
            reservation.IdHotel = IdHotel;

            Reservation reservation1 = _reservationService.Insert(
                reservation.DateDepart,
                reservation.DateArrivee,
                reservation.IdHotel,
                reservation.IdClient

            ).ToModel();


            // - Créer la reservation

            // Et cela dans la BLL ;) 

            return View();
        }
    }
}
