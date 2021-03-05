using Infosys.KMaxMovies.DataAccessLayer.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;

namespace Infosys.KMaxMovies.DataAccessLayer
{
    public class KMaxMoviesRepository
    {
        private KMaxMoviesDBContext context;

        public KMaxMoviesDBContext Context { get { return context; } }

        public KMaxMoviesRepository(KMaxMoviesDBContext dbContext)
        {
            context = dbContext;
        }

        public KMaxMoviesRepository()
        {
            context = new KMaxMoviesDBContext();
        }

        //Method To get The Connection String from AppSettings.JSON
        public string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("KMaxMoviesDBConnectionString");
            return connectionString;
        }
    }
}
