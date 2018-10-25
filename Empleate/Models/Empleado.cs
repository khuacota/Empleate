
using System.Collections.Generic;
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

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public int Telefono { get; set; }

        public string Correo { get; set; }

        public int ProfesionId { get; set; }
        [ForeignKey("ProfesionId")]
        public Profesion Profesion { get; set; }

    }
}
