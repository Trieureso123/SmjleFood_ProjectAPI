using AutoMapper;
using Azure.Core;
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
using static SmjleFood_Project.Service.Helpers.Enum;

namespace SmjleFood_Project.Service.Service
{
    public interface IStoreService
    {
        Task<PagedResults<StoreResponse>> GetStores(StoreResponse request, PagingRequest paging);
        Task<StoreResponse> GetStoreById(int StoreId);
        Task<StoreResponse> UpdateStore(int StoreId, UpdateStoreRequest request);
        Task<StoreResponse> CreateStore(CreateStoreRequest request);
        bool DeleteStore(int StoreId);
    }

    public class StoreService : IStoreService
    {
        private IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public StoreService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<StoreResponse> CreateStore(CreateStoreRequest request)
        {
            try
            {
                var CheckStore =
                _unitOfWork.Repository<Store>()
                .Find(x => x.StoreName.Equals(request.StoreName));
                if (CheckStore != null)
                {
                    throw new CrudException(HttpStatusCode.BadRequest,
                        "Store already existed!", request.StoreName);
                }

                //if the Store is not existed 
                var store = _mapper.Map<CreateStoreRequest, Store>(request);
                store.Active = true;
                store.CreateAt = DateTime.Now;

                await _unitOfWork.Repository<Store>().InsertAsync(store);
                await _unitOfWork.CommitAsync();

                return _mapper.Map<Store, StoreResponse>(store);
            }
            catch (CrudException ex)
            {
                throw new CrudException(HttpStatusCode.BadRequest, "Create Store Data Error!", ex?.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<PagedResults<StoreResponse>> GetStores(StoreResponse request, PagingRequest paging)
        {
            try
            {
                var store = _unitOfWork.Repository<Store>().GetAll().ToArray();
                var storeList =
                    _mapper.Map<Store[], StoreResponse[]>(store).ToList();
                var result = PageHelper<StoreResponse>
                    .Paging(storeList, paging.Page, paging.PageSize);
                return result;
            }
            catch (CrudException ex)
            {
                throw new CrudException(HttpStatusCode.BadRequest, "Get Store Data Error!", ex?.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<StoreResponse> GetStoreById(int StoreId)
        {
            try
            {
                Store store = null;
                store = _unitOfWork.Repository<Store>().GetAll()
                    .Where(x => x.Id == StoreId)
                    .FirstOrDefault();
                if (store == null)
                {
                    throw new CrudException(HttpStatusCode.NotFound, "Not found Store with Id", StoreId.ToString());
                }
                return _mapper.Map<Store, StoreResponse>(store);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<StoreResponse> UpdateStore(int StoreId, UpdateStoreRequest request)
        {
            try
            {
                Store store = null;
                store = _unitOfWork.Repository<Store>()
                    .Find(x => x.Id == StoreId);
                if (store == null)
                {
                    throw new CrudException(HttpStatusCode.NotFound,
                        "The Store Data is not existed", StoreId.ToString());
                }
                _mapper.Map<UpdateStoreRequest, Store>(request, store);
                store.UpdateAt = DateTime.Now;
                //it may be error because the field unchange will be set to null
                
                await _unitOfWork.Repository<Store>().UpdateDetached(store);
                await _unitOfWork.CommitAsync();
                return _mapper.Map<Store, StoreResponse>(store);
            }
            catch (CrudException ex)
            {
                throw new CrudException(HttpStatusCode.BadRequest, "Update Store Data Error!", ex?.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool DeleteStore(int StoreId)
        {
            try
            {
                var result = _unitOfWork.Repository<Store>().GetAll()
                    .Where(x => x.Id == StoreId).ToList();
                if (result != null)
                {
                    _unitOfWork.Repository<Store>().HardDelete(StoreId);
                    _unitOfWork.Commit();
                    return true;
                }
                return false;
            }
            catch (CrudException ex)
            {
                throw new CrudException(HttpStatusCode.BadRequest, "Delete Store Data Error!", ex?.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
