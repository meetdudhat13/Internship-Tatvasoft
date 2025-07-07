
using StudentInfo.DataAccess.Models;
using StudentInfo.DataAccess.Repositories;

namespace StudentInfo.Services.Services
{
    public class StudentService
    {
        private readonly StudentRepository _usersRepository;

        public StudentService(StudentRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public List<Student> GetStudents()
        {
            try
            {
                return _usersRepository.GetStudent();
            }
            catch (Exception ex)
            {
                // Log the exception here if needed
                throw new ApplicationException("Error retrieving users.", ex);
            }
        }

        public Student GetStudentById(int id)
        {
            try
            {
                return _usersRepository.GetStudentById(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error retrieving user with ID {id}.", ex);
            }
        }

        public void AddStudent(Student user)
        {
            try
            {
                _usersRepository.AddStudent(user);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error adding new user.", ex);
            }
        }

        public int UpdateStudent(Student user)
        {
            try
            {
                // logic 
                return _usersRepository.UpdateStudent(user);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error updating user with ID {user?.Id}.", ex);
            }
        }

        public int DeleteStudent(int id)
        {
            try
            {
                return _usersRepository.DeleteStudent(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error deleting user with ID {id}.", ex);
            }
        }

        public List<Student> GetFilteredStudents(string name)
        {
            try
            {
                return _usersRepository.GetFilteredStudent(name);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error filtering users by name: {name}.", ex);
            }
        }

        public Student? Login(string username, string password)
        {
            try
            {
                return _usersRepository.Login(username, password);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Login failed.", ex);
            }
        }

    }

}
