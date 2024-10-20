﻿using FluentValidation;
using System;

namespace Products.Model
{
    public class ProductOption
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ProductOptionValidator : AbstractValidator<ProductOption>
    {
        public ProductOptionValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ProductOption ID cannot be empty");
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Product ID cannot be empty");
        }
    }
}
