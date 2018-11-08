using Empleate.Validators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empleate.Models
{
    public class Empresa
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Descripción es requerido")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Rubro es requerido")]
        public string Rubro { get; set; }

        [Required(ErrorMessage = "Dirección es requerido")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Telefono es requerido")]
        [RegularExpression(RegularExpression.IntegerValidation, ErrorMessage = "Telefono invalido")]
        public int Telefono { get; set; }

        [Required(ErrorMessage = "Correo es requerido")]
        public string Correo { get; set; }

        public string Url { get; set; }

        [RegularExpression(RegularExpression.ImageValidation, ErrorMessage = "Formato de imagen invalido")]
        public string Imagen { get; set; }


    }
}
