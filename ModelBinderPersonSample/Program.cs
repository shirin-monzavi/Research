using JsonSubTypes;
using ModelBinderPersonSample.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.ModelBinderProviders.Insert(0, new DeviceModelBinderProvider());
})
    .AddNewtonsoftJson(options =>
    {
        //Register the subtypes of the Device (Phone and Laptop)
        //and define the device Discriminator
        options.SerializerSettings.Converters.Add(
            JsonSubtypesConverterBuilder
            .Of(typeof(Person), "PersonType")
            .RegisterSubtype(typeof(Teacher), PersonTypeEnum.Teacher)
            .RegisterSubtype(typeof(Student), PersonTypeEnum.Student)
            .SerializeDiscriminatorProperty()
            .Build()
        );
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Add the features of Polymorphism to the swagger
builder.Services.AddSwaggerGen(c =>
{
    c.UseAllOfToExtendReferenceSchemas();
    c.UseAllOfForInheritance();
    c.UseOneOfForPolymorphism();
    c.SelectDiscriminatorNameUsing(type =>
    {
        return type.Name switch
        {
            nameof(Person) => "PersonType",
            _ => null
        };
    });
});
var app = builder.Build();
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