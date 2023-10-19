using System.IO.Compression;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace User_Collection_IList_Generic_Serializable
{
    public class Program
    {
        static public void Main()
        {
            #region Class Tests
            //test of constructors
            Student student1 = new Student(18, "John", 1, 101);
            Student student2 = new Student(19, "Mark", 2, 102);
            Student student3 = new Student(20, "Kent", 3, 103);
            Student student4 = new Student(21, "Lara", 4, 104);

            List<Person> studentList = new List<Person>() { student1, student2, student3 };

            StudentList students1 = new StudentList();
            StudentList students2 = new StudentList(studentList);
            StudentList students3 = new StudentList() { student1, student2, student3 };

            Person per = student3;
            Console.WriteLine(per.ToString());

            //test of ToString()
            Console.WriteLine("\ttest of ToString()");
            Console.WriteLine(students1.ToString());
            Console.WriteLine(students2.ToString());
            Console.WriteLine(students3.ToString());

            //test of indexer (count = 0)
            Console.WriteLine("\ttest of indexer (count = 0)");
            students1[0] = student2;
            Student? IndexExceptionStudent = students1[0] as Student;
            Console.WriteLine(IndexExceptionStudent);

            //test of indexer (count > 0)
            Console.WriteLine("\ttest of indexer (count > 0)");
            students2[0] = student2;
            Student? IndexStudent = students2[1] as Student;
            Console.WriteLine(IndexStudent);
            Console.WriteLine();

            //test of Add()
            Console.WriteLine("\ttest of Add()");
            students3.Add(student4);
            Console.WriteLine(students3.ToString());

            //test of Count prop
            Console.WriteLine("\ttest of Count prop");
            Console.WriteLine($"Count of students in list#{students1.CurrentList}: {students1.Count}");
            Console.WriteLine($"Count of students in list#{students2.CurrentList}: {students2.Count}");
            Console.WriteLine($"Count of students in list#{students3.CurrentList}: {students3.Count}");
            Console.WriteLine();

            //test of ReadOnly prop
            Console.WriteLine("\ttest of ReadOnly prop");
            Console.WriteLine($"List#{students1.CurrentList} is read only: {students1.IsReadOnly}");
            Console.WriteLine($"List#{students2.CurrentList} is read only: {students2.IsReadOnly}");
            Console.WriteLine($"List#{students3.CurrentList} is read only: {students3.IsReadOnly}");
            Console.WriteLine();

            //test of Remove
            Console.WriteLine("\ttest of Remove");
            students1.Remove(student4);     //no exceptions
            students3.Remove(student4);

            Console.WriteLine(students3);

            //test of RemoveAt
            Console.WriteLine("\ttest of RemoveAt");
            students1.RemoveAt(0);
            students3.RemoveAt(4);
            students3.RemoveAt(2);
            Console.WriteLine();

            Console.WriteLine(students3);

            //test of Contains()
            Console.WriteLine("\ttest of Contains()");
            Console.WriteLine($"List#{students1.CurrentList} contains student " +
                $"<{student1}>: {students1.Contains(student1)}");
            Console.WriteLine($"List#{students3.CurrentList} contains student " +
                $"<{student1}>: {students3.Contains(student1)}");
            Console.WriteLine();

            //test of IndexOf()
            //Console.WriteLine("\ttest of IndexOf()"); 
            Console.WriteLine($"Index of student <{student1}> in list#{students1.CurrentList}: " +
                $"{students1.IndexOf(student1)}");
            Console.WriteLine($"Index of student <{student1}> in list#{students3.CurrentList}: " +
                $"{students3.IndexOf(student1)}");
            Console.WriteLine();

            Console.WriteLine(students2);

            //test of Insert()
            Console.WriteLine("\ttest of Insert()");
            students1.Insert(0, student4);              //inserted
            students2.Insert(0, student4);              //inserted
            students3.Insert(10, student4);             //exception
            Console.WriteLine();

            Console.WriteLine(students1);
            Console.WriteLine(students2);
            Console.WriteLine(students3);

            //test of Copy()
            Console.WriteLine("\ttest of Copy()");
            Person[] people = new Person[2];
            students3.CopyTo(people, 0);
            students3.CopyTo(people, 10);

            foreach (Person p in people)
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine();

            //test of Clear()
            Console.WriteLine("\ttest of Clear()");
            students2.Clear();
            Console.WriteLine(students2);
            #endregion

            #region Serialization Tests

            //test of serialization to xml
            Console.WriteLine("\ttest of serialization to xml");
            FileInfo path1 = new FileInfo(@"C:\test\test.xml");
            XmlSerializer serializer = new(typeof(StudentList));

            StudentList serializedToXml = new StudentList() { student1, student2, student3, student4 };
            StudentList? deserializedFromXml;

            //serialization to xml
            using (FileStream stream = new FileStream(path1.FullName, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(stream, serializedToXml);
                Console.WriteLine($"List {serializedToXml.CurrentList} / {serializedToXml.NumOfLists} serialized...");
            }
            //deserialization from xml
            using (FileStream stream = new FileStream(path1.FullName, FileMode.Open, FileAccess.Read))
            {
                deserializedFromXml = serializer.Deserialize(stream) as StudentList;
                Console.WriteLine($"And deserialized");
                Console.WriteLine("\nDeserialized list:");
                if (deserializedFromXml != null) Console.WriteLine(deserializedFromXml);
            }



            //test of serialization to bin
            Console.WriteLine("\ttest of serialization to bin");
            FileInfo path2 = new FileInfo(@"C:\test\test.bin");
            IFormatter formatter = new BinaryFormatter();

            StudentList serializedToBin = new StudentList() { student1, student2, student3, student4 };
            StudentList? deserializedFromBin;

            //serialization to bin
            using (FileStream stream = new FileStream(path2.FullName, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(stream, serializedToBin);
                Console.WriteLine($"List {serializedToBin.CurrentList} / {serializedToBin.NumOfLists} serialized...");
            }

            //deserialization from bin
            using (FileStream stream = new FileStream(path2.FullName, FileMode.Open, FileAccess.Read))
            {
                deserializedFromBin = formatter.Deserialize(stream) as StudentList;
                Console.WriteLine($"And deserialized");
                Console.WriteLine("\nDeserialized list:");
                if (deserializedFromBin != null) Console.WriteLine(deserializedFromBin);
            }
            #endregion
        }
    }
}