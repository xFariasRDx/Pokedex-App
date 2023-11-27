using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Tipos
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        
        //Navigation Property
        public ICollection<Pokemon> pokemones1 { get; set; }
        public ICollection<Pokemon> pokemones2 { get; set; }
    }
}
