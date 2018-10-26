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
        public string Nombre { get; set; }

        [Required]
        public string Apellidos { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public string Genero { get; set; }

        [Required]
        public string EstadoCivil { get; set; }

        [Required]
        public int Celular { get; set; }

        [Required]
        public int Ciudad { get; set; }

        [Required]
        public int Direccion { get; set; }

        [Required]
        public string Correo { get; set; }

        [Required]
        public string Imagen { get; set; }

        public int ProfesionId { get; set; }
        [ForeignKey("ProfesionId")]
        public Profesion Profesion { get; set; }
    }
}
