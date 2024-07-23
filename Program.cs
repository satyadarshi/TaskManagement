using TaskManagementBlazor.Data;
using TaskManagementBlazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMudServices();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
//builder.Services.AddHttpClient("APPINSIGHTS_CLIENT", c =>
//{
//    c.BaseAddress = new Uri("https://localhost:7299/api/taskmanager/taskdetail/");
//    c.DefaultRequestHeaders.Add("ApiKey", "6CBxzdYcEg");
//});
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddHttpClient<ITaskService, TaskService>(c => {
    c.BaseAddress = new Uri("https://localhost:7299/api/taskmanager/taskdetail/");
    c.DefaultRequestHeaders.Add("XApiKey", "6CBxzdYcEg");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
