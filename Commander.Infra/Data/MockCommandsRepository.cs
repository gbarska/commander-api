using System.Collections.Generic;
using Commander.Logic.Models;
using Commander.Logic.Core.Abstractions;

namespace Commander.Infra.Data
{
    public class MockCommandsRepository : ICommandsRepository
    {
        public void AddCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public  IEnumerable<Command> GetAppCommands()
       {
           var commands = new List<Command> 
           {
               new Command {Id =0, HowTo = "Boil an egg", Line ="Boil Water", Platform = "Ketle & Pan" },
               new Command {Id =1, HowTo = "Cook pasta", Line ="Boil Water", Platform = "Macaroni & Pasta" },
               new Command {Id =2, HowTo = "Cut bread", Line ="Get a knife", Platform = "Knife & chopping bread" },
           };
           return commands;
       }

       public Command GetCommandById(int id)
       {
           return new Command {Id =1, HowTo = "Cook pasta", Line ="Boil Water", Platform = "Macaroni & Pasta" };
       }

        public void SaveChanges()
        {
           return;
        }
    }
}