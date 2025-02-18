using System.ComponentModel.DataAnnotations;

namespace JUAN_MARIA_P1_AP1.Components.Models
{
    public class Aportes
    {
        [Key]
        public int AporteId { get; set; }

        [Required(ErrorMessage = "El campo Descripcion no puede estar vacio.")]

        public string Descripcion { get; set; }
    }
}
