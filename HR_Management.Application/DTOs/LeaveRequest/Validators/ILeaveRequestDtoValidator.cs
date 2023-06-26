using FluentValidation;
using HR_Management.Application.Contracts.Persistence;

namespace HR_Management.Application.DTOs.LeaveRequest.Validators
{
    public class ILeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public ILeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.StartDate)
                .NotEmpty()
                .WithMessage("{PropertyName} اجباری است.")
                .LessThan(p => p.EndDate)
                .WithMessage("{PropertyName} باید کمتر از {ComparisonValue} باشد.");

            RuleFor(p => p.EndDate)
               .NotEmpty()
               .WithMessage("{PropertyName} اجباری است.")
               .GreaterThan(p => p.StartDate)
               .WithMessage("{PropertyName} باید بیشتر از {ComparisonValue} باشد.");

            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .WithMessage("{PropertyName} معتبر نمی باشد .")
                .MustAsync(async (id , token) =>
                {
                    var leaveTypeExist = await _leaveTypeRepository.Exist(id);
                    return !leaveTypeExist;
                }).WithMessage("{PropertyName} موجود نمی باشد .");
            
        }
    }
}
