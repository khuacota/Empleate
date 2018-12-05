using Empleate.Validators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        public string Name { get; set; }

        [Required(ErrorMessage = "Apellido es requerido")]
        [RegularExpression(RegularExpression.TextValidation, ErrorMessage = "Apellido debe ser texto")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Fecha de nacimiento es requerido")]
        [AgeCheck]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Género es requerido")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Estado civil es requerido")]
        public string CivilStatus { get; set; }

        [Required(ErrorMessage = "Celular es requerido")]
        [RegularExpression(RegularExpression.CellphoneValidation, ErrorMessage = "Numero de celular debe empezar con 6 o 7")]
        public int Phone { get; set; }

        [Required(ErrorMessage = "Ciudad es requerido")]
        public string City { get; set; }

        [Required(ErrorMessage = "Dirección es requerido")]
        public string Direction { get; set; }

        [Required(ErrorMessage = "Correo es requerido")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Imagen es requerido")]
        [RegularExpression(RegularExpression.ImageValidation, ErrorMessage = "Formato de imagen invalido")]
        public string Image { get; set; }
        
        public List<OccupationEmp> Occupations{ get; set; }
    }
}
