using System.Collections.Generic;
using APPROVAL.Moedls;

namespace APPROVAL.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command { id = 0, howTo = "Boil an egg", line = "Boil water", platForm = "Kettle & Pan" },
                new Command { id = 1, howTo = "Boil an egg1", line = "Boil water", platForm = "Kettle & Pan" },
                new Command { id = 2, howTo = "Boil an egg2", line = "Boil water", platForm = "Kettle & Pan" },
                new Command { id = 3, howTo = "Boil an egg3", line = "Boil water", platForm = "Kettle & Pan" }
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { id = 2, howTo = "Boil an egg??", line = "Boil water", platForm = "Kettle & Pan" };
        }
    }
}