using Business.Abstract;
using Business.Contans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FavoriteHouseManager : IFavoriteHouseSerivice
    {
        IFavoriteHouseDal _favHouseDal;
        public FavoriteHouseManager(IFavoriteHouseDal favHouseDal)
        {
            _favHouseDal = favHouseDal;
        }

        public IResult AddOrDelete(FavoriteHouse favoriteHouse)
        {
            var FavCheck = CheckFav(favoriteHouse.UserId, favoriteHouse.HouseId);
            if(!(FavCheck.Data.Count>0))
            {
                _favHouseDal.Add(favoriteHouse);
                return new SuccessResult(Messages.FavoriteAdded);
            }
            _favHouseDal.Delete(FavCheck.Data.FirstOrDefault());
            return new SuccessResult(Messages.FavoriteDeleted);
        }

        public IDataResult<List<FavoriteHouse>> CheckFav(int userId, Guid houseId)
        {
           return new SuccessDataResult<List<FavoriteHouse>>(_favHouseDal.GetAll(x => x.UserId == userId && x.HouseId == houseId,null), Messages.FavoriteListed);
        }

        public IResult Delete(FavoriteHouse favoriteHouse)
        {
            _favHouseDal.Delete(favoriteHouse);
            return new SuccessResult(Messages.FavoriteDeleted);
        }

        public IDataResult<List<FavoriteHouse>> GetAll()
        {
            return new SuccessDataResult<List<FavoriteHouse>>(_favHouseDal.GetAll(null, null),Messages.FavoriteListed);
        }

        public IDataResult<List<FavoriteHouse>> GetByFavId(int id)
        {
            return new SuccessDataResult<List<FavoriteHouse>>(_favHouseDal.GetAll(x=>x.Id==id,null),Messages.FavoriteListed);
        }

        public IDataResult<List<FavoriteHouse>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<FavoriteHouse>>(_favHouseDal.GetAll(x => x.UserId == userId, null), Messages.FavoriteListed);
        }

        public IResult Update(FavoriteHouse favoriteHouse)
        {
            _favHouseDal.Add(favoriteHouse);
            return new SuccessResult(Messages.FavoriteAdded);
        }
    }
}
