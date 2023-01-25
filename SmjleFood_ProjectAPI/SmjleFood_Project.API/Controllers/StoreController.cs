using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmjleFood_Project.API.Helpers;
using SmjleFood_Project.Service.DTO.Request;
using SmjleFood_Project.Service.DTO.Response;
using SmjleFood_Project.Service.Service;

namespace SmjleFood_Project.API.Controllers
{
    [Route(Helpers.SettingVersionAPI.ApiVersion)]
    [ApiController]
    public class StoreController : ControllerBase
    {

        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        /// <summary>
        /// Get List Store
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PagedResults<StoreResponse>>> GetProducts
            ([FromQuery] StoreResponse request, [FromQuery] PagingRequest paging)
        {
            try
            {
                var rs = await _storeService.GetStores(request, paging);
                if (rs != null) return Ok(rs); 
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        ///<summary>
        /// Get Store By Id
        /// </summary>
        /// <param name="StoreId"></param>
        /// <return></return>
        [HttpGet("GetStoreById")]
        public async Task<ActionResult<PagedResults<StoreResponse>>> GetStoreById
            ([FromQuery] int StoreId, [FromQuery] PagingRequest paging)
        {
            try
            {
                var rs = await _storeService.GetStoreById(StoreId);
                if (rs != null) return Ok(rs);
                return BadRequest();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        /// Get Store By Id
        /// </summary>
        /// <param name="StoreId"></param>
        /// <return></return>
        [HttpPost("CreateProduct")]
        public async Task<ActionResult<StoreResponse>> CreateStore
            ([FromBody] CreateStoreRequest request)
        {
            try
            {
                var rs = await _storeService.CreateStore(request);
                if (rs != null) return Ok(rs);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);    
            }
        }

        ///<summary>
        /// Update Store Information
        /// </summary>
        /// <param name="request"></param>
        /// <return></return>
        [HttpPatch("UpdateStore")]
        public async Task<ActionResult<StoreResponse>> UpdateStore
            ([FromQuery] int StoreId, [FromBody] UpdateStoreRequest request)
        {
            try
            {
                var rs = await _storeService.UpdateStore(StoreId, request);
                return Ok(rs);
            }
            catch  (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        /// Update Store Information
        /// </summary>
        /// <param name="StoreId"></param>
        /// <return></return>
        [HttpDelete("DeleteStore")]
        public ActionResult DeleteStore
            ([FromQuery] int StoreId)
        {
            try
            {
                var rs = _storeService.DeleteStore(StoreId);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
