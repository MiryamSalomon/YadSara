using System.Text.Json.Serialization;
using YadSara.Core.Repositories;
using YadSara.Core.Services;
using YadSara.Data;
using YadSara.Data.Repositories;
using YadSara.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IBorrowRepository, BorrowRepository>();
        builder.Services.AddScoped<IBorrowService, BorrowService>();

        builder.Services.AddScoped<ICityRepository, CityRepository>();
        builder.Services.AddScoped<ICityService, CityService>();

        builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
        builder.Services.AddScoped<IEquipmentService, EquipmentService>();

        builder.Services.AddScoped<ILenderRepository, LenderRepository>();
        builder.Services.AddScoped<ILenderService, LenderService>();

        //builder.Services.AddScoped<ILendingRepository, LendingRepository>();
        builder.Services.AddScoped<ILendingRepository, LendingRepository>();
        builder.Services.AddScoped<ILendingService, LendingService>();

        builder.Services.AddSingleton<DataContext>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
   

