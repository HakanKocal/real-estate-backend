using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category:IEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
    }
}
