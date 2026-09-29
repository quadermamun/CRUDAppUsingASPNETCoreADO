using CRUDAppUsingADO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Extract the connection string
string connectionString = builder.Configuration.GetConnectionString("CURDADODBCONNECTIONSTRING")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Register your custom ADO.NET Data Repository/Service with DI
builder.Services.AddScoped<IEmployeeRepository>(sp => new EmployeeDataAccessLayer(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
