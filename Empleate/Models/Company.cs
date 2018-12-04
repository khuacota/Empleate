using Empleate.Validators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empleate.Models
{
    public class Company
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Descripción es requerido")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Rubro es requerido")]
        public string Entry { get; set; }

        [Required(ErrorMessage = "Dirección es requerido")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Telefono es requerido")]
        [RegularExpression(RegularExpression.IntegerValidation, ErrorMessage = "Telefono invalido")]
        public int Phone { get; set; }

        [Required(ErrorMessage = "Correo es requerido")]
        public string Email { get; set; }

        public string Url { get; set; }

        [RegularExpression(RegularExpression.ImageValidation, ErrorMessage = "Formato de imagen invalido")]
        public string Image { get; set; }


    }
}
