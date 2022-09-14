using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class DepartmentValidator : AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Başlık en az 5 karakterden oluşturulmalıdır");
            RuleFor(x => x.Title).MaximumLength(20).WithMessage("Başlık en fazla 20 karakterden oluşturulmalıdır");
        }
    }
}
