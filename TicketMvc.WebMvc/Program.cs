using Microsoft.EntityFrameworkCore;
using TicketMvc.Data;
using TicketMvc.Data.Entities;
using TicketMvc.Services;
using TicketMvc.Services.User;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// Add services to the container.
// DbContext configuration, adds the DbContext for dependency injection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IShowService, ShowService>();

// Enables using Identity Managers (Users, SignIn, Password)
builder.Services.AddDefaultIdentity<UserEntity>(options => {
    options.Password.RequiredLength = 4;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<AppDbContext>();

// Configure what happens when a logged out user tries to access an authorized route
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
