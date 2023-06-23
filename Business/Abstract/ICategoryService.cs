using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<List<Category>> GetByCategoryId(Guid CategoryId);
        IResult Add(Category house);
        IResult Update(Category house);
        IResult Delete(Category house);
    }
}
