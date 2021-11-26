using System.Collections.Generic;
using System.Threading.Tasks;
using University.Models;

namespace University.IService
{
    public interface IGroupService
    {
        Group SaveGroup(Group oGroup);
        IEnumerable<Group> GetSavedGroup();
        Group UpdateGroup(Group oGroup);
    }
}
