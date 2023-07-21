using AutoMapper;
using HR_Management.MVC.Contracts;
using HR_Management.MVC.Models;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        private readonly IMapper _mapper;
        private readonly IClient _httpClient;
        private readonly ILocalStorageService _localStorageService;

        public LeaveTypeService(IMapper mapper, IClient httpClient, ILocalStorageService localStorageService) 
            : base(httpClient, localStorageService)
        {
            _mapper = mapper;
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }

        public async Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM leaveType)
        {
            try
            {
                var response = new Response<int>();
                CreateLeaveTypeDto createLeaveTypeDto = 
                    _mapper.Map<CreateLeaveTypeDto>(leaveType);

                //TODO Auth

                var apiResponse = await _httpClient.LeaveTypesPOSTAsync(createLeaveTypeDto);

                if (apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach(var err in apiResponse.Errors)
                    {
                        response.ValidationErrors += err + Environment.NewLine;
                    }
                }
                return response;
            }
            catch (ApiException exp)
            {

                return ConvertApiExceptions<int>(exp);
            }
        }

        public async Task<Response<int>> DeleteLeaveType(int id)
        {
            try
            {
                await _httpClient.LeaveTypesDELETEAsync(id);
                return new Response<int> { Success = true };
            }
            catch (ApiException exp)
            {

                return ConvertApiExceptions<int>(exp);
            }
        }

        public async Task<LeaveTypeVM> GetLeaveTypeDetail(int id)
        {
            var leaveType = await _httpClient.LeaveTypesGETAsync(id);
            return  _mapper.Map<LeaveTypeVM>(leaveType);
        }

        public async Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
            var leaveTypes = await _httpClient.LeaveTypesAllAsync();
            return _mapper.Map<List<LeaveTypeVM>>(leaveTypes);
        }

        public async Task<Response<int>> UpdateLeaveType(int id , LeaveTypeVM leaveType)
        {
            try
            {
                LeaveTypeDto leaveTypeDto =
                    _mapper.Map<LeaveTypeDto>(leaveType);

                await _httpClient.LeaveTypesPUTAsync(id,leaveTypeDto);
                return new Response<int> { Success = true};

            }
            catch (ApiException exp)
            {

                return ConvertApiExceptions<int>(exp);
            }
        }
    }
}
