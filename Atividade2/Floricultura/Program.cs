using Floricultura.Data;
using Floricultura.Models;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<FloriculturaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<FloriculturaContext>();

    if (!context.Plants.Any())
    {
        context.Plants.AddRange(
            new Plant { Name = "Orquídea Phalaenopsis", SensorValue = 25.5f, SensorEvent = 20.0f },
            new Plant { Name = "Rosa Vermelha", SensorValue = 22.4f, SensorEvent = 18.5f },
            new Plant { Name = "Lírio Branco", SensorValue = 21.3f, SensorEvent = 19.0f }
        );

        context.SaveChanges();
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Plants}/{action=Index}/{id?}"
);

app.Run();
