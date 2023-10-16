using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Collection_IList_Generic_Serializable
{
    [Serializable]
    public class StudentList : PersonsList<Person>
    {
        private int currentList;
        private static int numOfLists;
        static object locker = new object();
        public int CurrentList { get { return currentList; } }
        public int NumOfLists { get { return numOfLists; } }
        static StudentList() => numOfLists = 0;
        public StudentList() : base() { SetNum(); }
        public StudentList(IEnumerable<Person> collection) : base(collection) { SetNum(); }
        private void SetNum()
        {
            lock (locker)
            {
                numOfLists++;
                currentList = numOfLists;
            }
        }
        public override string ToString()
        {
            return $"List {currentList} / {numOfLists}\n" + base.ToString();
        }
    }

}
