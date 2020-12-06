using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Commander.Infra
{

    public static class AppConfig
    {
        public static IConfigurationRoot Config => GetlazyConfig().Value;
        private static Lazy<IConfigurationRoot> GetlazyConfig()
        {
            //project's folder /bin/debug/framework/*.dll
            var assemblyPath = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().Location).LocalPath);
            
            //../../../../Workspace's path
            var workspacePath = System.IO.Directory.GetParent(assemblyPath).Parent.Parent.Parent.FullName;
        
            var mainProjectName = "Commander.Api";
            
            return new Lazy<IConfigurationRoot>(() =>
            new ConfigurationBuilder()
                .SetBasePath(Path.Combine(workspacePath, mainProjectName))
                // .AddJsonFile("appsettings.json", true)
                // .AddJsonFile("config.json")
                .AddJsonFile("appsettings.json")
                .Build());
        }  


    }
}