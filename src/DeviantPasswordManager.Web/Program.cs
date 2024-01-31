using Ardalis.GuardClauses;
using Ardalis.ListStartupServices;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DeviantPasswordManager.Core;
using DeviantPasswordManager.Core.IdentityAggregate;
using DeviantPasswordManager.Core.Interfaces;
using DeviantPasswordManager.Infrastructure;
using DeviantPasswordManager.Infrastructure.Data;
using DeviantPasswordManager.Infrastructure.Identity;
using DeviantPasswordManager.Web.Common;
using DeviantPasswordManager.Web.Services;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));

builder.Services.Configure<CookiePolicyOptions>(options =>
{
  options.CheckConsentNeeded = context => true;
  options.MinimumSameSitePolicy = SameSiteMode.None;
});

string? connectionString = builder.Configuration.GetConnectionString("SqlServerConnection");
Guard.Against.Null(connectionString);
builder.Services.AddApplicationDbContext(connectionString);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument(o =>
{
  o.ShortSchemaNames = true;
});


builder.Services.Configure<SiteSettings>(builder.Configuration.GetSection(nameof(SiteSettings)));

var sitSettings = builder.Configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
builder.Services.AddCustomIdentity(sitSettings!.IdentitySettings, connectionString!);
builder.Services.AddCustomJwtAuthentication(sitSettings!.JwtSettings);


// add list services for diagnostic purposes - see https://github.com/ardalis/AspNetCoreStartupServices
builder.Services.Configure<ServiceConfig>(config =>
{
  config.Services = new List<ServiceDescriptor>(builder.Services);

  // optional - default path to view services is /listallservices - recommended to choose your own path
  config.Path = "/listservices";
});


builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
  containerBuilder.RegisterModule(new DefaultCoreModule());
  containerBuilder.RegisterModule(new AutofacInfrastructureModule(builder.Environment.IsDevelopment()));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
  app.UseShowAllServicesMiddleware(); // see https://github.com/ardalis/AspNetCoreStartupServices
}
else
{
  app.UseDefaultExceptionHandler(); // from FastEndpoints
  app.UseHsts();
}

app.UseCustomExceptionHandler();

app.UseRouting();
app.UseFastEndpoints(c =>
{
  c.Endpoints.RoutePrefix = "api";
});
app.UseSwaggerGen(); // FastEndpoints middleware


app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

SeedDatabase(app);

app.Run();

static void SeedDatabase(WebApplication app)
{
  using var scope = app.Services.CreateScope();
  var services = scope.ServiceProvider;

  try
  {
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
    // context.Database.EnsureCreated();
    // SeedData.Initialize(services);

    var identityContext = services.GetRequiredService<AppIdentityDbContext>();
    identityContext.Database.Migrate();
    // identityContext.Database.EnsureCreated();
  }
  catch (Exception ex)
  {
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
  }
}

// Make the implicit Program.cs class public, so integration tests can reference the correct assembly for host building
public partial class Program
{
}
