﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG.Application.Models
{
    public class ResultDTO
    {
        public bool IsSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
