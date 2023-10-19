using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace User_Collection_IList_Generic_Serializable
{
    [Serializable]
    [XmlInclude(typeof(Student))]
    public abstract class Person
    {
        private int age;
        private string name;
        public int Age { get { return age; } set { age = value; } }
        public string Name { get { return name; } set { name = value; } }
        public Person() {
            age = 0;
            name = string.Empty;
        }
        public Person(int age, string name)
        {
            this.age = age;
            this.name = name;
        }
        public override string ToString()
        {
            return $"Age: {Age}, Name: {Name}";
        }
    }
}
