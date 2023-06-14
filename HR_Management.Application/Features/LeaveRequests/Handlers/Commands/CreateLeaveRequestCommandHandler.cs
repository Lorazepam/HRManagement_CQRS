using AutoMapper;
using HR_Management.Application.DTOs.LeaveRequest.Validators;
using HR_Management.Application.DTOs.LeaveType.Validators;
using HR_Management.Application.Features.LeaveRequests.Requests.Commands;
using HR_Management.Application.Persistence.Contracts;
using HR_Management.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository 
            , IMapper mapper
            ,ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            #region Validators
            var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.CreateLeaveRequestDto);

            if (validationResult.IsValid == false)
            {
                throw new Exception();
            }
            #endregion
            var leaveRequest = _mapper.Map<LeaveRequest>(request.CreateLeaveRequestDto);
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);
            return leaveRequest.Id;
        }
    }
}
