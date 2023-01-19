using AutoMapper;
using SmjleFood_Project.Data.Entity;
using SmjleFood_Project.Service.DTO.Request;
using SmjleFood_Project.Service.DTO.Response;

namespace SmjleFood_Project.API.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            #region Brand
            #endregion

            #region Store
            #endregion

            #region Category
            #endregion

            #region Product
            CreateMap<Product, ProductResponse>();
            CreateMap<CreateProductRequest, Product>();
            CreateMap<UpdateProductRequest, Product>();
            #endregion

            #region ProductInMenu
            #endregion

            #region ProductInCombo
            #endregion

            #region ComboProduct
            #endregion

            #region Menu
            #endregion

            #region TimeSlot
            CreateMap<TimeSlot, TimeSlotResponse>().ReverseMap();  
            #endregion

            #region Collection
            #endregion

            #region CollectionItem
            #endregion

            #region Transaction
            #endregion

            #region Order
            #endregion

            #region OrderDetail
            #endregion

            #region Payment
            #endregion

            #region Shipper
            #endregion

            //AdminAccount not have DB table yet
            #region AdminAccount
            #endregion

            #region Area
            #endregion

            #region Floor
            #endregion

            #region Room
            #endregion





        }
    }
}
