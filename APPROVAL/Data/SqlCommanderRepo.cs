using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APPROVAL.Models;

namespace APPROVAL.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly DataContext _context;

        public SqlCommanderRepo(DataContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Add(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(p => p.id == id);
        }

        public Command GetCommandBySearch(string searchWord)
        {
            return _context.Commands.FirstOrDefault(p => p.howTo == searchWord);
        }

        public void UpdateCommand(Command cmd)
        {
            // Nothing
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Update(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Remove(cmd);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}