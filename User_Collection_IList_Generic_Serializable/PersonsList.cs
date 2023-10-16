using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Collection_IList_Generic_Serializable
{
    [Serializable]
    public abstract class PersonsList<T> : IList<T> where T : Person
    {
        public List<T> personsList;
        public PersonsList() { personsList = new List<T>(); }
        public PersonsList(IEnumerable<T> collection) : this()
        {
            if (collection != null)
            {
                foreach (T person in collection)
                {
                    if (person != null) personsList.Add(person);
                }
            }
        }
        public T this[int index]
        {
            get
            {
                try { return personsList[index]; }
                catch (Exception e) { Console.WriteLine(e.Message); return null; }
            }
            set
            {
                try { personsList[index] = value; }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }
        }
        public void Add(T person)
        {
            if (person != null) personsList.Add(person);
        }
        public int Count { get { return personsList.Count; } }
        public bool IsReadOnly => false;
        public void Clear() => personsList.Clear();
        public bool Contains(T item) => personsList.Contains(item);
        public void CopyTo(T[] array, int arrayIndex)
        {
            try { personsList.CopyTo(array, arrayIndex); }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
        public int IndexOf(T item) => personsList.IndexOf(item);
        public void Insert(int index, T item)
        {
            try { personsList.Insert(index, item); }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
        public bool Remove(T item) => personsList.Remove(item);
        public void RemoveAt(int index)
        {
            try { personsList.RemoveAt(index); }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
        public IEnumerator<T> GetEnumerator() => personsList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => personsList.GetEnumerator();
        public override string ToString()
        {
            if (Count != 0)
            {
                StringBuilder collectInfoWithStrBuilder = new();
                foreach (T item in personsList)
                {
                    collectInfoWithStrBuilder.AppendLine(item.ToString());
                }
                return collectInfoWithStrBuilder.ToString();
            }
            else return "Collection is empty\n";
        }
    }
}
