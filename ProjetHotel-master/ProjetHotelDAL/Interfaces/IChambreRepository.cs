using ProjetHotelDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetHotelDAL.Interfaces
{
    public interface IChambreRepository : IRepository<int, ChambreEntity>
    {
    }
}
