using ProjetHotelBLL.DTO;
using ProjetHotelDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetHotelBLL.Mapper
{
    internal static class ClientMapper
    {
        public static ClientDTO ToDTO(this ClientEntity entity)
        {
            return new ClientDTO()
            {
                IdClient = entity.IdClient,
                Pseudo = entity.Pseudo,
                Nom = entity.Nom,
                Prenom = entity.Prenom,
                Email = entity.Email,
                MDPHash = entity.MDPHash,
            };
        }

        public static ClientEntity ToEntity(this ClientDTO dto)
        {
            return new ClientEntity()
            {
                IdClient = dto.IdClient,
                Pseudo = dto.Pseudo,
                Nom = dto.Nom,
                Prenom = dto.Prenom,
                Email = dto.Email,
                MDPHash = dto.MDPHash,
            };
        }
    }
}
