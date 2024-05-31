using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using toshokan.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<toshokanContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("toshokanContext") ?? throw new InvalidOperationException("Connection string 'toshokanContext' not found.")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
