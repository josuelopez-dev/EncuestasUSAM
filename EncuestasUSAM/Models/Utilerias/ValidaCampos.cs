using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EncuestasUSAM.Models.Utilerias
{
    public class ValidaCampos
    {

    }

    public class UserExist : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            using (ENCUESTASUSAMEntities bdDatos = new ENCUESTASUSAMEntities())
            {
                string user = (string)value;
                if (bdDatos.USUARIO.Where(u => u.NOMBRE_USUARIO == user).Count() > 0)
                {
                    return new ValidationResult("El Usuario ya Existe");
                }
            }

            return ValidationResult.Success;
        }
    }

    public class WorkEmailExist : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            using (ENCUESTASUSAMEntities bdDatos = new ENCUESTASUSAMEntities())
            {
                string email = (string)value;
                if (bdDatos.PERSONA.Where(u => u.CORREO_INSTITUCIONAL == email).Count() > 0)
                {
                    return new ValidationResult("El Correo ya Existe");
                }
            }

            return ValidationResult.Success;
        }
    }

    public class PersonalEmailExist : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            using (ENCUESTASUSAMEntities bdDatos = new ENCUESTASUSAMEntities())
            {
                string email = (string)value;
                if (bdDatos.PERSONA.Where(u => u.CORREO_PERSONAL == email).Count() > 0)
                {
                    return new ValidationResult("El Correo ya Existe");
                }
            }

            return ValidationResult.Success;
        }
    }

    public class DUIExist : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            using (ENCUESTASUSAMEntities bdDatos = new ENCUESTASUSAMEntities())
            {
                string dui = (string)value;
                if (bdDatos.PERSONA.Where(u => u.DUI == dui).Count() > 0)
                {
                    return new ValidationResult("El Número de DUI ya Existe");
                }
            }

            return ValidationResult.Success;
        }
    }

    public class HousePhoneExist : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            using (ENCUESTASUSAMEntities bdDatos = new ENCUESTASUSAMEntities())
            {
                string telefono = (string)value;
                if (bdDatos.PERSONA.Where(u => u.TELEFONO_FIJO == telefono).Count() > 0)
                {
                    return new ValidationResult("El Número Telefónico ya Existe");
                }
            }

            return ValidationResult.Success;
        }
    }

    public class MovilPhoneExist : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            using (ENCUESTASUSAMEntities bdDatos = new ENCUESTASUSAMEntities())
            {
                string telefono = (string)value;
                if (bdDatos.PERSONA.Where(u => u.TELEFONO_MOVIL == telefono).Count() > 0)
                {
                    return new ValidationResult("El Número Telefónico ya Existe");
                }
            }

            return ValidationResult.Success;
        }
    }

}