using Empleate.Validators;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empleate.Models
{
    public class Empleado
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [RegularExpression(RegularExpression.TextValidation, ErrorMessage = "Nombre solo debe ser nombre")]
        public string Nombre { get; set; }

        [Required]
        [RegularExpression(RegularExpression.TextValidation, ErrorMessage = "Apellidos debe ser solo texto")]
        public string Apellidos { get; set; }

        [Required]
        [AgeCheck]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public string Genero { get; set; }

        [Required]
        public string EstadoCivil { get; set; }

        [Required]
        [RegularExpression(RegularExpression.CellphoneValidation, ErrorMessage = "Numero de celular debe empezar con 6 o 7")]
        public int Celular { get; set; }

        [Required]
        public string Ciudad { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [RegularExpression(RegularExpression.ImageValidation, ErrorMessage = "Formato de imagen invalido")]
        public string Imagen { get; set; }
    }
}
