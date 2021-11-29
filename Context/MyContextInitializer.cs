using System.Data.Entity;
using University.Models;
using Microsoft.EntityFrameworkCore;

namespace University.Context
{
    public static class MyContextInitializer
    {
      public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().HasData(
                new Group
                {
                    GroupId = 2,
                    GroupName = "18ИС",
                    Yers = 2018,
                    Speciality = "Сети и системы",
                    TeacherId= 1,
                    CursId = 1,
                });
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 2,
                    Name = "Иванов Иван Иванович",
                    GroupId = 2,
                    Phone = 77515236,
                });
            modelBuilder.Entity<Teacher>().HasData(
               new Teacher
               {
                   TeacherId = 1,
                   TeacherName = "Иванова Иванка Сергеевна",
               });
            modelBuilder.Entity<Curs>().HasData(
               new Curs
               {
                   CursId = 1,
                   NameCurs = "1",
               });
            modelBuilder.Entity<Curs>().HasData(
              new Curs
              {
                  CursId = 2,
                  NameCurs = "2",
              });
            modelBuilder.Entity<Curs>().HasData(
              new Curs
              {
                  CursId = 3,
                  NameCurs = "3",
              });
            modelBuilder.Entity<Curs>().HasData(
              new Curs
              {
                  CursId = 4,
                  NameCurs = "4",
              });
        }
    }
}
