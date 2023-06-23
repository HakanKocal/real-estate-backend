using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Image:IEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public Guid HouseId { get; set; }
        public string? ImagePath { get; set; }
        public DateTime? Date { get; set; }
    }
}
