﻿using Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Models.Dtos {
    public class OrderDto {
        public DateOnly Date { get; set; }
        public IEnumerable<DishDto> Dishes { get; set; } = null!;
    }
}
