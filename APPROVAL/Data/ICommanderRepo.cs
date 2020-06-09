using System.Collections.Generic;
using APPROVAL.Moedls;

namespace APPROVAL.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
    }
}