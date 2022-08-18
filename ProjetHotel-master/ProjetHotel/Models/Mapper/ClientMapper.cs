using ProjetHotelBLL.DTO;

namespace ProjetHotel.Models.Mapper
{
    internal static class ClientMapper
    {
        public static Client ToModel(this ClientDTO dto)
        {
            return new Client()
            {
                IdClient = dto.IdClient,
                Pseudo = dto.Pseudo,
                Nom = dto.Nom,
                Prenom = dto.Prenom,
                Email = dto.Email,
            };
        }
    }
}
