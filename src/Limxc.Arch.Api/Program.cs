using FastEndpoints;
using FastEndpoints.Swagger;

var bld = WebApplication.CreateBuilder();
bld.Services.AddFastEndpoints();
bld.Services.AddSwaggerDocument();

var app = bld.Build();
app.UseFastEndpoints();
app.UseSwaggerGen();
app.Run();