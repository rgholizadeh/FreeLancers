using FreeLancersWebApi.Modells;
using FreeLancersWebApi.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.Configure<FreeLancersDatabaseSettings>(
//    builder.Configuration.GetSection(nameof(FreeLancersDatabaseSettings)));
builder.Services.Configure<FreeLancersDatabaseSettings>(
    builder.Configuration.GetSection("FreeLancersDatabaseSettings"));

//builder.Services.AddSingleton<IFreeLancersDatabaseSettings>(fp => 
//fp.GetRequiredService<IOptions<FreeLancersDatabaseSettings>>().Value);
builder.Services.AddSingleton<FreeLancerService>();

//builder.Services.AddSingleton<IMongoClient>(f =>
//new MongoClient(builder.Configuration.GetValue<string>("FreeLancersDatabaseSettings: ConnectionString")));

//builder.Services.AddScoped<IFreeLancerService, FreeLancerService>();


builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.MapGet("/", () => "FreeLancers API!");

app.Run();

