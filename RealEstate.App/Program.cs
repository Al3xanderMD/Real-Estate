using Blazored.LocalStorage;
using Blazored.SessionStorage;
using FluentValidation;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using Microsoft.Extensions.DependencyInjection;

using MudBlazor;
using MudBlazor.Services;
using RealEstate.App;
using RealEstate.App.Auth;
using RealEstate.App.Contracts;
using RealEstate.App.Models;
using RealEstate.App.Services;
using RealEstate.App.Validators;
using System.Text.Json;
using System.Text.Json.Serialization;
using RealEstate.App.Operations.Update;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddAuthorizationCore();

builder.Services.AddBlazoredLocalStorage(config =>
{
    config.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    config.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    config.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
    config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    config.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
    config.JsonSerializerOptions.WriteIndented = false;
});

builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<CustomStateProvider>();
builder.Services.AddScoped<UpdateService>();
builder.Services.AddScoped<FetchService>();
builder.Services.AddScoped<CreateService>();
builder.Services.AddScoped<PostBuilderService>();
builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomStateProvider>());
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IValidator<LoginViewModel>, LoginValidator>();
builder.Services.AddScoped<IValidator<ForgotPasswordViewModel>, ForgotPasswordValidator>();
builder.Services.AddScoped<IValidator<ResetPasswordViewModel>, ResetPasswordValidator>();
builder.Services.AddScoped<IValidator<RegisterViewModel>, RegisterViewModelValidator>();

builder.Services.AddMudServices();

builder.Services.AddMudServices(config => //snackbar pop-ups config
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;

    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 10000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

builder.Services.AddSingleton<ISnackbar, SnackbarService>();


builder.Services.AddHttpClient<IAuthentificationService, AuthenticationService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7190/"); // 7165
});

builder.Services.AddHttpClient<IFetchService, FetchService>(client =>
{
	client.BaseAddress = new Uri("https://localhost:7190/"); // 7165
});

builder.Services.AddHttpClient<IUpdateService, UpdateService>(client =>
{
	client.BaseAddress = new Uri("https://localhost:7190/"); // 7165
});

builder.Services.AddHttpClient<IPostBuilderService, PostBuilderService>(client =>
{
	client.BaseAddress = new Uri("https://localhost:7190/"); // 7165
});

await builder.Build().RunAsync();
