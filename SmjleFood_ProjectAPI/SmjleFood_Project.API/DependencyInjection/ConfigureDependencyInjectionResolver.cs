using Autofac;
using SmjleFood_Project.Data.Repository;
using SmjleFood_Project.Data.UnitOfWork;
using SmjleFood_Project.Service.Service;

namespace SmjleFood_Project.API.DependencyInjection
{
    public static class ConfigureDependencyInjectionResolver
    {
        public static ContainerBuilder DependencyInjection(this ContainerBuilder builder)
        {
            // Register your own things directly with Autofac, like:

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            //builder.RegisterType<CategoryService>().As<ICategoryService>();
            //builder.RegisterType<CustomerService>().As<ICustomerService>();
            //builder.RegisterType<MenuService>().As<IMenuService>();
            //builder.RegisterType<OrderService>().As<IOrderService>();
            //builder.RegisterType<ProductInMenuService>().As<IProductInMenuService>();

            //builder.RegisterType<StoreService>().As<IStoreService>();
            //builder.RegisterType<UserService>().As<IUserService>();
            //builder.RegisterType<ProductService>().As<IProductService>();
            //builder.RegisterType<SettingService>().As<ISettingService>();

            builder.RegisterGeneric(typeof(GenericRepository<>))
            .As(typeof(IGenericRepository<>))
            .InstancePerLifetimeScope();

            return builder;
        }
    }
}
