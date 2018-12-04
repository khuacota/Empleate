
using Empleate.Validators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empleate.Models
{
    public class LanguageRequired
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Idioma es requerido")]
        [RegularExpression(RegularExpression.TextValidation, ErrorMessage = "Idioma debe ser texto")]
        public string Idioma { get; set; }

        public int OfertaId { get; set; }

    }
}
