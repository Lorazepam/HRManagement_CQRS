using HR_Management.Application.DTOs.LeaveType;
using MediatR;

namespace HR_Management.Application.Features.LeaveTypes.Requests.Commands
{
    //Unit baraye ine k momkene Api dashte bashim va bekhaim NoContent Bar gardunim.
    public class UpdateLeaveTypeCommand : IRequest<Unit>
    {
        public LeaveTypeDto LeaveTypeDto { get; set; }
    }
}
