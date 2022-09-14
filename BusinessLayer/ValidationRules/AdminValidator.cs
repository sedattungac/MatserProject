using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Ad Soyad boş geçilemez");
            RuleFor(x => x.FullName).MinimumLength(5).WithMessage("Ad Soyad en az 5 karakterden oluşturulmalıdır");
            RuleFor(x => x.FullName).MaximumLength(30).WithMessage("Ad Soyad en fazla 30 karakterden oluşturulmalıdır");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez");
            RuleFor(x => x.Email).MinimumLength(10).WithMessage("Email en az 10 karakterden oluşturulmalıdır");
            RuleFor(x => x.Email).MaximumLength(30).WithMessage("Email en fazla 30 karakterden oluşturulmalıdır");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.Password).MinimumLength(5).WithMessage("Email en az 5 karakterden oluşturulmalıdır");
            RuleFor(x => x.Password).MaximumLength(15).WithMessage("Email en fazla 15 karakterden oluşturulmalıdır");
        }
    }
}
