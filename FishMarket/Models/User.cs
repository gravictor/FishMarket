﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishMarket.Models
{
    public class User:IdentityUser
    {
        public string Name { get; set; }
        public string NumberPhone { get; set; }
    }
}
