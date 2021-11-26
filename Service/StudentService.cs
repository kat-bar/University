using System.Collections.Generic;
using System.Linq;
using University.Context;
using University.IService;
using University.Models;

namespace University.Service
{
    public class StudentService : IStudentService
    {
        private readonly DatabaseContext _context;
        public StudentService(DatabaseContext context)
        {
            _context = context;
        }

        public Student Save(Student oStudent)
        {
            _context.Students.Add(oStudent);
            _context.SaveChanges();
            return oStudent;
        }
        public IEnumerable<Student> GetSavedStudent()
        {
            return _context.Students.ToList();
        }
        public Student Update(Student oStudent)
        {
            _context.Students.Update(oStudent);
            _context.SaveChanges();
            return oStudent;
        }
    }
}

