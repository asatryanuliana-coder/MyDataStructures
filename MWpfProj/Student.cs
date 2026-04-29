using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp;

public class Student : IComparable<Student>
{
    public Student(int id, string name, Gender gender)
    {
        StudentId = id;
        Name = name;
        Gender = gender;
    }
    public int StudentId { get; set; }
    public string Name { get; set; }


    public Gender Gender { get; set; }


    public int CompareTo(Student? other)
    {
        if (other == null)
        {
            return 1; // This instance is greater than null
        }

        return StudentId.CompareTo(other.StudentId);
    }
}