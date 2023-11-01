using Microsoft.EntityFrameworkCore;
using MovieRental.Web.Data;
using MovieRental.Web.Interface.DomainService;
using MovieRental.Web.Interface.Repository;
using MovieRental.Web.Producer;
using MovieRental.Web.Service;

var policyName = "AllowOrigin";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
        builder =>
        {
            builder
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

//DBContext
builder.Services.AddDbContext<MovieContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext"));
});

//Build services
builder.Services.AddScoped(typeof(IRentalService), typeof(RentalService));
builder.Services.AddScoped(typeof(IMovieService), typeof(MovieService));

//Build Kafka producers
builder.Services.AddSingleton<KafkaProducer>();

//Build repositories
builder.Services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(policyName);
app.UseAuthorization();

app.MapControllers();

app.Run();