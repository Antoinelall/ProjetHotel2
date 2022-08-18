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
        private IClientRepository clientRepository;

        public ReservationService(IReservationRepository reservationRepository, IClientRepository clientRepository)
        {
            this.reservationRepository = reservationRepository;
            this.clientRepository = clientRepository;
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

        //public DateTime Day1 = DateTime.Parse("00/00/0000, 24:00:00");


        public ReservationDTO Insert(DateTime dateArrivee, DateTime dateDepart, int idHotel, int idClient)
        {
            int id = reservationRepository.Insert(new DAL.Entities.ReservationEntity
            {
                DateArrivee = dateArrivee,
                DateDepart = dateDepart,
                IdHotel = idHotel,
                IdClient = idClient,
                NBNuit = (dateDepart - dateArrivee).Days                
            }); ;

            return reservationRepository.GetById(id).ToDTO();
        }


        public IEnumerable<ReservationDTO> GetByIdClient(int idClient)
        {
            if( clientRepository.GetById(idClient) is null)
            {
                return Enumerable.Empty<ReservationDTO>();
            }

            // FIXME : Remove Where clause and use custom method in Repo (Opti !)
            return reservationRepository.GetAll().Where(r => r.IdClient == idClient).Select(b => b.ToDTO());
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
