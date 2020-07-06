using System.Collections.Generic;
using System.Threading.Tasks;
using APPROVAL.Models;

namespace APPROVAL.Data
{
    public interface ICommanderRepo
    {
        bool SaveChanges();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        Command GetCommandBySearch(string searchWord);
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);
    }
}