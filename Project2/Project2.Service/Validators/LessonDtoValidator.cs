using FluentValidation;
using Project2.Core.Dtos;

namespace Project2.Service.Validators
{
    public class LessonDtoValidator:AbstractValidator<LessonDto>
    {
        public LessonDtoValidator()
        {
            RuleFor(x => x.Code).NotNull().WithMessage("Code boş ola bilməz!").NotEmpty()
                .WithMessage("Code boş ola bilməz!").Length(3).WithMessage("Code 3 simvoldan artıq olmaz!");

            RuleFor(x => x.Name).NotNull().WithMessage("Ad boş ola bilməz!").NotEmpty().WithMessage("Ad boş ola biləz!")
                .MaximumLength(30);
            RuleFor(x => x.Class).InclusiveBetween(1, int.MaxValue).WithMessage("Sinif boş ola bilməz!");

            RuleFor(x => x.TeacherName).NotNull().WithMessage("Müəllim adı boş ola bilməz!").NotEmpty()
                .WithMessage("Müəllim adı boş ola bilməz!").MaximumLength(20).WithMessage("Müəllim adı 20 simvoldan artıq ola bilməz!");

            RuleFor(x => x.TeacherSurname).NotNull().WithMessage("Müəllim soyadı boş ola bilməz!").NotEmpty()
                .WithMessage("Müəllim soyadı boş ola bilməz!").MaximumLength(20).WithMessage("Müəllim soyadı 20 simvoldan artıq ola bilməz!");
        }
    }
}