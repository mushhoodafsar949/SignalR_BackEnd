using CRUDinCore.Data;
using CRUDinCore.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
        {
            builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin().AllowCredentials().WithOrigins("http://localhost:4200");
        }));
        builder.Services.AddSignalR();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        //builder.Services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbString")));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
app.UseRouting();
app.UseAuthorization();
app.UseCors("CorsPolicy");

app.UseEndpoints(routes =>
{
    routes.MapHub<NotifyHub>("/notify");
});

app.UseHttpsRedirection();
        
       

        app.MapControllers();
       

        app.Run();