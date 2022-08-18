using ProjetHotelBLL.DTO;
using ProjetHotelDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetHotelBLL.Mapper
{
    public static class ReservationMapper
    {
        public static ReservationDTO ToDTO(this ReservationEntity entity)
        {
            return new ReservationDTO()
            {
                IdReservation = entity.IdReservation,
                Prix = entity.Prix,
                NBNuit = entity.NBNuit,
                DateArrivee = entity.DateArrivee,
                DateDepart = entity.DateDepart,
                IdChambre = entity.IdChambre,
                IdHotel = entity.IdHotel,
                IdClient = entity.IdClient,
            };
        }

        public static ReservationEntity ToEntity(this ReservationDTO dto)
        {
            return new ReservationEntity()
            {
                IdReservation = dto.IdReservation,
                Prix = dto.Prix,
                NBNuit = dto.NBNuit,
                DateArrivee = dto.DateArrivee,
                DateDepart = dto.DateDepart,
                IdChambre = dto.IdChambre,
                IdHotel = dto.IdHotel,
                IdClient = dto.IdClient,
            };
        }
    }
}
