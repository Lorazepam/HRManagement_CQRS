using FluentValidation;

namespace HR_Management.Application.DTOs.LeaveType.Validators
{
    public class ILeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
    {
        public ILeaveTypeDtoValidator()
        {
            RuleFor(p=> p.Name).NotEmpty().WithMessage("{PropertyName} اجباری است.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} بیشتر از 50 کاراکتر نمی تواند باشد .")
                .WithName("نوع");

            RuleFor(p => p.DefaultDay).NotEmpty().WithMessage("{PropertyName} اجباری است.")
                .GreaterThan(0).WithMessage("{PropertyName} کمتر از 0 کاراکتر نمی تواند باشد .")
                .LessThan(100).WithMessage("{PropertyName} بیشتر از 100 کاراکتر نمی تواند باشد .")
                .WithName("تعداد روز ها");
        }
    }
}
