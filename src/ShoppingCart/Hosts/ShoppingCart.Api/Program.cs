
using Microsoft.AspNetCore.Identity;
using Serilog;
using Serilog.Formatting.Json;
using Serilog.Sinks.Elasticsearch;
using Serilog.Sinks.File;
using ShoppingCart.Api;
using ShoppingCart.DataAccess;
using ShoppingCart.Domain;
using ShoppingCart.Registrar;

var builder = WebApplication.CreateBuilder(args);

//builder.Host.ConfigureLogging(options => options.AddEventLog());

//builder.Host.UseSerilog((context, services, configuration) =>
//configuration.ReadFrom.Configuration(context.Configuration)
//.Enrich.FromLogContext()
//.WriteTo.Console()

//.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
//{
//    FailureCallback = e =>
//    {
//        Console.WriteLine("Unable to submit event " + e.Exception);
//    },
//    FailureSink = new FileSink("./failures.txt", new JsonFormatter(), null),
//    TypeName = null,
//    IndexFormat = "api-logs",
//    AutoRegisterTemplate = true,
//    EmitEventFailure = EmitEventFailureHandling.ThrowException | EmitEventFailureHandling.RaiseCallback | EmitEventFailureHandling.WriteToSelfLog
//})

//.WriteTo.Seq("http://localhost:5341")

//.WriteTo.EventLog("EventLog", manageEventSource: true)

//);

// Add services to the container.

//builder.Services.AddSingleton(typeof(ILogger<>), typeof(MyLogger<>));

builder.Services.AddServiceRegistrationModule();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHttpContextAccessor();

builder.Services.AddSwaggerModule();

builder.Services.AddAuthenticationModule(builder.Configuration);

//builder.Services.AddIdentity<ApplicationUser,IdentityRole>()
//    .AddEntityFrameworkStores<ShoppingCartContext>()
//    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shopping Cart Api v1"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();