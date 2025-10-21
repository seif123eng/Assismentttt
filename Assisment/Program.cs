using Assisment.AppDbContextsss;
using Assisment.SpecificRepos.CoachRepos;
using Assisment.SpecificRepos.CompetetionRepos;
using Assisment.SpecificRepos.PlayerRepos;
using Assisment.SpecificRepos.TeamRepos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer
( builder.Configuration.GetConnectionString("Con1")));

builder.Services.AddScoped<ICoachRepo, CoachRepo>();
builder.Services.AddScoped<ITeamRepo, TeamRepo>();
builder.Services.AddScoped<IPlayerRepo, PlayerRepo>();
builder.Services.AddScoped<ICompetetionRepos, CompetetionRepo>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
