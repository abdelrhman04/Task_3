﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DTO
{
    public class LoginModel
    {
        //[Required]
        public string Email { get; set; }
        //[Required]
        //[MinLength(3)]
        //[MaxLength(16)]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
        //public string ReturnUrl { get; set; }
        //public bool RememberMe { get; set; }
    }
}
