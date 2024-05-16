using BlazorApp3.Components;
using BlazorApp3.Components.Account;
using BlazorApp3.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

var connectionString = builder.Configuration.GetConnectionString("ServerConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();


builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
.AddGoogle(options =>
{
    options.ClientId = builder.Configuration["GoogleKey:ClientId"];
    options.ClientSecret = builder.Configuration["GoogleKey:ClientSecret"];
/*    options.CallbackPath = "/signin-google"; // Ścieżka do przekierowania po autoryzacji Google

    // Konfiguracja dla automatycznego logowania użytkownika Google, jeśli już jest zalogowany
    options.Events.OnCreatingTicket = ctx =>
    {
        var userId = ctx.Identity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        return Task.CompletedTask;
    };

    // Konfiguracja dla wymuszenia logowania użytkownika Google, jeśli nie jest jeszcze zalogowany
    options.Events.OnRedirectToAuthorizationEndpoint = ctx =>
    {
        if (ctx.Request.Query.ContainsKey("returnUrl"))
        {
            ctx.Response.Redirect(ctx.Request.Query["returnUrl"]);
        }
        else
        {
            ctx.Response.Redirect("/"); // Przekierowanie na stronę główną, jeśli nie ma określonego returnUrl
        }
        return Task.CompletedTask;
    };*/
})
.AddIdentityCookies();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
