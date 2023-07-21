using System.Text;
using System.Globalization;
using SoftwareOne.BaseLine.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Versioning;
using SoftwareOne.BaseLine.Api.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Base.Application.Validators;
using SoftwareOne.BaseLine.Api.Filters;

var builder = WebApplication.CreateBuilder(args);

if (builder != null) {
    builder.Services.AddResponseCompression();
    builder.Services.AddHttpContextAccessor();

    // Add services to the container.

    builder.Services.AddControllers();

    builder.Services.Configure<ApiBehaviorOptions>(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

    builder.Services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });

    builder.Services.AddControllers().AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        builder.Services.AddMvc()
        .AddJsonOptions(options => {
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });

    builder.Services.AddControllersWithViews(options =>
    {
        options.Filters.Add<AuthorizationFilter>();
    });

    builder.Services.AddApiVersioning(opt =>
    {
        opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
        opt.AssumeDefaultVersionWhenUnspecified = true;
        opt.ReportApiVersions = false;
        opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                        new HeaderApiVersionReader("x-api-version"),
                                                        new MediaTypeApiVersionReader("x-api-version"));
    });

    builder.Services.Configure<RequestLocalizationOptions>(options =>
    {
        List<CultureInfo> supportedCultures = new()
        {
            new CultureInfo("en-US"),
            new CultureInfo("es-CO")
        };

        options.DefaultRequestCulture = new RequestCulture("en-US");
        options.SupportedCultures = supportedCultures;
        options.SupportedUICultures = supportedCultures;
    });

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddMiddlewareResponseApi();

    builder.Services.AddSwaggerGen();
    builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

    builder.Services.Configure<SoftwareOne.BaseLine.Authentication.Common.AuthenticationConfiguration>(
        options =>
        {
            options.JwtKey = builder.Configuration.GetSection("JWT:SecretKey").Value ?? string.Empty;
            options.ExpirationTime = Convert.ToInt32(builder?.Configuration.GetSection("JWT:TokenLifeTime").Value);
        });

    var jwtKey = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JWT:SecretKey").Value ?? string.Empty);
    var tokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(jwtKey),

        ValidateIssuer = false,
        ValidateAudience = false,
        RequireExpirationTime = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };

    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.SaveToken = true;
        x.TokenValidationParameters = tokenValidationParameters;
    });

    builder.Services.AddSingleton(tokenValidationParameters);
    builder.Services.AddTransient<SoftwareOne.BaseLine.Authentication.IUserAuthenticator, SoftwareOne.BaseLine.Authentication.UserAuthenticator>();

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", builderCors => builderCors
        .WithOrigins(builder.Configuration.GetSection("AppConfiguration:CorsPolicyOrigins").Value?.Split('|') ?? new[] { "*" })
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
    });

    // Add ApiExplorer to discover versions
    builder.Services.AddVersionedApiExplorer(setup =>
    {
        setup.GroupNameFormat = "'v'VVV";
        setup.SubstituteApiVersionInUrl = true;
    });

    var conexionData = (Environment.GetEnvironmentVariable("DefaultConnection") ??
                                    builder.Configuration.GetSection("ConnectionStrings:Default").Value);
    builder.Services.AddDbContextFactory<SoftwareOne.BaseLine.DataAccess.SqlServer.Common.MainContextApplication>(options =>
                                        options
                                        .UseSqlServer(conexionData, m => m.MigrationsAssembly(typeof(SoftwareOne.BaseLine.DataAccess.SqlServer.Common.MainContextApplication).Assembly.FullName)));
    builder.Services.AddScoped<SoftwareOne.BaseLine.Core.DataAccess.IMainDataAccessContext, SoftwareOne.BaseLine.DataAccess.SqlServer.Common.MainContextApplication>();

    builder.Services.AddScoped<SoftwareOne.BaseLine.Core.ProcessServicesApplication.IProcessServicesApplication, SoftwareOne.BaseLine.ApplicationServices.ProcessServicesApplication>();

    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.DataAccess.IAuthorizationPermissions, SoftwareOne.BaseLine.DataAccess.SqlServer.AuthorizationPermissions>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.DataAccess.IAuthorizationPermissions, SoftwareOne.BaseLine.DataAccess.SqlServer.AuthorizationPermissions>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.DataAccess.IAudit, SoftwareOne.BaseLine.DataAccess.SqlServer.Audit>();        
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.DataAccess.IMenu, SoftwareOne.BaseLine.DataAccess.SqlServer.Menu>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.DataAccess.IUser, SoftwareOne.BaseLine.DataAccess.SqlServer.User>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.DataAccess.IRole, SoftwareOne.BaseLine.DataAccess.SqlServer.Role>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.DataAccess.IEntity, SoftwareOne.BaseLine.DataAccess.SqlServer.Entity>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.DataAccess.ICategory, SoftwareOne.BaseLine.DataAccess.SqlServer.Category>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.DataAccess.ICity, SoftwareOne.BaseLine.DataAccess.SqlServer.City>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.DataAccess.ICustomer, SoftwareOne.BaseLine.DataAccess.SqlServer.Customer>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.DataAccess.IProduct, SoftwareOne.BaseLine.DataAccess.SqlServer.Product>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.DataAccess.IShippingAddress, SoftwareOne.BaseLine.DataAccess.SqlServer.ShippingAddress>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.DataAccess.IShoppingCart, SoftwareOne.BaseLine.DataAccess.SqlServer.ShoppingCart>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.DataAccess.IShoppingCartItem, SoftwareOne.BaseLine.DataAccess.SqlServer.ShoppingCartItem>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.DataAccess.IState, SoftwareOne.BaseLine.DataAccess.SqlServer.State>();
    
    

    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Services.IAuthorizationPermissions, SoftwareOne.BaseLine.ApplicationServices.Services.AuthorizationPermissions>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Services.IAuthorizationPermissions, SoftwareOne.BaseLine.ApplicationServices.Services.AuthorizationPermissions>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Services.IAudit, SoftwareOne.BaseLine.ApplicationServices.Services.Audit>();    
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Services.IMenu, SoftwareOne.BaseLine.ApplicationServices.Services.Menu>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Services.IUser, SoftwareOne.BaseLine.ApplicationServices.Services.User>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Services.IRole, SoftwareOne.BaseLine.ApplicationServices.Services.Role>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Services.IEntity, SoftwareOne.BaseLine.ApplicationServices.Services.Entity>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Services.ICategory, SoftwareOne.BaseLine.ApplicationServices.Services.Category>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Services.ICity, SoftwareOne.BaseLine.ApplicationServices.Services.City>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Services.ICustomer, SoftwareOne.BaseLine.ApplicationServices.Services.Customer>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Services.IProduct, SoftwareOne.BaseLine.ApplicationServices.Services.Product>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Services.IShippingAddress, SoftwareOne.BaseLine.ApplicationServices.Services.ShippingAddress>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Services.IShoppingCart, SoftwareOne.BaseLine.ApplicationServices.Services.ShoppingCart>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Services.IShoppingCartItem, SoftwareOne.BaseLine.ApplicationServices.Services.ShoppingCartItem>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Services.IState, SoftwareOne.BaseLine.ApplicationServices.Services.State>();
    
    

    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Facade.IAuthorizationPermissions, SoftwareOne.BaseLine.ApplicationServices.Facade.AuthorizationPermissions>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Facade.IAuthorizationPermissions, SoftwareOne.BaseLine.ApplicationServices.Facade.AuthorizationPermissions>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Facade.IAudit, SoftwareOne.BaseLine.ApplicationServices.Facade.Audit>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Facade.IMenu, SoftwareOne.BaseLine.ApplicationServices.Facade.Menu>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Facade.IUser, SoftwareOne.BaseLine.ApplicationServices.Facade.User>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Facade.IRole, SoftwareOne.BaseLine.ApplicationServices.Facade.Role>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Facade.IEntity, SoftwareOne.BaseLine.ApplicationServices.Facade.Entity>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Facade.ICategory, SoftwareOne.BaseLine.ApplicationServices.Facade.Category>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Facade.ICity, SoftwareOne.BaseLine.ApplicationServices.Facade.City>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Facade.ICustomer, SoftwareOne.BaseLine.ApplicationServices.Facade.Customer>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Facade.IProduct, SoftwareOne.BaseLine.ApplicationServices.Facade.Product>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Facade.IShippingAddress, SoftwareOne.BaseLine.ApplicationServices.Facade.ShippingAddress>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Facade.IShoppingCart, SoftwareOne.BaseLine.ApplicationServices.Facade.ShoppingCart>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Facade.IShoppingCartItem, SoftwareOne.BaseLine.ApplicationServices.Facade.ShoppingCartItem>();
    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Facade.IState, SoftwareOne.BaseLine.ApplicationServices.Facade.State>();
    
    


    builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.IManageUserAccount, SoftwareOne.BaseLine.ApplicationServices.ManageUserAccount>();

    builder.Services.AddSingleton<AuthorizationPermissions>();
    builder.Services.AddSingleton<Audit>();    
    builder.Services.AddSingleton<Entity>();
    builder.Services.AddSingleton<Menu>();
    builder.Services.AddSingleton<Role>();
    builder.Services.AddSingleton<User>();
    builder.Services.AddSingleton<Category>();
    builder.Services.AddSingleton<City>();
    builder.Services.AddSingleton<Customer>();
    builder.Services.AddSingleton<Product>();
    builder.Services.AddSingleton<ShippingAddress>();
    builder.Services.AddSingleton<ShoppingCart>();
    builder.Services.AddSingleton<ShoppingCartItem>();
    builder.Services.AddSingleton<State>();
    
    

    builder.Services.AddSingleton<RequestLocalizationCookiesMiddleware>();

    builder.Services.AddHealthChecks();

    var app = builder.Build();

    app.UseResponseCompression();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
    });

    IWebHostEnvironment env = app.Environment;

    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to 
        // change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseRequestLocalization();
    app.UseRequestLocalizationCookies();

    app.UseStaticFiles();

    app.UseCors("CorsPolicy");

    app.UseHttpsRedirection();

    app.UseMiddlewareResponseApi();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.MapGet("/", () => "SWO - Base Line [OnLine]");

    app.Run();
}

namespace SoftwareOne.BaseLine.Api
{
    /// Partial Program class for testing.
    public partial class Program { }
}