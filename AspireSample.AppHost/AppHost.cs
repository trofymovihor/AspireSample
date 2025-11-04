using Aspire.Hosting.Azure;
var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddAzurePostgresFlexibleServer("sql")
.WithPasswordAuthentication()
.RunAsContainer(container =>
container.WithLifetime(ContainerLifetime.Persistent));

var database = postgres.AddDatabase("EffortlessDb");
var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.AspireSample_ApiService>("apiservice")
    .WithReference(database)
    .WaitFor(database)
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health");

var webui = builder.AddProject<Projects.AspireSample_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

    if (builder.ExecutionContext.IsPublishMode)
{
    var insights = builder.AddAzureApplicationInsights("insights");
    
    apiService.WithReference(insights);
    webui.WithReference(insights);
}

builder.Build().Run();
