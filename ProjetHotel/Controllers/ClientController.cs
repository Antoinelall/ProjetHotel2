using Isopoh.Cryptography.Argon2;
using Microsoft.AspNetCore.Mvc;
using ProjetHotel.Infrastructure;
using ProjetHotel.Models;
using ProjetHotel.Models.Mapper;
using ProjetHotelBLL.Services;

namespace ProjetHotel.Controllers
{
    public class ClientController : Controller
    {
        private ClientService clientService;
        private SessionManager sessionManager;

        public ClientController(ClientService clientService, SessionManager sessionManager)
        {
            this.clientService = clientService;
            this.sessionManager = sessionManager;   
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register([FromForm] ClientRegister clientRegister)
        {
            if (!ModelState.IsValid)
            {
                return View(clientRegister);
            }

            // Check if Member exists
            if (clientService.CheckMemberExists(clientRegister.Pseudo, clientRegister.Email))
            {
                ModelState.AddModelError("", "Le compte existe déjà.");
                return View(clientRegister);
            }

            // Hashage du mot de passe
            string pwdHash = Argon2.Hash(clientRegister.Password);

            // Save Member in DB
            Client client = clientService.Insert(
                clientRegister.Pseudo,
                clientRegister.Email,
                pwdHash
            ).ToModel();

            // TODO Store Member in Session
            sessionManager.Login(client);
            Console.WriteLine($"Client create with id {client.IdClient}");

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([FromForm] ClientLogin clientLogin)
        {
            if (!ModelState.IsValid)
            {
                return View(clientLogin);
            }

            // Récuperation du hashage du mot de passe
            string? pwdHash = clientService.GetPasswordHash(clientLogin.Pseudo);
            if (pwdHash is null)
            {
                ModelState.AddModelError("", "Les credentials ne sont pas valide");
                return View(clientLogin);
            }

            // Validation du hashage du mot de passe
            if (!Argon2.Verify(pwdHash, clientLogin.Password))
            {
                ModelState.AddModelError("", "Les credentials ne sont pas valide");
                return View(clientLogin);
            }

            // Récuperation du compte via son pseudo
            Client client = clientService.GetByPseudo(clientLogin.Pseudo).ToModel();


            sessionManager.Login(client);
            Console.WriteLine($"Client login with id {client.IdClient}");

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout(ClientLogin clientLogin)
        {

            sessionManager.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}
