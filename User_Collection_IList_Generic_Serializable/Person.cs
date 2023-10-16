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
        public int Age { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public Person() { }
        public Person(int age, string name)
        {
            Age = age;
            Name = name;
        }
        public override string ToString()
        {
            return $"Age: {Age}, Name: {Name}";
        }
    }
}
