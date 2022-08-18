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
    public class ClientService
    {
        private IClientRepository clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        # region Register & Login
        public ClientDTO Insert(string pseudo, string email, string mdpHash)
        {
            int id = clientRepository.Insert(new DAL.Entities.ClientEntity
            {
                Pseudo = pseudo,
                Email = email,
                MDPHash = mdpHash
            });

            return clientRepository.GetById(id).ToDTO();
        }

        public string? GetPasswordHash(string pseudo)
        {
            return clientRepository.GetPasswordHash(pseudo);
        }

        public bool CheckMemberExists(string pseudo, string email)
        {
            return clientRepository.CheckMemberExists(pseudo, email);
        }
        #endregion
        #region crud
        public ClientDTO GetByPseudo(string pseudo)
        {
            return clientRepository.GetByPseudo(pseudo).ToDTO();
        }

        public bool Delete(int idMember)
        {
            return clientRepository.Delete(idMember);

        }
        #endregion
    }
}
