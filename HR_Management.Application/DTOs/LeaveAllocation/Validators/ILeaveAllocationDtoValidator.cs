using FluentValidation;
using HR_Management.Application.Contracts.Persistence;
using System;

namespace HR_Management.Application.DTOs.LeaveAllocation.Validators
{
    public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public ILeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.NumberOfDays)
                .GreaterThan(0).WithMessage("{PropertyName} باید بیشتر از {ComparisonValue} باشد.");

            RuleFor(p=>p.Priod)
                .GreaterThanOrEqualTo(DateTime.Now.Year)
                .WithMessage("{PropertyName} باید بیشتر از {ComparisonValue} باشد.");

            RuleFor(p => p.LeaveTypeId)
               .GreaterThan(0)
               .WithMessage("{PropertyName} معتبر نمی باشد .")
               .MustAsync(async (id, token) =>
               {
                   var leaveTypeExist = await _leaveTypeRepository.Exist(id);
                   return !leaveTypeExist;
               }).WithMessage("{PropertyName} موجود نمی باشد .");
        }
    }
}
