using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Context;
using University.IService;
using University.Models;

namespace University.Service
{
    public class GroupService : IGroupService
    {
        private readonly DatabaseContext _context;
        public GroupService(DatabaseContext context)
        {
            _context = context;
        }
        public IEnumerable<Group> GetSavedGroup()
        {
            return _context.Groups.ToList();
        }
        public Group SaveGroup(Group oGroup)
        {
            _context.Groups.Add(oGroup);
            _context.SaveChanges();
            return oGroup;
        }

        public Group Update(Group oGroup)
        {
            _context.Groups.Update(oGroup);
            _context.SaveChanges();
            return oGroup;
        }
    }
}
