using Microsoft.AspNetCore.Mvc;
using ProjetHotel.Infrastructure;
using ProjetHotel.Models;

namespace ProjetHotel.Controllers
{
    public class CalendarController : Controller
    {
        private readonly SessionManager _sessionManager;
        private readonly Hotel _hotel;
        public CalendarController(SessionManager sessionManager, Hotel hotel)
        {
            _sessionManager = sessionManager;
            _hotel = hotel;
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
            reservation.IdClient = _sessionManager.User.IdClient;
            // - Obtenir l'id de l'hotel
            reservation.IdHotel = _hotel.IdHotel;


            // - Créer la reservation

            // Et cela dans la BLL ;) 

            return View();
        }
    }
}
