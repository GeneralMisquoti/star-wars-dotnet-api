using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PL_452490_P2.Data;
using PL_452490_P2.Models;

namespace PL_452490_P2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // using MyContext context = new MyContext();
            // var movies = context.Movies.ToList();

            // Person person = new Person()
            // {
            //     Name = "Yoda",
            //     Type = Person.ForceUserType.Jedi,
            //     MidichlorianCount = 2000
            // };
            // context.Add(person);
            // context.SaveChanges();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}