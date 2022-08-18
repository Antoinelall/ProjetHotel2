using ProjetHotelBLL.DTO;
using ProjetHotelDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetHotelBLL.Mapper
{
    public static class HotelMapper
    {
        public static HotelDTO ToDTO(this HotelEntity entity)
        {
            return new HotelDTO()
            {
                IdHotel = entity.IdHotel,
                Nom = entity.Nom,
                NBChambre = entity.NBChambre,
                Pays = entity.Pays,
                Ville = entity.Ville
            };
        }

        public static HotelEntity ToEntity(this HotelDTO dto)
        {
            return new HotelEntity()
            {
                IdHotel = dto.IdHotel,
                Nom = dto.Nom,
                NBChambre = dto.NBChambre,
                Pays = dto.Pays,
                Ville= dto.Ville
            };
        }
    }
}
