﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntManZooClassLibrary.DTOs
{
    public class LoginResponseDTO
    {
        public bool Success { get; set; } = false;
        public string? JWTToken { get; set; }
    }
}