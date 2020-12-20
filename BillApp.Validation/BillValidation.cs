using BillApp.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillApp.Validation
{
    public class BillValidation : AbstractValidator<BillsDto>
    {
        private string ErrorMessage = "{PropertyName} cannot be empty.";
        public BillValidation()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage(ErrorMessage);
            RuleFor(x => x.TotalAmount).NotEmpty().WithMessage(ErrorMessage);
            RuleFor(x => x.KdvAmount).NotEmpty().WithMessage(ErrorMessage);
            RuleFor(x => x.Currency).NotEmpty().WithMessage(ErrorMessage)
                .IsEnumName(typeof(CurrencyEnum))
                .WithMessage("The currency must be equal to the parameters. Paramaters : TL,Dolar,Euro");
            RuleFor(x => x.BillNo).Must(x=>
            {
                return x.ToString().Length == 6 ;
            }).WithMessage("Length should be 6 characters.")
              .NotEmpty().WithMessage(ErrorMessage);
            RuleFor(x => x.BillDate).NotEmpty().WithMessage(ErrorMessage);
            RuleFor(x => x.CreateDate).NotEmpty().WithMessage(ErrorMessage);
        }
    }
}
