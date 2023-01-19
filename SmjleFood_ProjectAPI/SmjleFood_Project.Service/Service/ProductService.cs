using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
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
    public interface IProductService
    {
        Task<PagedResults<ProductResponse>> GetProducts(ProductResponse request, PagingRequest paging);
        Task<ProductResponse> GetProductById(int productId);
        Task<ProductResponse> GetProductByCode(string code);
        Task<PagedResults<ProductResponse>> GetProductByStore(int storeId, PagingRequest paging);
        Task<PagedResults<ProductResponse>> GetProductByCategory(int cateId, PagingRequest paging);
        Task<PagedResults<ProductResponse>> GetProductByTimeSlot(int timeSlotId, PagingRequest paging);
        Task<ProductResponse> CreateProduct(CreateProductRequest request);
        Task<ProductResponse> UpdateProduct(int productId, UpdateProductRequest request);
        Task<PagedResults<ProductResponse>> SearchProduct(string searchString, int timeSlotId, PagingRequest paging);
        Task<PagedResults<ProductResponse>> SearchProductInMenu(string searchString, int timeSlotId, PagingRequest paging);
    }

    public class ProductService : IProductService
    {
        private IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductResponse> CreateProduct(CreateProductRequest request)
        {
            try
            {
                var checkProduct = 
                    _unitOfWork.Repository<Product>()
                    .Find(x => x.Code == request.Code);
                if (checkProduct != null)
                {
                    throw new CrudException(HttpStatusCode.NotFound, 
                        "Product all ready exist!!!!!", request.Code);
                }
                var product = _mapper.Map<CreateProductRequest, Product>(request);

                //product.IsAvailable = (bool)ProductStatsEnum.IsAvailable;
                product.IsAvailable = true;
                product.CreatedAt = DateTime.Now;

                await _unitOfWork.Repository<Product>().InsertAsync(product);
                await _unitOfWork.CommitAsync();

                return _mapper.Map<Product, ProductResponse>(product);
            }
            catch (CrudException ex)
            {
                throw new CrudException(ex.Status, ex.Message, ex?.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<PagedResults<ProductResponse>> GetProductByCategory(int cateId, PagingRequest paging)
        {
            //try
            //{
            //    var product = await _unitOfWork.Repository<Product>().GetAll()
            //                    .Where(x => x.CategoryId == cateId)
            //                    .ProjectTo<ProductResponse>(_mapper.ConfigurationProvider)
            //                    .ToListAsync();

            //    var result = PageHelper<ProductResponse>.Paging(product, paging.Page, paging.PageSize);
            //    return result;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
            return null;
        }

        public async Task<ProductResponse> GetProductByCode(string code)
        {
            Product product = null;
            product = await _unitOfWork.Repository<Product>().GetAll()
                .Where(x => x.Code.Contains(code))
                .FirstOrDefaultAsync();

            if (product == null)
            {
                throw new CrudException(HttpStatusCode.NotFound, "Not found product with code", code);
            }
            return _mapper.Map<Product, ProductResponse>(product);
        }

        public async Task<ProductResponse> GetProductById(int productId)
        {
            Product product = null;
            product = await _unitOfWork.Repository<Product>().GetAll()
                .Where(x => x.Id == productId)
                .FirstOrDefaultAsync();
            if (product == null)
            {
                throw new CrudException(HttpStatusCode.NotFound, "Not found product with id", productId.ToString());
            }
            return _mapper.Map<Product, ProductResponse>(product);
        }

        public async Task<PagedResults<ProductResponse>> GetProductByStore(int storeId, PagingRequest paging)
        {
            try
            {
                var product = await _unitOfWork.Repository<Product>().GetAll()
                    .Where(p => p.StoreId == storeId)
                    .ProjectTo<ProductResponse>(_mapper.ConfigurationProvider)
                    .ToListAsync();
                if (product == null)
                {
                    throw new CrudException(HttpStatusCode.NotFound, "Not found product with storeID", storeId.ToString());
                }
                var result = PageHelper<ProductResponse>.Paging(product, paging.Page, paging.PageSize);
                return result;
            }
            catch (CrudException ex)
            {
                throw ex;
            }
            catch (Exception e)
            {
                throw new CrudException(HttpStatusCode.BadRequest, "Get product error!!!!", e?.Message);
            }
        }

        public async Task<PagedResults<ProductResponse>> GetProductByTimeSlot(int timeSlotId, PagingRequest paging)
        {
            //try
            //{

            //    var productInMenu = await _unitOfWork.Repository<ProductInMenu>().GetAll()
            //                        .Where(x => x.Menu.TimeSlots == timeSlotId)
            //                        .ProjectTo<ProductResponse>(_mapper.ConfigurationProvider)
            //                        .ToListAsync();

            //    var result = PageHelper<ProductResponse>.Paging(productInMenu, paging.Page, paging.PageSize);
            //    return result;
            //}
            //catch (CrudException ex)
            //{
            //    throw new CrudException(HttpStatusCode.BadRequest, "Get Product By Time Slot Error!!!!", ex?.Message);
            //}
            //catch (Exception e)
            //{
            //    throw new Exception(e.Message);
            //}
            return null;
        }

        public async Task<PagedResults<ProductResponse>> GetProducts(ProductResponse request, PagingRequest paging)
        {
            try
            {
                var product = _unitOfWork.Repository<Product>().GetAll().ToArray();
                var productList =
                    _mapper.Map<Product[], ProductResponse[]>(product).ToList();

                var result = PageHelper<ProductResponse>.Paging(productList, paging.Page, paging.PageSize);
                return result;
            }
            catch (CrudException ex)
            {
                throw new CrudException(HttpStatusCode.BadRequest, "Get Product Error!!!!", ex?.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<PagedResults<ProductResponse>> SearchProduct(string searchString, int timeSlotId, PagingRequest paging)
        {
            var product = _unitOfWork.Repository<Product>().GetAll()
                                .Where(x => x.ProductName.Contains(searchString))
                                .ProjectTo<ProductResponse>(_mapper.ConfigurationProvider)
                                .ToList();

            var result = PageHelper<ProductResponse>.Paging(product, paging.Page, paging.PageSize);
            return result;
        }

        public async Task<PagedResults<ProductResponse>> SearchProductInMenu(string searchString, int timeSlotId, PagingRequest paging)
        {
            //var productInMenu = _unitOfWork.Repository<ProductInMenu>().GetAll()
            //                    .Where(x => x.Menu.TimeSlotId == timeSlotId && x.Product.Name.Contains(searchString))
            //                    .ProjectTo<ProductResponse>(_mapper.ConfigurationProvider)
            //                    .ToList();

            //var result = PageHelper<ProductResponse>.Paging(productInMenu, paging.Page, paging.PageSize);
            //return result;
            return null;
        }
        public async Task<ProductResponse> UpdateProduct(int productId, UpdateProductRequest request)
        {
            try
            {
                Product product = null;
                product = _unitOfWork.Repository<Product>()
                    .Find(p => p.Id == productId);
                if (product == null)
                {
                    throw new CrudException(HttpStatusCode.NotFound, "Not found product with id", productId.ToString());
                }
                _mapper.Map<UpdateProductRequest, Product>(request, product);
                product.Active = true;
                product.UpdatedAt = DateTime.Now;

                await _unitOfWork.Repository<Product>().UpdateDetached(product);
                await _unitOfWork.CommitAsync();
                return _mapper.Map<Product, ProductResponse>(product);
            }
            catch (Exception ex)
            {
                throw new CrudException(HttpStatusCode.BadRequest, "Update product error!!!!", ex?.Message);
            }
        }
    }
}
