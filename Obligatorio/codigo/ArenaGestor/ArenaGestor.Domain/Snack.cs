﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGestor.Domain
{
    public class Snack
    {
        public int SnackId { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public Snack() { }
    }
}