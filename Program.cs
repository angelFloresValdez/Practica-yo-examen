using ConexionEF;
using ConexionEF.Servicios;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//Politica de autentificación.
var polityUserAuthentifition = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();

// Add services to the container.
builder.Services.AddControllersWithViews(
    opc => opc.Filters.Add(new AuthorizeFilter(polityUserAuthentifition))
);

//Esto es para la conexion a la BASE DE DATOS.
builder.Services.AddDbContext<ApplicationDbContext>(opc => opc.UseSqlServer("name=MyConnection"));


 builder.Services.AddAuthentication();

 //Utilizar los servicios de Identity
 builder.Services.AddIdentity<IdentityUser, IdentityRole>(
    opc =>  { opc.SignIn.RequireConfirmedAccount = false; }
).AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders()
.AddErrorDescriber<MensajesDeErrorIdentity>();

builder.Services.PostConfigure<CookieAuthenticationOptions>(
    IdentityConstants.ApplicationScheme, opc => 
    {
        opc.LoginPath = "/user/login";
        opc.AccessDeniedPath = "/user/login";
    }
);

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


app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
