using Business.Abstract;
using Business.Contans;
using Core.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Concrete
{
    public class HouseManager : IHouseService
    {
        string[] includes = { "Address","Category" ,"Image","User", "Address.City", "Address.District" };
        
        IHouseDal _houseDal;
        IImageService _imageService;

        public HouseManager(IHouseDal houseDal, IImageService ımageService)
        {
            _houseDal = houseDal;
            _imageService = ımageService;
        }

        public IResult Add(List<IFormFile> file,House house)
        {
            _houseDal.Add(house);
            for (int i = 0; i < file.Count; i++)
            {
                _imageService.Add(file[i], new Image() { HouseId = house.Id });
            }
            return new SuccessResult(Messages.HouseAdded);
        }

        public IResult ApproveHouse(Guid id)
        {
            var result = _houseDal.GetAll(h => h.Id == id, includes).FirstOrDefault();
            result.Status = !result.Status;
            _houseDal.Update(result);
            return new SuccessResult(Messages.HouseUpdated);

        }

        public IResult Delete(House house)
        {
            _houseDal.Delete(house);
            return new SuccessResult(Messages.HouseAdded);
        }

        public IDataResult<List<House>> GetAll()
        {
            return new SuccessDataResult<List<House>>(_houseDal.GetAll(null,includes),Messages.HouseListed);
        }

        public IDataResult<List<House>> GetFavoriteListByUserId(int userId)
        {
            return new SuccessDataResult<List<House>>(_houseDal.GetFavoriteListByUserId(userId,includes),Messages.FavoriteListed);
        }

        public IDataResult<List<House>> GetByFilterHouse(int minprice,int maxprice, Guid categoryId, int minsize,int maxsize, int floor, int room, int cityId, int districtId)
        {
           return new SuccessDataResult<List<House>>(_houseDal.GetByFilterHouse(minprice,maxprice, categoryId, minsize,maxsize, floor, room, cityId, districtId, includes),Messages.HouseListed);
        }

        public IDataResult<List<House>> GetByHouseId(Guid houseId)
        {
            return new SuccessDataResult<List<House>>(_houseDal.GetAll(p=>p.Id==houseId, includes), Messages.HouseListed);
        }

        public IDataResult<List<House>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<House>>(_houseDal.GetAll(p => p.UserId == userId, includes), Messages.HouseListed);
        }

        public IDataResult<List<House>> Search(string searchKey)
        {
            return new SuccessDataResult<List<House>>(_houseDal.Search(searchKey, includes), Messages.HouseListed);
        }

        public IResult Update(House house)
        {
            _houseDal.Update(house);
            return new SuccessResult(Messages.HouseUpdated);
        }
    }
}
