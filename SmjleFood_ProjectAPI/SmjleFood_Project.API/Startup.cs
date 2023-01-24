using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.AspNetCore3;
using Hangfire;
using Autofac;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.OpenApi.Models;
using SmjleFood_Project.API.AutoMapper;
using SmjleFood_Project.Data.Repository;
using SmjleFood_Project.Data;
using System.Text;
using SmjleFood_Project.Data.MakeConnection;
using SmjleFood_Project.Data.Context;
using SmjleFood_Project.Data.Entity;
using SmjleFood_Project.API.Helpers;
using SmjleFood_Project.Service.Helpers;
using SmjleFood_Project.Data.UnitOfWork;
using SmjleFood_Project.Service.Service;
using SmjleFood_Project.API.DependencyInjection;

namespace SmjleFood_Project.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. 
        //Use this method to add services to the container.
#pragma warning disable CA1041 // Provide ObsoleteAttribute message
        
        [Obsolete]
        #region Knowledge
        /*
            Trong C#, Obsolote đánh dấu một thực thể chương trình mà 
        không nên được sử dụng. Nó cho bạn thông báo với trình biên dịch 
        để loại bỏ một phần tử target cụ thể. Ví dụ, khi một phương thức mới 
        đang được sử dụng trong một lớp và nếu bạn vẫn muốn giữ lại 
        phương thức cũ trong lớp này, bạn có thể đánh dấu nó là 
        obsolete (lỗi thời) bằng việc hiển thị một thông báo là 
        phương thức mới sẽ được sử dụng, thay cho phương thức cũ.

         */
        #endregion

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder
                        ////.WithOrigins(GetDomain())
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });
            services.AddControllersWithViews();
            services.AddControllers(options =>
            {
                options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SmjleFood Project API",
                    Version = "v1"
                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                #region README
                /*
                 - README: https://topdev.vn/blog/json-web-token-la-gi/
                 */
                #endregion

                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                c.AddSecurityDefinition("Bearer", securitySchema);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                        securitySchema,
                    new string[] { "Bearer" }
                    }
                });
            });
            services.ConnectToConnectionString(Configuration);

            #region JWT

            var appSettingsSection = Configuration.GetSection("AppSettings");

            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();

            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
            });

            #endregion JWT

        }

        #region Old ConfigureContainer Code
        //public void ConfigureContainer(ContainerBuilder builder)
        //{
        //    // Register your own things directly with Autofac, like:

        //    builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

        //    //builder.RegisterType<CategoryService>().As<ICategoryService>();
        //    //builder.RegisterType<CustomerService>().As<ICustomerService>();
        //    //builder.RegisterType<MenuService>().As<IMenuService>();
        //    //builder.RegisterType<OrderService>().As<IOrderService>();
        //    //builder.RegisterType<ProductInMenuService>().As<IProductInMenuService>();
        //    builder.RegisterType<StoreService>().As<IStoreService>();
        //    builder.RegisterType<UserService>().As<IUserService>();
        //    builder.RegisterType<ProductService>().As<IProductService>();
        //    builder.RegisterType<SettingService>().As<ISettingService>();

        //    builder.RegisterGeneric(typeof(GenericRepository<>))
        //    .As(typeof(IGenericRepository<>))
        //    .InstancePerLifetimeScope();
        //}
        #endregion

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.DependencyInjection();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.ConfigMigration<SmjleFoodDBContext>();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseExceptionHandler("/error");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmjleFood Api V1");
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseDeveloperExceptionPage();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
