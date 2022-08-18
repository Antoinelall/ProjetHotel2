using ProjetHotelBLL.DTO;
using ProjetHotelBLL.Mapper;
using ProjetHotelDAL.Interfaces;
using DAL = ProjetHotelDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetHotelBLL.Services
{
    public class ReservationService
    {
        private IReservationRepository reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }
        public ReservationDTO GetById(int id)
        {
            return reservationRepository.GetById(id).ToDTO();
        }

        public IEnumerable<ReservationDTO> GetAll()
        {
            return reservationRepository.GetAll().Select(b => b.ToDTO());
        }

        //public ReservationDTO Insert(ReservationDTO reservation)
        //{
        //    int IdReservarion = reservationRepository.Insert(reservation.ToEntity());

        //    reservation.IdReservation = IdReservarion;
        //    return reservation;
        //}
        public ReservationDTO Insert(DateTime dateArrivee, DateTime dateDepart, int idHotel, int idClient, int idChambre)
        {
            int id = reservationRepository.Insert(new DAL.Entities.ReservationEntity
            {
                DateArrivee = dateArrivee,
                DateDepart = dateDepart,
                IdHotel = idHotel,
                IdClient = idClient,
                IdChambre = -idChambre,
                NBNuit = (dateArrivee - dateDepart).Days-1 
                
            }); ;

            return reservationRepository.GetById(id).ToDTO();
        }




        public bool Update(int id, ReservationDTO G)
        {
            return reservationRepository.Update(id, G.ToEntity());
        }
        public bool Delete(int id)
        {
            return reservationRepository.Delete(id);
        }
    }
}
