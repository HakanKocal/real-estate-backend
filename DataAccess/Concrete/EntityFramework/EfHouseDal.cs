using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfHouseDal : EfEntityRepositoryBase<House, EmlakContext>, IHouseDal
    {
        //public List<House> GetByFilterHouse(int minprice,int maxprice, int size, int floor, int room, string cityName, string districtName, params string[]? includes)
        //{
        //    using (EmlakContext context = new EmlakContext())
        //    {

        //        var result = new List<House>();
        //        foreach (var include in includes)
        //        {

        //            result = context.Set<House>().Include(include).Where(x => x.Address.DistrictName == districtName && x.Address.CityName == cityName || x.Price >= minprice && x.Price <= maxprice || x.Size == size || x.Floor == floor || x.Room == room).ToList();
        //        }
        //        return result;
        //    }
        //}
        public List<House> GetByFilterHouse(int minprice, int maxprice, Guid categoryId, int minsize,int maxsize, int floor, int room, int cityId, int districtId, params string[]? includes)
        {
            using (EmlakContext context = new EmlakContext())
            {
                var result = context.Houses.Where(minprice != default, x => x.Price >= minprice)
                        .Where(maxprice != default, x => x.Price <= maxprice)
                        .Where(minsize != default, x => x.Size >= minprice)
                        .Where(maxsize != default, x => x.Size <= maxsize)
                        .Where(floor != default, x => x.Floor == floor)
                        .Where(room != default, x => x.Room == room)
                        .Where(cityId != default, x => x.Address.CityId == cityId)
                        .Where(districtId != default, x => x.Address.DistrictId == districtId)
                        .Where(categoryId != default,x=>x.CategoryId==categoryId);

                foreach (var include in includes)
                {
                    result = result.Include(include);
                }
                return result.ToList();
            }
        }
        public List<House> GetFavoriteListByUserId(int userId, params string[] includes)
        {
            using (EmlakContext context = new EmlakContext())
            {
                var result = from h in context.Houses
                             join f in context.FavoriteHouses
                             on h.Id equals f.HouseId
                             where f.UserId == userId
                             select h;
                foreach (var include in includes)
                {
                    result = result.Include(include);
                }
                return result.ToList();
            }
        }
        public List<House> Search(string search, params string[]? includes)
        {
            using (EmlakContext context = new EmlakContext())
            {
                var result = new List<House>();
                foreach (var include in includes)
                {
                    result = context.Set<House>().Include(include).Where(x => EF.Functions.Like(x.Title, $"%{search}%")).ToList();
                }
                return result;
            }
        }
        
            
        }

}

