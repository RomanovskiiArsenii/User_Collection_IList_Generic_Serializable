using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Collection_IList_Generic_Serializable
{
    [Serializable]
    public class Student : Person
    {
        public int classroom = 0;
        public int personalId = 0;
        public int Classroom { get {return classroom;} set { classroom = value;} }
        public int PersonalId { get { return personalId; } set { personalId = value;} }
        public Student() { }
        public Student(int age, string name, int classroom, int personalId) : base(age, name)
        {
            Classroom = classroom;
            PersonalId = personalId;
        }
        public override string ToString()
        {
            return base.ToString() + $", Classroom: {Classroom}, ID: {PersonalId}";
        }
    }
}
