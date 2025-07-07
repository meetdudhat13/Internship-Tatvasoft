
using Microsoft.AspNetCore.Mvc;
using StudentInfo.DataAccess.Models;
using StudentInfo.Services.Services;

namespace StudentInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService _userService;

        public StudentsController(StudentService studentService)
        {
            _userService = studentService;
        }

        [HttpGet("GetAllUsers")]
        public ActionResult<List<Student>> GetAllUsers()
        {
            List<Student> Users = _userService.GetStudents();
            if (Users == null || Users.Count == 0)
            {
                return NotFound("No Users found");
            }
            else
            {
                return Ok(Users);
            }
        }

        [HttpGet("GetSingleUser")]
        public ActionResult<Student> GetUser(int id)
        {
            Student User = _userService.GetStudentById(id);
            if (User == null)
            {
                return NotFound("User Not found");
            }
            else
            {
                return Ok(User);
            }
        }

        [HttpPost]
        public ActionResult AddUser(Student User)
        {
            _userService.AddStudent(User);
            return Ok("User added successfully");
        }

        [HttpPut]
        public ActionResult UpdateUser(Student UserToBeUpdated)
        {
            int UserUpdateStatus = _userService.UpdateStudent(UserToBeUpdated);
            if (UserUpdateStatus == -1)
            {
                return NotFound("User Not FOund");
            }
            else if (UserUpdateStatus == 1)
            {
                return Ok("User updated successfully");
            }
            else
            {
                return BadRequest("Bad request");
            }
        }

        [HttpDelete]
        public ActionResult DeleteUser(int id)
        {
            int deleteStatus = _userService.DeleteStudent(id);
            if (deleteStatus == -1)
            {
                return NotFound("User Not found");
            }
            else if (deleteStatus == 1)
            {
                return Ok("User Deleted Successfully");
            }
            else
            {
                return BadRequest("Bad request");
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] StudentInfo.Services.DTOs.LoginRequest loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password))
                return BadRequest("Invalid login data.");

            var user = _userService.Login(loginRequest.Username, loginRequest.Password);

            if (user == null)
                return Unauthorized("Invalid username or password.");

            return Ok(new
            {
                user.Id,
                user.StudentName,
                user.Email
            });
        }

        [HttpGet("GetFilteredUsers")]
        public ActionResult GetFilteredUsers(string name)
        {
            List<Student> Users = _userService.GetFilteredStudents(name);
            if (Users == null || Users.Count == 0)
            {
                return NotFound("Users Not Found");
            }
            else
            {
                return Ok(Users);
            }

        }
    }
}
