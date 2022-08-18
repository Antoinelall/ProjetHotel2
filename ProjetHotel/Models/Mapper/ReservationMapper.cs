using ProjetHotelBLL.DTO;

namespace ProjetHotel.Models.Mapper
{
    public static class ReservationMapper
    {
        public static Reservation ToModel(this ReservationDTO dto)
        {
            return new Reservation()
            {
                IdReservation = dto.IdReservation,
                Prix = dto.Prix,
                NBNuit = dto.NBNuit,
                DateArrivee = dto.DateArrivee,
                DateDepart = dto.DateDepart,
                IdHotel = dto.IdHotel,
                IdChambre = dto.IdChambre,
                
            };
        }
    }
}
