using System;
using Commander.Infra;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    class Program
    {
        static void Main(string[] args)
        {
            //only for debug 
            // Console.WriteLine(AppConfig.Config.GetConnectionString("DefaultConnection"));
        }
    }
}
