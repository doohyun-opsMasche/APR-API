using System.Collections.Generic;
using APPROVAL.Models;

namespace APPROVAL.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command cmd);
        bool SaveChanges();
    }
}