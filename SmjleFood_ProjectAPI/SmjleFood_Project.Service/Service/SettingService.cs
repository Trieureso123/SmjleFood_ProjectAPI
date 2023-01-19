using AutoMapper;
using SmjleFood_Project.Data.Entity;
using SmjleFood_Project.Data.UnitOfWork;
using SmjleFood_Project.Service.DTO.Request;
using SmjleFood_Project.Service.DTO.Response;
using SmjleFood_Project.Service.Exceptions;
using SmjleFood_Project.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SmjleFood_Project.Service.Service
{
    public interface ISettingService
    {
        Task<PagedResults<TimeSlotResponse>> GetListTimeSlot(TimeSlotResponse response, PagingRequest paging);
        
    }

    public class SettingService : ISettingService
    {
        private IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SettingService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;   
        }

        public async Task<PagedResults<TimeSlotResponse>> GetListTimeSlot(TimeSlotResponse response, PagingRequest paging)
        {
            try
            {
                TimeSlot[] timeslotList = 
                    _unitOfWork.Repository<TimeSlot>().GetAll().ToArray();
                List<TimeSlotResponse> listResult
                    = _mapper.Map<TimeSlot[], TimeSlotResponse[]>(timeslotList).ToList();
            
                var result = 
                    PageHelper<TimeSlotResponse>.Paging(listResult, paging.Page, paging.PageSize);
                return result;
            }
            catch (CrudException ex)
            {
                throw new CrudException(HttpStatusCode.BadRequest, "", ex.Message);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
