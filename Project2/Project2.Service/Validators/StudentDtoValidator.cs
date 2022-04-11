using FluentValidation;
using Project2.Core.Dtos;

namespace Project2.Service.Validators
{
    public class StudentDtoValidator:AbstractValidator<StudentDto>
    {
        public StudentDtoValidator()
        { 
            RuleFor(x => x.Name).NotNull().WithMessage("Ad boş ola bilməz!").NotEmpty()
                .WithMessage("Ad boş ola bilməz!").MaximumLength(30).WithMessage("Ad 30 simvoldan artıq olmaz!");

            RuleFor(x => x.Surname).NotNull().WithMessage("Soyad boş ola bilməz!").NotEmpty()
                .WithMessage("Soyad boş ola bilməz!").MaximumLength(30).WithMessage("Soyad 30 simvoldan artıq olmaz!");
            RuleFor(x => x.Class).InclusiveBetween(1, int.MaxValue).WithMessage("Sinif boş ola bilməz!");
        }
    }
}