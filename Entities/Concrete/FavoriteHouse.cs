﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class FavoriteHouse:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Guid HouseId { get; set; }
    }
}
