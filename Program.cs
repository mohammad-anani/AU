using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()        // Allow any origin
               .AllowAnyMethod()        // Allow any HTTP method (GET, POST, etc.)
               .AllowAnyHeader());      // Allow any headers
});


//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.LoginPath = "/api/AU/GetStudentByUsernameAndPassword";
//        options.LogoutPath = "/api/AU/logout";
//        options.ExpireTimeSpan = TimeSpan.FromDays(30);
//        options.SlidingExpiration = true;
//        options.Cookie.SameSite = SameSiteMode.None;
//        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; 
//        options.Cookie.HttpOnly = true;
//    });

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add controllers for Web API
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // Enable Swagger in development environment
    app.UseSwagger();
    app.UseSwaggerUI();

}

// Enable CORS globally
app.UseCors("AllowAll");

// Use Routing
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
