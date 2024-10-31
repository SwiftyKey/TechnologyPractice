using TechnologyPractice.Middleware;
using TechnologyPractice.Services;
using TechnologyPractice.Services.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.Configure<AppConfig>(builder.Configuration);
builder.Services.Configure<Settings>(builder.Configuration.GetSection("Settings"));

builder.Services.AddSingleton<RandomNumberClient>();
builder.Services.AddSingleton<StringHandler>();
builder.Services.AddSingleton<BlackListService>();
builder.Services.AddSingleton<RequestLimitService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<RequestLimitMiddleware>();
app.UseMiddleware<BlackListMiddleware>();

app.Run();
