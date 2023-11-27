﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Regiones
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        //Navigation Property
        public ICollection<Pokemon> pokemones { get; set; }
        

    }
}
