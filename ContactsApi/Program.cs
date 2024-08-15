var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

try
{
    builder.Services.AddWebApiServices();
    builder.Services.AddApplicationServices();
    builder.Services.AddInfrastructureServices();
    builder.Services.AddDbServices(configuration);
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(
            name: "DevelopmentHosts",
            p => p.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed(hostName => true)
        );

        options.AddPolicy(
            name: "ProductionHosts",
            p => p.WithOrigins(configuration["CorsOrigin"] ?? "").AllowAnyHeader().AllowAnyMethod().AllowCredentials()
        );
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseHttpsRedirection();

    // Cors

    var canAllowAnyOrigin = !builder.Environment.IsProduction();
    if (canAllowAnyOrigin)
    {
        app.UseCors("DevelopmentHosts");
    }
    else
    {
        app.UseCors("ProductionHosts");
    }

    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{
    throw ex;
}



