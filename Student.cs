using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace struct_lab_student
{
    struct Student
    {
        public string surName;
        public string firstName;
        public string patronymic;
        public char sex;
        public string dateOfBirth;
        public char mathematicsMark;
        public char physicsMark;
        public char informaticsMark;
        public int scholarship;

        public Student(string lineWithAllData)
        {
            lineWithAllData = lineWithAllData.Replace("-", "2").Replace("\r", "");
            string[] a = lineWithAllData.Split(' ');
            this.firstName = a[0];
            this.surName = a[1];
            this.patronymic = a[2];
            this.sex = Convert.ToChar(a[3]);
            this.dateOfBirth = a[4];
            this.mathematicsMark = Convert.ToChar(a[5]);
            this.physicsMark = Convert.ToChar(a[6]);
            this.informaticsMark = Convert.ToChar(a[7]);
            this.scholarship = Convert.ToInt32(a[8]);
        }
    }
}
