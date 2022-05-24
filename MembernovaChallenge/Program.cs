using MembernovaChallenge.AutoMapper;
using MembernovaChallenge.Services;
using MembernovaChallenge.Services.Contracts;
using MembernovaChallenge.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfiles();
});

var countriesApiSettings = builder.Configuration.GetSection("CountriesApi").Get<CountriesApiSettings>();
builder.Services.AddSingleton(countriesApiSettings);

builder.Services.AddHttpClient<ICountriesService, ApiCountriesService>(httpClient =>
{
    if(countriesApiSettings.Url == null)
    {
        throw new MissingFieldException("CountriesApi:Url is required field in configuration file");
    }

    httpClient.BaseAddress = new Uri(countriesApiSettings.Url);
});

var app = builder.Build();

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
