using Bion.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using BionModels.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CinemaContextConnection");;


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<CinemaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<IdentityUser,IdentityRole>()
    .AddEntityFrameworkStores<CinemaContext>().AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender, EmailSender>();

//cookie for bad login,logout and if you're not authorized
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";

});


//TODO: how to store sensetive information?
builder.Services.AddAuthentication().AddFacebook(options =>
{
    options.AppId = "appid";
    options.AppSecret = "appsecret";
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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
