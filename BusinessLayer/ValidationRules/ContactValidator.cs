using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("İsim boş geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Lütfen mesaj giriniz");
            RuleFor(x => x.Telephone).NotEmpty().WithMessage("Lütfen telefon ekleyiniz");
            RuleFor(x => x.FullName).MaximumLength(30).WithMessage("İsim en fazla 30 karakterli oluşturulmalıdır");
            RuleFor(x => x.Email).MaximumLength(30).WithMessage("Email en fazla 30 karakterli oluşturulmalıdır");
            RuleFor(x => x.Telephone).MaximumLength(11).WithMessage("Telefon en fazla 11 karakterden oluşturulmalıdır");
            RuleFor(x => x.Telephone).MinimumLength(11).WithMessage("Telefon en az 11 karakterden oluşturulmalıdır");
            RuleFor(x => x.Email).MinimumLength(11).WithMessage("Email en az 11 karakterden oluşturulmalıdır");
        }
    }
}
