using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using toshokan.Data;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<toshokanContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("toshokanContext") ?? throw new InvalidOperationException("Connection string 'toshokanContext' not found.")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


// Add session
builder.Services.AddSession(options =>
{
    // Thiết lập thời gian timeout của session 
    options.IdleTimeout = TimeSpan.FromMinutes(30);

    // Thiết lập tên cookie của session
    options.Cookie.Name = "MySessionCookie";

    // Cấu hình các tùy chọn khác nếu cần
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<toshokanContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession();
app.MapRazorPages();

app.Run();
