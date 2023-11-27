using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class PokemonsViewModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Tipo1 { get; set;}
        public string? Tipo2 { get; set; }
        public string Region { get; set; }
        public int RegionId { get; set;}

    }
}
