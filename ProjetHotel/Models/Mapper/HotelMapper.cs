using ProjetHotelBLL.DTO;

namespace ProjetHotel.Models
{
    public static class HotelMapper
    {
        public static Hotel ToModel(this HotelDTO dto)
        {
            return new Hotel()
            {
                IdHotel = dto.IdHotel,
                Nom = dto.Nom,
                NBChambre = dto.NBChambre,
                Pays = dto.Pays,
                Ville = dto.Ville,
            };
        }
    }
}
