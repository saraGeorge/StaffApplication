using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationEndpoints
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // create csv file
            string staffFileName = @"C:\stafflist.csv";

            if (!File.Exists(staffFileName))
            {
                string staffFileHeader = "Id , FirstName , LastName , Email ID , role" + Environment.NewLine;
                string data = "1 , sara , tom , saratom@email.com , teaching" + Environment.NewLine;

                File.WriteAllText(staffFileName, staffFileHeader);
                File.AppendAllText(staffFileName, data);
            }
            CreateHostBuilder(args).Build().Run();

        
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
