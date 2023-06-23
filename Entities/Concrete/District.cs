using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class District:IEntity
    {
        public int Id { get; set; }
        public string DistrictName { get; set; }
        [JsonIgnore]
        public int CityId { get; set; }
    }
}
