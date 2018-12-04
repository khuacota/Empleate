using Empleate.Validators;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empleate.Models
{
    public class Employee
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        [RegularExpression(RegularExpression.TextValidation, ErrorMessage = "Nombre debe ser texto")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellidos es requerido")]
        [RegularExpression(RegularExpression.TextValidation, ErrorMessage = "Apellidos debe ser texto")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Fecha de nacimiento es requerido")]
        [AgeCheck]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Género es requerido")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Estado civil es requerido")]
        public string EstadoCivil { get; set; }

        [Required(ErrorMessage = "Celular es requerido")]
        [RegularExpression(RegularExpression.CellphoneValidation, ErrorMessage = "Numero de celular debe empezar con 6 o 7")]
        public int Celular { get; set; }

        [Required(ErrorMessage = "Ciudad es requerido")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "Dirección es requerido")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Correo es requerido")]
        [EmailAddress]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Imagen es requerido")]
        [RegularExpression(RegularExpression.ImageValidation, ErrorMessage = "Formato de imagen invalido")]
        public string Imagen { get; set; }
    }
}
