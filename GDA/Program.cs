using AutoMapper;
using FluentValidation;
using GDA.Concern.Enums;
using GDA.Data.DataStore;
using GDA.Data.ReferenceCatalog.DocumentType;
using GDA.Managers.PassengerManagers;
using GDA.Mapper.AutoMapperProfiles;
using GDA.Model.Entity;
using GDA.Model.WebModel;
using GDA.Validators;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

MapperConfiguration mapperConfig = new(config =>
{
    config.AddProfile(new PassengerMapperProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddSwaggerGen(swaggerOptions =>
{
    swaggerOptions.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API",
        Version = "v1",
    });
    swaggerOptions.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
});

builder.Services.AddScoped<IValidator<CreatePassengerRequestModel>, CreatePassengerValidator>();
builder.Services.AddScoped<IValidator<UpdatePassengerRequestModel>, UpdatePassengerValidator>();

builder.Services.AddScoped<IPassengerManager, PassengerManager>();

builder.Services.AddSingleton<IDocumentTypeCache, DocumentTypeCache>();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "GDA");
});

OnlinePassengerCache.Instance.Add(new Passenger(Guid.NewGuid()) { Name = "Ad 1", Surname = "Soyad 1", Gender = Gender.Male, DocumentData = new Document() { DocumentNo = "1234", DocumentType = "Pasaport", IssueDate = DateTime.Now } });
OnlinePassengerCache.Instance.Add(new Passenger(Guid.NewGuid()) { Name = "Ad 2", Surname = "Soyad 2", Gender = Gender.Female, DocumentData = new Document() { DocumentNo = "XYZ", DocumentType = "Visa", IssueDate = DateTime.Now } });
OfflinePassengerCache.Instance.Add(new Passenger(Guid.NewGuid()) { Name = "Ad 3", Surname = "Soyad 3", Gender = Gender.Male, DocumentData = new Document() { DocumentNo = "5678", DocumentType = "TravelDocument", IssueDate = DateTime.Now } });
OfflinePassengerCache.Instance.Add(new Passenger(Guid.NewGuid()) { Name = "Ad 4", Surname = "Soyad 4", Gender = Gender.Female, DocumentData = new Document() { DocumentNo = "ABC", DocumentType = "Pasaport", IssueDate = DateTime.Now } });

app.Run();