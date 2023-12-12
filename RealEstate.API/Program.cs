using RealEstate.Application;
using Infrastructure;
using RealEstate.API.Servicies;
using RealEstate.Application.Contracts.Interfaces;
using RealEstate.Identity;
using Microsoft.OpenApi.Models;
using RealEstate.API.Utility;
using RealEstate.Identity.Models;
using RealEstate.Identity.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


///////////////
builder.Services.AddHttpContextAccessor();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
// Add services to the container.
builder.Services.AddInfrastrutureIdentityToDI(builder.Configuration);
///////////////

//Add Config for Required Email
builder.Services.Configure<IdentityOptions>(
	opts => opts.SignIn.RequireConfirmedEmail = true
	);

builder.Services.Configure<DataProtectionTokenProviderOptions> (
	opts =>
	    opts.TokenLifespan = TimeSpan.FromHours(10));

// Add services to the container.
builder.Services.AddInfrastructureToDI(builder.Configuration);
builder.Services.AddApplicationServices();

// Add email Configs
var emailConfig = builder.Configuration
    .GetSection("EmailConfiguration")
    .Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
		Name = "Authorization",
		In = ParameterLocation.Header,
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer"
	});

	c.AddSecurityRequirement(new OpenApiSecurityRequirement()
				  {
					{
					  new OpenApiSecurityScheme
					  {
						Reference = new OpenApiReference
						  {
							Type = ReferenceType.SecurityScheme,
							Id = "Bearer"
						  },
						  Scheme = "oauth2",
						  Name = "Bearer",
						  In = ParameterLocation.Header,

						},
						new List<string>()
					  }
					});

	c.SwaggerDoc("v1", new OpenApiInfo
	{
		Version = "v1",
		Title = "Real Estate Management API",

	});

	c.OperationFilter<FileResultContentTypeOperationFilter>();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("Open");


app.UseAuthorization();

app.MapControllers();

app.Run();
