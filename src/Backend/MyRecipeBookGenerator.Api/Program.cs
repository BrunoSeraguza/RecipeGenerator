using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using MyRecipeBookGenerator.Api.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<RequestLocalizationOptions>(options =>
{

    var suportedLanguages = new List<CultureInfo> { new("en"), new("es"),new("pt-BR")};

    options.DefaultRequestCulture = new  RequestCulture("en");
    options.SupportedCultures = suportedLanguages;
    options.SupportedUICultures = suportedLanguages;

    options.RequestCultureProviders = new List<IRequestCultureProvider> { new AcceptLanguageHeaderRequestCultureProvider() };

});
builder.Services.AddMvc(options => options.Filters.Add<ExceptionFilter>());

var app = builder.Build();

var optionsLocatization = app.Services.GetRequiredService<IOptions< RequestLocalizationOptions>>();
app.UseRequestLocalization(optionsLocatization.Value);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
