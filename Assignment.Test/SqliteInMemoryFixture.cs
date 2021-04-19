
using System;
using System.Reflection;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyAssignment.Data;

namespace Assignment.Test
{
    public class SqliteInMemoryFixture: IDisposable
    {
        private IServiceScope _serviceScope;
        private SqliteConnection _connect;

        public virtual IServiceProvider ServiceProvider
        {
            get
            {
                if (_serviceScope == null)
                {
                    _serviceScope = ConfigureServices(new ServiceCollection())
                        .BuildServiceProvider()
                        .CreateScope();
                }

                return _serviceScope.ServiceProvider;
            }
        }

        public virtual ApplicationDbContext Context
            => ServiceProvider.GetRequiredService<ApplicationDbContext>();

        public virtual void CreateDatabase()
        {
            Dispose();
            _connect = new SqliteConnection("Data Source=:memory:");
            _connect.Open();
            Context.Database.EnsureCreated();
        }

        public virtual void Dispose()
        {
            _connect?.Close();
            _connect?.Dispose();
            _serviceScope?.Dispose();
            _serviceScope = null;
        }

        public virtual IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(b =>
                b.UseSqlite(_connect));

            return services;
        }
    }
}
