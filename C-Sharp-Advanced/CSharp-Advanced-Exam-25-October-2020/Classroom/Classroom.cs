using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        public int Capacity { get; set; }
        public int Count => students.Count;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }

        public string RegisterStudent(Student student)
        {
            if (students.Count < Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            
            return $"No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            var student =
                students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

            if (student is null)
            {
                return "Student not found";
            }
            
            students.Remove(student);
            return $"Dismissed student {firstName} {lastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Subject: {subject}").AppendLine();
            sb.Append("Students:").AppendLine();

            if (!students.Exists(s => s.Subject == subject))
            {
                return "No students enrolled for the subject";
            }
            
            foreach (var student in students.Where(s => s.Subject == subject) )
            {
                sb.Append($"{student.FirstName} {student.LastName}").AppendLine();
            }

            return sb.ToString().TrimEnd();
        }

        public int GetStudentsCount()
        {
            return Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
        }
    }
}