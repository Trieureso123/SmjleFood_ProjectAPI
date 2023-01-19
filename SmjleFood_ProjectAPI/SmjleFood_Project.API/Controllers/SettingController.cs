using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmjleFood_Project.Service.DTO.Request;
using SmjleFood_Project.Service.DTO.Response;
using SmjleFood_Project.Service.Service;

namespace SmjleFood_Project.API.Controllers
{
    /*
     This controller is for ...
     */

    [Route(Helpers.SettingVersionAPI.ApiVersion)]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly ISettingService _settingsService;

        public SettingController(ISettingService settingService)
        {
            _settingsService = settingService;
        }

        /// <summary>
        /// Get List Timeslot
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("GetListTimeslot")]
        public async Task<ActionResult<PagedResults<TimeSlotResponse>>> GetListTimeslot
            ([FromQuery] TimeSlotResponse request, [FromQuery] PagingRequest paging)
        {
            try
            {
                var rs = await _settingsService.GetListTimeSlot(request, paging);
                return Ok(rs);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
