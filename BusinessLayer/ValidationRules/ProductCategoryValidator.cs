using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ProductCategoryValidator : AbstractValidator<ProductCategory>
    {
        public ProductCategoryValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez");
            //RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim boş geçilemez");
            //RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş geçilemez");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Başlık en az 5 karaterden oluşmalıdır");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Başlık en fazla 50 karakterden oluşmalıdır");
            RuleFor(x => x.Description).MaximumLength(1000).WithMessage("Açıklama en fazla 1000 karakterden oluşturulmalıdır");
            RuleFor(x => x.Description).MinimumLength(200).WithMessage("Açıklama en az 200 karakterden oluşturulmalıdır");
        }
    }
}
