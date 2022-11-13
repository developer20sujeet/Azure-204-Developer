using sqlapp.Services;

var builder = WebApplication.CreateBuilder(args);


// Start : Azure App Configuration
var connectionString = "Endpoint=https://delete-appconfig.azconfig.io;Id=quFC-l0-s0:hUAYt1eeVyUAVAF0py0f;Secret=kV4G9T3unB4nkiyVjyD64l5zhrM9+nKFCIikxwTe1nw=";

    builder.Host.ConfigureAppConfiguration(builder =>
    {
        //Connect to your App Config Store using the connection string
        builder.AddAzureAppConfiguration(connectionString);
    });

    builder.Services.AddTransient<IProductService, ProductService>();
// Start : Azure App Configuration


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseAuthorization();

app.MapControllers();

app.Run();
