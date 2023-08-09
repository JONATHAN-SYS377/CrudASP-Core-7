using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CrudASP.Models
{
    public class Contacto
    {
        //==============================================================================
        [Key]
        public int Id { get; set; }
        //==============================================================================

        //==============================================================================
        [Required(ErrorMessage ="El nombre es Obligatorio")]
        [StringLength(50)]
        public string Nombre { get; set; }
        //==============================================================================

        //==============================================================================
        [Phone]
        [Required(ErrorMessage = "El telefono es Obligatorio")]
        [Display(Name = "Teléfono")]
        [StringLength(8)]
        public string Telefono { get; set; }
        //==============================================================================

        //==============================================================================
        [Phone]
        [Required(ErrorMessage = "El celular es Obligatorio")]
        [Display(Name = "Celular")]
        [StringLength(8)]
        public string Celular { get; set; }
        //==============================================================================

        //==============================================================================
        [EmailAddress]
        [Required(ErrorMessage = "El email es Obligatorio")]
        public string Email { get; set; }
        //==============================================================================

        //==============================================================================
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Creación")]
        [Required(ErrorMessage = "El nombre es Obligatorio")]
        public DateTime FechaCreacion { get; set; }
        //==============================================================================

    }
}
