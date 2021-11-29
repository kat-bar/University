using Microsoft.EntityFrameworkCore;
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
        private readonly DatabaseContext db;
        public GroupService(DatabaseContext context)
        {
            db = context;
            db.SaveChanges();
        }
        public IEnumerable<Group> GetSavedGroup()
        {
            return db.Groups.ToList();
        }
        public Group SaveGroup(Group oGroup)
        {
            db.Groups.Add(oGroup);
            db.SaveChanges();
            return oGroup;
        }

        public Group UpdateGroup(Group oGroup)
        {
            db.Groups.Update(oGroup);
            db.SaveChanges();
            return oGroup;
        }
    }
}
