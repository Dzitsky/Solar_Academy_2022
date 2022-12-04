using ShoppingCart.Api;
using ShoppingCart.Registrar;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

builder.Services.AddMemoryCache();

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

public partial class Program { }