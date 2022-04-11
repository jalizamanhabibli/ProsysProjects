using FluentValidation;
using Project2.Core.Dtos;

namespace Project2.Service.Validators
{
    public class ExamDtoValidator:AbstractValidator<ExamDto>
    {
        public ExamDtoValidator()
        {
            RuleFor(x => x.LessonCode).NotNull().WithMessage("Dərs secilmeyib!").NotEmpty()
                .WithMessage("Dərs secilmeyib!");

            RuleFor(x => x.StudentId).InclusiveBetween(1, int.MaxValue).WithMessage("Telebe secilmeyib");
            RuleFor(x => x.Score).NotNull().WithMessage("Qiymət Seçilməyib!");
            RuleFor(x => x.ExamDate).NotNull().WithMessage("Imtahan tarixi seçilməyib!");
        }
    }
}