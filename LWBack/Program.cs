using LWBack.Model;
using LWBack.HashManager;
using LWBack.Data;
using LWBack.Services;
using Security_jwt;
using System;
using dotenv.net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

DotEnv.AutoConfig();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<LinkWaveContext>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IForumRepository, ForumRepository>();
builder.Services.AddTransient<IPostsRepository, PostsRepository>();
builder.Services.AddTransient<IPositionRepository, PositionRepository>();
builder.Services.AddTransient<IPosPermRepository, PosPermRepository>();
builder.Services.AddTransient<IForumUserRepository, ForumUserRepository>();
builder.Services.AddTransient<IRatingRepository, RatingRepository>();

builder.Services.AddTransient<IJwtService>(p =>
    new JwTService(new PasswordProvider(Environment.GetEnvironmentVariable("PRIVATE_KEY")))
);

var env = builder.Environment;

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MainPolicy",
        policy =>
        {
            policy
                .AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors(); // Usando Cors

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
