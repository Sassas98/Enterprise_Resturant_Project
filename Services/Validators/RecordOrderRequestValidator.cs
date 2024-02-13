using Applications.Models.Dtos;
using Applications.Models.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Validators {
    public class RecordOrderRequestValidator : AbstractValidator<RecordOrderRequest> {


        public RecordOrderRequestValidator() {
            RuleFor(x => x.PageSize)
                .GreaterThan(0)
                .WithMessage("La dimensione della pagina deve essere maggiore di 0");
        }
    }
}
