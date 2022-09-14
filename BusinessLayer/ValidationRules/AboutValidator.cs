using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez");
            //RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel alanı boş geçilemez");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş geçilemez");
            RuleFor(x => x.Description2).NotEmpty().WithMessage("Açıklama boş geçilemez");
            RuleFor(x => x.Description3).NotEmpty().WithMessage("Açıklama boş geçilemez");
            RuleFor(x => x.Description4).NotEmpty().WithMessage("Açıklama boş geçilemez");
            RuleFor(x => x.Description).MinimumLength(50).WithMessage("Açıklama en az 50 karakter olmalıdır");
            RuleFor(x => x.Description2).MinimumLength(50).WithMessage("Açıklama en az 50 karakter olmalıdır");
            RuleFor(x => x.Description3).MinimumLength(50).WithMessage("Açıklama en az 50 karakter olmalıdır");
            RuleFor(x => x.Description4).MinimumLength(50).WithMessage("Açıklama en az 50 karakter olmalıdır");
            RuleFor(x => x.Description).MaximumLength(1000).WithMessage("Açıklama en fazla 1000 karakter olmalıdır");
            RuleFor(x => x.Description2).MaximumLength(400).WithMessage("Açıklama en fazla 400 karakter olmalıdır");
            RuleFor(x => x.Description3).MaximumLength(400).WithMessage("Açıklama en fazla 400 karakter olmalıdır");
            RuleFor(x => x.Description4).MaximumLength(400).WithMessage("Açıklama en fazla 400 karakter olmalıdır");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Başlık en az 5 karakterden oluşmak zorundadır");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Başlık en fazla 100 karakterden oluşmak zorundadır");
        }
    }
}
