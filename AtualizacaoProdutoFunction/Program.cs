using AtualizacaoProdutoFunction.Extension;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Hosting;

var builder = FunctionsApplication.CreateBuilder(args);

Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

builder.ConfigureFunctionsWebApplication();

builder.Services.AddServicesServicos();
builder.Services.AddServicesInfraestrutura();

builder.Build().Run();
