using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public abstract class Model : IValidatableObject
    {
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Throws an Error if the Object is not Valid
        /// </summary>
        public virtual void Validate()
        {
            Validator.ValidateObject(this, new ValidationContext(this, serviceProvider: null, items: null));
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => new ValidationResult[0];
    }
}
