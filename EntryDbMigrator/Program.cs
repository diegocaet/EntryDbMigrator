// See https://aka.ms/new-console-template for more information
using EntryDbMigrator.Tables;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;


    using (var serviceProvider = CreateServices())
    using (var scope = serviceProvider.CreateScope())
    {
        // Put the database update into a scope to ensure
        // that all resources will be disposed.
        UpdateDatabase(scope.ServiceProvider);
    }


static ServiceProvider CreateServices()
{
    string connectionString = "Server=127.0.0.1;Database=CONTA;User Id=sa;Password=yourStrong(!)Password;";
    return new ServiceCollection()
        // Add common FluentMigrator services
        .AddFluentMigratorCore()
        .ConfigureRunner(rb => rb
            // Add SQLite support to FluentMigrator
            .AddSqlServer2016()
            // Set the connection string
            .WithGlobalConnectionString(connectionString)
            // Define the assembly containing the migrations
            .ScanIn(typeof(TipoConta).Assembly, typeof(Conta).Assembly).For.Migrations())
        // Enable logging to console in the FluentMigrator way
        .AddLogging(lb => lb.AddFluentMigratorConsole())
        // Build the service provider
        .BuildServiceProvider(false);
}

/// <summary>
/// Update the database
/// </summary>
static void UpdateDatabase(IServiceProvider serviceProvider)
{
    // Instantiate the runner
    var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

    // Execute the migrations
    runner.MigrateUp();
}
