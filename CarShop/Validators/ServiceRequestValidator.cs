﻿using CarShop.Models.Requests;
using FluentValidation;

namespace CarShop.Validators
{
    public class ServiceRequestValidator : AbstractValidator<ServiceRequest>
    {
        public ServiceRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(30);
            RuleFor(x => x.Price).NotNull().NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}
