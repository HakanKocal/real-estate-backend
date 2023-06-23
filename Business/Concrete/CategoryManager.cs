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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category house)
        {
            _categoryDal.Add(house);
            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult Delete(Category house)
        {
            _categoryDal.Delete(house);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(null,null));
        }

        public IDataResult<List<Category>> GetByCategoryId(Guid CategoryId)
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(p => p.Id == CategoryId, null));
        }

        public IResult Update(Category house)
        {
            _categoryDal.Update(house);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
