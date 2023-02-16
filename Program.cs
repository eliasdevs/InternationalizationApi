var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
//Localization
builder.Services.AddLocalization(options=>options.ResourcesPath="Resources");
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//2. SUPPORT CULTURES
var supportedCulteres = new[] { "en-US", "es-ES","fr-FR" };
var localizationOptions= new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCulteres[0])
    .AddSupportedCultures(supportedCulteres)
    .AddSupportedUICultures(supportedCulteres);
//3. Add localization
app.UseRequestLocalization(localizationOptions);
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
