using ProxyServer.Services;

var builder = WebApplication.CreateBuilder(args);

Uri baseURI = new("https://beta.check-mot.service.gov.uk/");

// Add services to the container.
builder.Services.AddHttpClient<IVehicleLookupService, VehicleLookupService>(client => client.BaseAddress = baseURI);

//Required so that requests from the front end blazor app, aren't refused due to CORS.
builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();
}

app.UseBlazorFrameworkFiles();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("Open");

app.MapControllers();

//This is to ensure that the Blazor app can run from same server as the api.
//However non specific "Get" request will always route here,
//so decided to make request between the two a POST request as it is also better for security.
app.MapFallbackToFile("index.html"); 

app.Run();
