using ProjetHotelBLL.DTO;
using ProjetHotelDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetHotelBLL.Mapper
{
    internal static class ChambreMapper
    {
        public static ChambreDTO ToDTO(this ChambreEntity entity)
        {
            return new ChambreDTO()
            {
                IdChambre = entity.IdChambre,
                Type = entity.Type,
                Prix = entity.Prix,
                IdHotel = entity.IdHotel,
            };
        }

        public static ChambreEntity ToEntity(this ChambreDTO dto)
        {
            return new ChambreEntity()
            {
                IdChambre = dto.IdChambre,
                Type = dto.Type,
                Prix = dto.Prix,
                IdHotel = dto.IdHotel,
            };  
        }
    }
}
