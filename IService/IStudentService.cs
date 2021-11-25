using System.Collections.Generic;
using University.Models;

namespace University.IService
{
    public interface IStudentService
    {
        Student Save(Student oStudent);
        Student GetSavedStudent();
        Student Update(Student oStudent);
    }
}
