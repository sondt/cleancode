using System.Text.Json.Serialization;
using ConferenceModule.ApiFe.Installers;
using ConferenceModule.ApiFe.Services;

const string corsPolicyOrigins = "OnlineExchangeApiFe";

ThreadPool.GetMinThreads(out var minWorker, out var portThreads);
ThreadPool.SetMaxThreads(minWorker * 200, portThreads);

var builder = WebApplication.CreateBuilder(args);

//Config other setting json files
Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
var path = AppDomain.CurrentDomain.BaseDirectory;
var settingFiles = Directory.GetFiles(path + "Settings", "*.json");
var configuration = new ConfigurationBuilder();
configuration.AddJsonFile("appsettings.json", false, true);
foreach (var setting in settingFiles) configuration.AddJsonFile(setting, true, true);
configuration.Build();


var corsAllowDomain = configuration.Build().GetSection("AllowDomain").Get<string[]>();
// Add services to the container.
builder.Services.RegisterServices(configuration.Build());

//JsonStringEnumConverter() --> config for Enums display as string
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

//config Cors
builder.Services.AddCors(options => {
    options.AddPolicy(corsPolicyOrigins,
        corsPolicyBuilder => corsPolicyBuilder.WithOrigins(corsAllowDomain).AllowAnyHeader().AllowAnyMethod()
            .AllowCredentials().SetIsOriginAllowedToAllowWildcardSubdomains().SetIsOriginAllowed(host => true));
});
builder.Services.InstallServicesInAssembly(configuration.Build());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseCors(corsPolicyOrigins);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//register the applications without system 
app.RegisterApplications();
app.UseAuthorization();

//config cors
app.MapControllers().RequireCors(corsPolicyOrigins);

app.Run();