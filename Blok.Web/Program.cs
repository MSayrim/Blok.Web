using Blok.Core;
using Blok.Core.Services;
using Blok.Data;
using Blok.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IArticleService, ArticleService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddDistributedMemoryCache();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection2");
builder.Services.AddDbContext<BlogDBContext>(options => options.UseSqlServer(connectionString , x => x.MigrationsAssembly("Blok.Data")));

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
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
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
