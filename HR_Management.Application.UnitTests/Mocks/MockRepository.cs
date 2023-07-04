using HR_Management.Application.Contracts.Persistence;
using HR_Management.Domain;
using Moq;

namespace HR_Management.Application.UnitTests.Mocks
{
    public static class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveType>()
            {
                new LeaveType {
                Id = 1,
                DefaultDay = 10,
                Name = "Test Vacation"
                },
                new LeaveType {
                Id = 2,
                DefaultDay = 15,
                Name = "Test Sick"
                }
            };


            var mockRepo = new Mock<ILeaveTypeRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(leaveTypes);

            mockRepo.Setup(r => r.Add(It.IsAny<LeaveType>()))
                .ReturnsAsync((LeaveType leaveType) =>
                {
                    leaveTypes.Add(leaveType);
                    return leaveType;
                });

        //var leaveType =  mockRepo.Setup(r => r.Get(leaveTypes[0].Id))
        //        .ReturnsAsync(leaveTypes[0]);
            
                
            return mockRepo;
        }
    }
}
