﻿using CarShop.Models.Requests;
using FluentValidation;

namespace CarShop.Validators
{
    public class ClientRequestValidator : AbstractValidator<ClientRequest>
    {
        public ClientRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(2).MaximumLength(25);
            RuleFor(x => x.Car).NotNull().NotEmpty();
            RuleFor(x => x.PaymentType).NotEmpty().NotEmpty();
            RuleFor(x => x.Discount).NotNull().InclusiveBetween(0, 60);
        }
    }
}
