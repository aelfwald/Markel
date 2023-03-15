using Markel.Insurance.Api;
using Markel.Insurance.ApiAppConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterServices();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure API Versioning
builder.Services.AddApiVersioning();
builder.Services.AddVersionedApiExplorer(options =>
{
	options.GroupNameFormat = "'v'VV";
	options.SubstitutionFormat = "VV";
	options.SubstituteApiVersionInUrl = true;
});


builder.Services.AddProblemDetails(ConfigureProblemDetailsOptions.ConfigureProblemDetails);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	// Host a swagger page at /swagger/index.html
	app.UseSwagger();
	app.UseSwaggerUI(options => options.SwaggerEndpoint("v1.0/swagger.json", "Market.Insurance v1.0"));

	app.UseDeveloperExceptionPage();
}


// Ensure unhandled exceptions are converted to RFC 7807 responses.
app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
