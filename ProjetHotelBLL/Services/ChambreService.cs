using ProjetHotelBLL.DTO;
using ProjetHotelBLL.Mapper;
using ProjetHotelDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetHotelBLL.Services
{
    internal class ChambreService
    {
        private IChambreRepository chambreRepository;

        public ChambreService(IChambreRepository chambreRepository)
        {
            this.chambreRepository = chambreRepository;
        }
        public ChambreDTO GetById(int id)
        {
            return chambreRepository.GetById(id).ToDTO();
        }

        public IEnumerable<ChambreDTO> GetAll()
        {
            return chambreRepository.GetAll().Select(b => b.ToDTO());
        }

        public ChambreDTO Insert(ChambreDTO chambre)
        {
            int IdChambre = chambreRepository.Insert(chambre.ToEntity());

            chambre.IdChambre = IdChambre;
            return chambre;
        }
        public bool Update(int id, ChambreDTO G)
        {
            return chambreRepository.Update(id, G.ToEntity());
        }
        public bool Delete(int id)
        {
            return chambreRepository.Delete(id);
        }
    }
}
