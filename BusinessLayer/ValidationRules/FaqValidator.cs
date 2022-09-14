using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class FaqValidator : AbstractValidator<Faq>
    {
        public FaqValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş geçilemez");
            //RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim boş geçilemez");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Başlık en az 5 karakterden oluşturulmalıdır");
            RuleFor(x => x.Description).MinimumLength(200).WithMessage("Açıklama en az 200 karakterden oluşturulmalıdır");
            RuleFor(x => x.Description).MaximumLength(2000).WithMessage("Açıklama en fazla 2000 karakterden oluşturulmalıdır");
            RuleFor(x => x.Title).MaximumLength(20).WithMessage("Başlık en fazla 20 karakterden oluşturulmalıdır");
        }
    }
}
