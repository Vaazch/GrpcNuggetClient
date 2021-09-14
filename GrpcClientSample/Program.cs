using GrpcClientNugget;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGreeterClientServices(builder.Configuration); // Needed to inject Nuget Dependencies and pass the Configuration object
builder.Services.AddControllers(); 
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "GrpcGreeter", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GrpcClientSample v1"));
}

app.MapControllers();

app.Run();
