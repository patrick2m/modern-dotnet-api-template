var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
{
  cfg.RegisterServicesFromAssemblyContaining<Program>();
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
  options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Host.UseSerilog((ctx, lc) =>
{
  lc.WriteTo.Console()
    .ReadFrom.Configuration(ctx.Configuration);
});

builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapHealthChecks("/health");

app.UseSwagger();
app.UseSwaggerUI();

app.MapCreateOrderEndpoint();

app.Run();