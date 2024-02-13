using Applications.Models.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Validators {
    public class OrderDtoValidator : AbstractValidator<OrderDto> {

        public OrderDtoValidator() {
            RuleFor(u => u.Dishes)
                .NotEmpty()
                .WithMessage("Il campo ordine deve contenere almeno un piatto.");
            RuleForEach(u => u.Dishes)
                .Custom(DishValidation);

        }

        private void DishValidation(DishDto dish, ValidationContext<OrderDto> context) {
            if (dish.Name == null || dish.Name.Length == 0)
                context.AddFailure("Il campo Name dei piatti è obbligatorio.");
            if (dish.Portions < 1)
                context.AddFailure("Non si può prendere meno di una porzione di un piatto.");
            if (dish.Price <= 0)
                context.AddFailure("Ogni prezzo deve essere un numero positivo.");
            string priceString = dish.Price.ToString(CultureInfo.InvariantCulture);
            int decimalNumbers = priceString.Substring(priceString.IndexOf('.') + 1).Length;
            if (decimalNumbers > 2)
                context.AddFailure("Un prezzo può avere al massimo due cifre decimali.");
        }

    }
}
