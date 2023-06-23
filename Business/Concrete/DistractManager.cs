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
    public class DistractManager:IDistractService
    {
        IDistractDal _distractDal;
        
        public DistractManager(IDistractDal distractDal)
        {
            _distractDal = distractDal;
        }
        
        public IDataResult<List<District>> GetDistractByCityId(int cityId)
        {
            var response = _distractDal.GetAll(d => d.CityId == cityId,null);
            return new SuccessDataResult<List<District>>(response, Messages.AddressListed);
        }
    }
}
