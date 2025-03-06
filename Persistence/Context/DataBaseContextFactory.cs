using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Persistence.Context
{
    public class DataBaseContextFactory : IDbContextFactory
    {
        private readonly IConfiguration _configuration;

        public DataBaseContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DataBaseContext CreateDbContext()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new DataBaseContext(optionsBuilder.Options);
        }
    }
}
