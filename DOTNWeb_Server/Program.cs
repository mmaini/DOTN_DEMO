using DOTN_Business.Repository;
using DOTN_Business.Repository.IRepository;
using DOTN_DataAccess.Data;
using DOTNWeb_Server.Data;
using DOTNWeb_Server.Service;
using DOTNWeb_Server.Service.IService;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


//mo�emo proslijediti neke argumente
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders().AddDefaultUI()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IFileUpload, FileUpload>();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();

//ovo �e zbuildati aplikaciju
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //prika�i default Error stranicu
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

//default routing
app.UseRouting();

SeedDatabase();
//dodajemo signalR konekciju 
app.MapBlazorHub();

//ako ne prona�e ni�ta drugo kod pokretanja onda ide na _Host
app.MapFallbackToPage("/_Host");
app.UseAuthentication();
app.UseAuthorization();

//u ovom koraku �e se aplikacija pokrenuti
app.Run();


void SeedDatabase()
{
    using (var scope= app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
    }
}