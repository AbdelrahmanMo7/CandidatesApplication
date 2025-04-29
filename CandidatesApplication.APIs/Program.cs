using CandidatesApplication.BL.Services.IServices;
using CandidatesApplication.BL.Services.Services;
using CandidatesApplication.DAL.Data;
using CandidatesApplication.DAL.Repos;
using CandidatesApplication.DAL.Repos.IRepos;
using CandidatesApplication.DAL.Repos.Repos;
using CandidatesApplication.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);





// our registrations

builder.Services.AddDbContext<CandidateAppContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("default")));

builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
builder.Services.AddScoped<ICandidateRepo, CandidateRepo>();
builder.Services.AddScoped<ICandidateHasSkillRepo, CandidateHasSkillRepo>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddScoped<ICandidatesServices, CandidatesServices>();
builder.Services.AddScoped<ISkillServices, SkillServices>();
builder.Services.AddScoped<ICandidatesHasSkillsServices, CandidatesHasSkillsServices>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy => policy.WithOrigins("http://localhost:8100")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

// Add services to the container.


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
}

app.UseHttpsRedirection();
app.UseCors("AllowAngularApp");
//app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
