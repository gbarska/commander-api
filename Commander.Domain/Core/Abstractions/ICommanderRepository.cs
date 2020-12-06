using Commander.Logic.Models;
using System.Collections.Generic;

namespace Commander.Logic.Core.Abstractions
{
    public interface ICommandsRepository
    {
        IEnumerable<Command> GetAppCommands();
        Command GetCommandById(int id);
        void AddCommand(Command command);
        // void UpdateCommand(Command command);
        void DeleteCommand(Command command);
        void SaveChanges();
    }
}