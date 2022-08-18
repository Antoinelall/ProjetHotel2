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
    public class HotelService
    {
        private IHotelRepository hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            this.hotelRepository = hotelRepository;
        }
        public IEnumerable<HotelDTO> GetAll()
        {
            return hotelRepository.GetAll().Select(b => b.ToDTO());
        }

        #region 
        public HotelDTO Insert(string nom, int nbchambre, string pays, string ville)
        {
            int id = hotelRepository.Insert(new DAL.Entities.HotelEntity
            {
                Nom = nom,
                NBChambre = nbchambre,
                Pays = pays,
                Ville = ville

            });

            return hotelRepository.GetById(id).ToDTO();
        }
        #endregion
        #region Crud

        public bool Delete(int idHotel)
        {
            return hotelRepository.Delete(idHotel);
        }
        #endregion
    }
}
