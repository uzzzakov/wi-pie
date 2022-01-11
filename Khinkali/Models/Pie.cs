﻿using System;

namespace Khinkali.Models
{
    public class Pie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Compound { get; set; }
        public decimal Cost { get; set; }
        public decimal Diameter { get; set; }
        public string Filling { get; set; }
        public int Weight { get; set; }
        public string Image { get; set; }
    }
}
