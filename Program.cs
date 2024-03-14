using E_Commerc;
using E_Commerc.Data;
using E_Commerc.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor(options =>
{
    options.DetailedErrors = true;
});
builder.Services.AddScoped<ITshirtService, TshirtService>();
builder.Services.AddScoped<IAuthService,  AuthService>();
builder.Services.AddScoped<IApiService, ApiService>();
builder.Services.AddScoped<ICartService, CartServices>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<OrderProductDTO>();
builder.Services.AddScoped<CartItemTshirtDTO>();

builder.Services.AddAuthentication("Cookies").AddCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(120);
    options.SlidingExpiration = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
