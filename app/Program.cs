using Microsoft.EntityFrameworkCore;
using OffsureAssessment.Context;
using OffsureAssessment.Services;

var builder = WebApplication.CreateBuilder(args);

// Add logging features
builder.Logging
.ClearProviders()
.AddSimpleConsole(options =>
        {
            options.SingleLine = true;
            options.TimestampFormat = "HH:mm:ss ";
            options.UseUtcTimestamp = true;
        })
.AddDebug();

// Add services to the container.
builder.Services
    .AddControllers(options =>
    {
        options.ReturnHttpNotAcceptable = true;
    })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    })
   .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

builder.Services.AddControllersWithViews();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContextFactory<ApplicationDbContext>(
       //options => options.UseNpgsql()
       options => options.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"))
);

builder.Services.AddScoped(typeof(IListingRepository<>), typeof(ListingRepository<>));

builder.Services.AddScoped<UnitOfWork>();

var app = builder.Build();

// update database on launch, not recommended for production
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
