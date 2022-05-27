using AutoMapper;
using MembernovaChallenge.Application.BusinessLogic;
using MembernovaChallenge.Application.Mocks;
using MembernovaChallenge.AutoMapper;
using MembernovaChallenge.Contracts.BusinessLogic;
using MembernovaChallenge.Contracts.Services;
using MembernovaChallenge.CountriesApi;
using MembernovaChallenge.Domain.Settings;
using MembernovaChallenge.Extensions;
using MembernovaChallenge.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseDefaultServiceProvider(options =>
{
    options.ValidateScopes = true;
    options.ValidateOnBuild = true;
});

builder.Services.AddRazorPages();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExceptionFilter>();
}).AddControllersAsServices();

builder.Services.AddExceptionResolvers();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfiles();
});

var countriesApiSettings = builder.Configuration.GetSection("CountriesApi").Get<CountriesApiSettings>();
builder.Services.AddSingleton(countriesApiSettings);

builder.Services.AddScoped<ICountryBusinessLogic, CountryBusinessLogic>();
builder.Services.AddScoped<IRegionBusinessLogic, RegionBusinessLogic>();
builder.Services.AddScoped<IUserBusinessLogic, UserBusinessLogic>();

builder.Services.AddScoped<IUserService, UserServiceMock>();

builder.Services.AddHttpClient<ICountriesService, ApiCountriesService>(httpClient =>
{
    if(countriesApiSettings.Url == null)
    {
        throw new MissingFieldException("CountriesApi:Url is required field in configuration file");
    }

    httpClient.BaseAddress = new Uri(countriesApiSettings.Url);
});

var app = builder.Build();

var mapper = app.Services.GetRequiredService<IMapper>();
mapper.ConfigurationProvider.AssertConfigurationIsValid();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapControllers();
app.MapRazorPages();

app.Run();
