using Applications.Models.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Validators {
    public class UserDtoValidator : AbstractValidator<UserDto> {

        public UserDtoValidator() {
            RuleFor(u => u.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Il campo email è obbligatorio.")
                .EmailAddress()
                .WithMessage("Il campo email deve essere un indirizzo email.");

            RuleFor(u => u.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("Il campo password è obbligatorio.")
                .MinimumLength(8)
                .WithMessage("Il campo password deve essere lungo almeno 8 caratteri");
        }
    }
}
