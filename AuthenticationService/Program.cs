using Authentication.Contract;
using Authentication.Models;
using Authentication.Services;
using EstateManager.Contract;
using EstateManager.Data;
using EstateManager.Dto;
using EstateManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer( builder.Configuration.GetConnectionString( "DefaultConnection"));
});

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGeneretor>();
builder.Services.AddScoped<IUsersService, UserService>();
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddIdentityCore<Users>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequiredLength = 8;    
    opt.User.RequireUniqueEmail = true;
})
    .AddRoles<Roles>()
    .AddRoleManager<RoleManager<Roles>>()    
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("MobilAppUsers", policy => policy.RequireRole("MobileUser"))
    .AddPolicy("AdminUser", policy => policy.RequireRole("Admin"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
