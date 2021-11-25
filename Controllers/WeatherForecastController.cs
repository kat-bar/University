using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using University.IService;
using University.Models;

namespace University.Controllers
{
    
    public class WeatherForecastController : Controller
    {
        IStudentService _studentService = null;
        IGroupService _groupService = null;
        public WeatherForecastController(IStudentService studentService, IGroupService groupService)
        {
            _studentService = studentService; 
             _groupService = groupService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string SaveFile([FromBody]  FileUpload fileObj)
        {
            Student oStudent = JsonConvert.DeserializeObject<Student>(fileObj.Student);

            if (fileObj.file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    fileObj.file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    oStudent.Photo = fileBytes;

                    oStudent = _studentService.Save(oStudent);
                    if (oStudent.StudentId > 0)
                    {
                        return "Saved";
                    }
                }
            }
            return "Failed";
        }

        [HttpGet]
        public Student GetSavedStudent()
        {
            var student = _studentService.GetSavedStudent();
            student.Photo = this.GetImage(Convert.ToBase64String(student.Photo));
            return student;
        }

        public byte[] GetImage(string sBase64String)
        {
            byte[] bytes = null;
            if (!string.IsNullOrEmpty(sBase64String))
            {
                bytes = Convert.FromBase64String(sBase64String);
            }
            return bytes;
        }
        [HttpPost]
        public IActionResult SaveGroup([FromBody]  Group oGroup)
        {
            oGroup = _groupService.SaveGroup(oGroup);
                
            if (oGroup.GroupId > 0)
            {
                return Ok(oGroup);
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public IEnumerable<Group> GetSavedGroup()
        {
            var group = _groupService.GetSavedGroup();
            return group;
        }

        [HttpPut]
        public string Update([FromBody] Group oGroup)
        {
            oGroup = _groupService.Update(oGroup);
            return "Saved";
        }
        [HttpPut]
        public string Update([FromBody] Student oStudent)
        {
            oStudent = _studentService.Update(oStudent);
            return "Saved";
        }
    }
}
