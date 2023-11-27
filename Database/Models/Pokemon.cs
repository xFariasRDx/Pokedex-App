using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }
        public int TipoId1 { get; set; }
        public int? TipoId2 { get; set; }
        public string ImageUrl { get; set; }


        //Navigation Property
        public Regiones regiones { get; set; }
        public Tipos tipo1 { get; set; }
        public Tipos? tipo2 { get; set; }
    }
}

