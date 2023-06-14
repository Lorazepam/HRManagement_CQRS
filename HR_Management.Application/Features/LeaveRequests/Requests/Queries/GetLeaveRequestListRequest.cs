using HR_Management.Application.DTOs.LeaveRequest;
using MediatR;
using System.Collections.Generic;

namespace HR_Management.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestListRequest : IRequest<List<LeaveRequestListDto>>
    {
    }
}
