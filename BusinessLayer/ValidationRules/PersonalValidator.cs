using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PersonalValidator : AbstractValidator<Personal>
    {
        public PersonalValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("İsim boş geçilemez");
            //RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim boş geçilemez");
            RuleFor(x => x.Telephone).NotEmpty().WithMessage("Lütfen telefon ekleyiniz");
            RuleFor(x => x.FullName).MaximumLength(30).WithMessage("İsim en fazla 30 karakterli oluşturulmalıdır");
            RuleFor(x => x.Telephone).MaximumLength(12).WithMessage("Telefon en fazla 12 karakterden oluşturulmalıdır");
            RuleFor(x => x.Telephone).MinimumLength(12).WithMessage("Telefon en az 12 karakterden oluşturulmalıdır");
        }
    }
}
