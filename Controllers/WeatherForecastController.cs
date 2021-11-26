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
        public IActionResult SaveFile([FromBody] Student oStudent)
        {
            oStudent = _studentService.Save(oStudent);

            if (oStudent.GroupId > 0)
            {
                return Ok(oStudent);
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public IEnumerable<Student> GetSavedStudent()
        {
            var students = _studentService.GetSavedStudent();
            return students;
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
        public IActionResult UpdateGroup([FromBody] Group oGroup)
        {
            oGroup = _groupService.UpdateGroup(oGroup);

            if (oGroup.GroupId > 0)
            {
                return Ok(oGroup);
            }
            return BadRequest(ModelState);
        }
    
        [HttpPut]
        public IActionResult UpdateStudent([FromBody] Student oStudent)
        {
            oStudent = _studentService.Update(oStudent);

            if (oStudent.StudentId > 0)
            {
                return Ok(oStudent);
            }
            return BadRequest(ModelState);
        }
    }
 }

