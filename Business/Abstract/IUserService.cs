using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
       IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetUserInfo(int userId);
        IResult Add(User user);
        IDataResult<User> GetByMail(string email);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<List<User>> Get(int id);
        
    }
}
