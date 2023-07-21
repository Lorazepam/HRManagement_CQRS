using HR_Management.MVC.Contracts;
using HR_Management.MVC.Models;
using HR_Management.MVC.Services.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.MVC.Controllers
{
    public class LeaveTypeController : Controller
    {
        private readonly ILeaveTypeService _leaveTypeService;

        public LeaveTypeController(ILeaveTypeService leaveTypeService)
        {
            _leaveTypeService = leaveTypeService;
        }
        // GET: LeaveTypeController
        public async Task<ActionResult> Index()
        {
            var leaveTypes = await _leaveTypeService.GetLeaveTypes();
            return View(leaveTypes);
        }

        // GET: LeaveTypeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
			var leaveType = await _leaveTypeService.GetLeaveTypeDetail(id);
			return View(leaveType);
		}

        // GET: LeaveTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveTypeVM createLeaveType)
        {
            try
            {
                var response = await _leaveTypeService.CreateLeaveType(createLeaveType);
                if(response.Success)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", response.ValidationErrors);

            }
			catch(Exception exp)
            {
				ModelState.AddModelError("", exp.Message);
            }

            return View(createLeaveType);
        }

        // GET: LeaveTypeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var leaveType = await _leaveTypeService.GetLeaveTypeDetail(id);
            return View(leaveType);
        }

        // POST: LeaveTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, LeaveTypeVM updateLeaveType)
        {
			try
			{
				var response = await _leaveTypeService.UpdateLeaveType(id, updateLeaveType);
				if (response.Success)
				{
					return RedirectToAction("Index");
				}
				ModelState.AddModelError("", response.ValidationErrors);

			}
			catch (Exception exp)
			{
				ModelState.AddModelError("", exp.Message);
			}

			return View(updateLeaveType);
		}

        // GET: LeaveTypeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
			var leaveType = await _leaveTypeService.GetLeaveTypeDetail(id);
			return View(leaveType);
		}

        // POST: LeaveTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteLeaveType(int id)
        {
			try
			{
				var response = await _leaveTypeService.DeleteLeaveType(id);
				if (response.Success)
				{
					return RedirectToAction("Index");
				}
				ModelState.AddModelError("", response.ValidationErrors);

			}
			catch (Exception exp)
			{
				ModelState.AddModelError("", exp.Message);
			}

			return BadRequest();
		}
    }
}
