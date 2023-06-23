using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFavoriteHouseSerivice
    {
        IResult AddOrDelete(FavoriteHouse favoriteHouse);
        IResult Update(FavoriteHouse favoriteHouse);
        IResult Delete(FavoriteHouse favoriteHouse);
        IDataResult<List<FavoriteHouse>> GetAll();
        IDataResult<List<FavoriteHouse>> GetByFavId(int id);
        IDataResult<List<FavoriteHouse>> GetByUserId(int userId);
        IDataResult<List<FavoriteHouse>> CheckFav(int userId,Guid houseId);
    }
}
