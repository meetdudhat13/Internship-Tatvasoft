
using StudentInfo.DataAccess.Models;

namespace StudentInfo.DataAccess.Repositories
{
    public class StudentRepository
    {
        private readonly StudentManagmentDbContext _userDbContext;

        public StudentRepository(StudentManagmentDbContext UserDbContext)
        {
            _userDbContext = UserDbContext;
        }

        // get all user from db 
        public List<Student> GetStudent()
        {
            return _userDbContext.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            Student User = _userDbContext.Students.FirstOrDefault(User => User.Id == id);
            if (User == null)
            {
                return null;
            }
            return User;
        }

        public void AddStudent(Student User)
        {
            _userDbContext.Students.Add(User);
            _userDbContext.SaveChanges();
        }

        public int UpdateStudent(Student User)
        {
            Student UserToBeUpdated = GetStudentById(User.Id);
            if (UserToBeUpdated == null)
            {
                return -1;
            }
            else
            {
                UserToBeUpdated.StudentName = User.StudentName;
                UserToBeUpdated.Enrollment = User.Enrollment;
                UserToBeUpdated.Email = User.Email;
                _userDbContext.SaveChanges();
                return 1;
            }
        }

        public int DeleteStudent(int id)
        {
            Student UserToBeRemoved = GetStudentById(id);
            if (UserToBeRemoved == null)
            {
                return -1;
            }
            else
            {
                _userDbContext.Students.Remove(UserToBeRemoved);
                _userDbContext.SaveChanges();
                return 1;
            }
        }

        public List<Student> GetFilteredStudent(string name)
        {
            List<Student> User = _userDbContext.Students.Where(User => User.StudentName.Equals(name)).ToList();
            return User;
        }

        public Student? Login(string username, string password)
        {
            return _userDbContext.Students
                .FirstOrDefault(u => u.StudentName == username && u.Enrollment == password);
        }

    }
}
