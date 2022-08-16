using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data.Tests;

public abstract class DatabaseTestBase
{
    private SqliteConnection SqliteConnection { get; set; } = null!;
    protected DbContextOptions<AppDbContext> Options { get; private set; } = null!;

    private static ILoggerFactory GetLoggerFactory()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddLogging(builder =>
        {
            builder.AddConsole();
        });
        return serviceCollection.BuildServiceProvider().
            GetService<ILoggerFactory>()!;
    }

    [TestInitialize]
    public void InitializeDb()
    {
        SqliteConnection = new SqliteConnection("DataSource=:memory:");
        SqliteConnection.Open();

        Options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(SqliteConnection)
            .UseLoggerFactory(GetLoggerFactory())
            .EnableSensitiveDataLogging()
            .Options;
        
        using var db = new AppDbContext(Options);
        db.Database.EnsureCreated();
        DatabaseSeed.Seed(db);
    }

    [TestCleanup]
    public void CloseDbConnection()
    {
        SqliteConnection.Close();
    }
}

