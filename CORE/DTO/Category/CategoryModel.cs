﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DTO
{
    public class CategoryModel
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; }
        public int? CategoryId { get; set; }
    }
}
