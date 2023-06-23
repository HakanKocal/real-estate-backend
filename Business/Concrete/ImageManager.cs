using Business.Abstract;
using Business.Contans;
using Core.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _imageDal;
        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public IResult Add(IFormFile file, Image image)
        {
            
                
                image.ImagePath = FileHelper.Add(file);
                image.Date = DateTime.Now;
                _imageDal.Add(image);
            
            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult Delete(Image image)
        {
            FileHelper.Delete(image.ImagePath);
            _imageDal.Delete(image);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<List<Image>> GetAll()
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll(null, null));
        }

        public IDataResult<List<Image>> GetById(int Id)
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll(p => p.Id == Id, null), Messages.ImageListed);
        }

        public IResult Update(IFormFile file, Image image)
        {
            image.ImagePath = FileHelper.Update(_imageDal.Get(c => c.Id == image.Id).ImagePath, file);
            image.Date = DateTime.Now;
            _imageDal.Update(image);
            return new SuccessResult(Messages.ImageUpdated);
        }
    }
}
