using WebSort;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IArrayRepository, ArrayRepository>(provider => new ArrayRepository("Data Source=DESKTOP-FOCMMOT\\SQLSERVER;Initial Catalog=Arrays;Persist Security Info=True;User ID=sa;Password=sa;Encrypt=False"));
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
