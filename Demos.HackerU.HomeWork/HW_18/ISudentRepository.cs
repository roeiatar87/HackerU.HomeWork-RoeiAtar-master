namespace Demos.HackerU.HomeWork.HW_18
{
    public interface ISudentRepository
    {
        bool AddNewStudent(StudentModel student);
        bool DeleteStudentByID(int id);
        List<StudentModel> GetAllStudents();
        List<StudentModel> GetAllStudentsByCourse(string courseName);
        StudentModel GetStudentByID(int id);
        void SaveLastStudentToFile(StudentModel studentModel);
        void UpdateStudentByID(int id, StudentModel studentModel);
    }
}