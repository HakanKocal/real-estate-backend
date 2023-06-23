using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Abstract
{
    public interface IHouseService
    {
        IDataResult<List<House>> GetAll();
        IDataResult<List<House>> GetByHouseId(Guid houseId);
        IDataResult<List<House>> GetByUserId(int userId);
        IDataResult<List<House>> Search(string searchKey);
        IDataResult<List<House>> GetByFilterHouse(int minprice,int maxprice, Guid categoryId, int minsize,int maxsize, int floor, int room, int cityId, int districtId);

        IDataResult<List<House>> GetFavoriteListByUserId(int userId);
        IResult Add(List<IFormFile> file,House house);
        IResult Update(House house);
        IResult ApproveHouse(Guid id);
        IResult Delete(House house);
    }
}
