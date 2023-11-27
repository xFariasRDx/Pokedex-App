using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SavePokemonViewModels
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Debe Colocar el Nombre del Pokemon")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Debe Colocar el region del Pokemon")]

        public int RegionId { get; set; }
        [Required(ErrorMessage = "Debe Colocar el tipo del Pokemon")]

        public int TipoId1 { get; set; }
        public int? TipoId2 { get; set; }
        [Required(ErrorMessage = "Debe Colocar el imagen del Pokemon")]

        public string ImageUrl { get; set; }

    }
}
