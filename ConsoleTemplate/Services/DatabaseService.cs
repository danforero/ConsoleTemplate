using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTemplate.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly ILogger<DatabaseService> _log;
        private readonly IConfiguration _config;
        public DatabaseService(ILogger<DatabaseService> log, IConfiguration config)
        {
            _log = log;
            _config = config;
        }

        public void Connect()
        {
            var connectionString = _config.GetValue<string>("ConnectionStrings:DefaultConnection");
            _log.LogInformation("Connection String {cs}", connectionString);
        }
    }
}
