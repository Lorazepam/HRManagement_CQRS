using HR_Management.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR_Management.Application.Persistence.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetail(int id);
        Task<List<LeaveRequest>> GetLeaveRequestsWithDetail();
        Task ChangeApprovalStatus(LeaveRequest leaveRequest,bool? approvalStatus);
    }
}
