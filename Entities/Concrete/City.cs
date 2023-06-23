using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class City:IEntity
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        [JsonIgnore]
        public  List<District>? Districts { get; set; }
    }
}
