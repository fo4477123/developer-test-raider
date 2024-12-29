using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IIconService, IconService>();

var app = builder.Build();
app.UseCors("AllowAll");
app.MapGet("/api/users", async (IUserService userService) =>
{
    return Results.Ok(await userService.GetUsersAsync());
});

app.MapGet("/api/icons/{iconName}", async (string iconName, IIconService iconService) =>
{
    var iconData = await iconService.GetIconBytesAsync(iconName);
    if (iconData == null)
    {
        return Results.NotFound();
    }
    Console.WriteLine($"Returning icon {iconName} with content-type: image/png");
    
    return Results.File(iconData,contentType: "image/png");
});

app.Run();
