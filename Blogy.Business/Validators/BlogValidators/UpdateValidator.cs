using Blogy.Business.DTOs.BlogDtos;
using FluentValidation;

namespace Blogy.Business.Validators.BlogValidators
{
    public class UpdateValidator:AbstractValidator<UpdateBlogDto>
    {
        public UpdateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Boş Bırakılamaz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Boş Bırakılamaz");
            RuleFor(x => x.CoverImage).NotEmpty().WithMessage("Kapak Resmi Boş Bırakılamaz");
            RuleFor(x => x.BlogImage1).NotEmpty().WithMessage("Blog Resmi 1 Boş Bırakılamaz");
            RuleFor(x => x.BlogImage2).NotEmpty().WithMessage("Blog Resmi 2 Boş Bırakılamaz");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori Boş Bırakılamaz");
        }
    }
}
