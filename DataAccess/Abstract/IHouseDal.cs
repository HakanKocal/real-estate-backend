using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IHouseDal : IEntityRepository<House>
    {
        List<House> Search(string search, params string[]? includes);
        List<House> GetByFilterHouse(int minprice, int maxprice, Guid categoryId, int minsize,int maxsize, int floor, int room, int cityId, int districtId, params string[]? includes);
        List<House> GetFavoriteListByUserId(int userId, params string[] includes);
    }
}
