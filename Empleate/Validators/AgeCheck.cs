using Empleate.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Empleate.Validators
{
    public class AgeCheck : ValidationAttribute
    {
        private const int EDADMINIMA = 18;
        public string FechaNacimientoInvalido { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = validationContext.ObjectInstance as Employee;

            if (model == null)
            {
                throw new ArgumentException("Atributo no aplicado al modelo");
            }
            int edad = DateTime.Today.AddTicks(-model.FechaNacimiento.Ticks).Year - 1;


            if (edad < EDADMINIMA)
            {
                return new ValidationResult(FechaNacimientoInvalido ?? "Fecha de nacimiento inválido");
            }

            return ValidationResult.Success;
        }

    }



}
