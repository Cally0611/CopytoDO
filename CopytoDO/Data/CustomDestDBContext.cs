using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopytoDO.Data
{
    internal class CustomDestDBContext : OeedashboardContext
    {
        private readonly IConfiguration _configuration;

        public IConfiguration Configuration
        {
            get
            {
                return _configuration;
            }
        }

        public CustomDestDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

         

            var connectionString = Configuration.GetConnectionString("DestExpressDB");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
