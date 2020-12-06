using System;
using System.Collections.Generic;
using Commander.Logic.Models;
using Commander.Logic.Core.Abstractions;
using System.Linq;

namespace Commander.Infra.Data
{
    public class CommandsRepository : ICommandsRepository
    {
        private readonly ApplicationContext _dbContext;
        public CommandsRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
       public  IEnumerable<Command> GetAppCommands()
       {
           return _dbContext.Commands.ToList();
       }

       public Command GetCommandById(int id)
       {
           return _dbContext.Find<Command>(id);
       }
        public void AddCommand(Command command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

           _dbContext.Attach(command);
        }

        public void DeleteCommand(Command command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            _dbContext.Remove(command);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
     
    }
}