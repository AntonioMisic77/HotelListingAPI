﻿using System.ComponentModel.DataAnnotations;

namespace DapperTest.Data.Login
{
    public class LoginDto
    {
        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }
}
