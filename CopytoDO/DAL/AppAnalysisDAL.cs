using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopytoDO.DAL
{
    internal class AppAnalysisDAL
    {
        private readonly IConfiguration _configuration = null!;
        private readonly string _connectionString = null!;


        //in the constructor
        public AppAnalysisDAL(IConfiguration configuration)
        {
            this._configuration = configuration;
            this._connectionString = this._configuration.GetConnectionString("LocalExpressDB");
        }
    }
}
