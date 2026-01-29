using AutomacaoSimples;
using AutomacaoSimples.Service;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddSingleton<IFileSystemService, FileSystemService>();

var host = builder.Build();
host.Run();
