using Entities.Abstract;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class House:IEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Size { get; set; }
        public int Floor { get; set; }
        public int Room { get; set; }
        public int UserId { get; set; }
        public bool IsRent { get; set; }
        public Guid? CategoryId { get; set; }
        public Address Address { get; set; }
        public User? User { get; set; }
        public Category? Category { get; set; }
        public ICollection<Image>? Image { get; set; }
        public bool Status { get; set; }

    }
}
