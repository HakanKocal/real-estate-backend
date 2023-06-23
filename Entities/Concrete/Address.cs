using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Address:IEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public string? CityName { get; set; }
        public string? DistrictName { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public City? City { get; set; }
        
        public District? District { get; set; }
    }
}
