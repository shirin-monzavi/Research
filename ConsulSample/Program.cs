using Winton.Extensions.Configuration.Consul;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.ConfigureAppConfiguration((context, config) =>
{
    var consulHost = config.Build().GetValue<string>("ConsulServer");
    config.AddConsul("FeatureManagement",
        options =>
        {
            options.ConsulConfigurationOptions =
                                          cco => { cco.Address = new Uri("http://127.0.0.1:8500"); };
            options.Optional = true;
            options.ReloadOnChange = true;
            options.OnLoadException = exceptionContext => { exceptionContext.Ignore = true; };
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
