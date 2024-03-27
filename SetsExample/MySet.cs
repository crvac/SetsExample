using System.Collections;

namespace SetsExample
{
    public class MySet<T> : IEnumerable<T>
        where T: IComparable<T>
    {
        private readonly List<T> _items = new List<T>();

        public MySet()
        { }
        public MySet(IEnumerable<T> items)
        {
            AddRange(items);
        }

        public void Add(T item)
        {
            if (Contains(item))
                throw new InvalidOperationException("Item already exists in Set");

            _items.Add(item);
        }
        public void AddRange(IEnumerable<T> items)
        {
            foreach (T item in items)
                Add(item);
        }

        public bool Remove(T item)
        {
            return _items.Remove(item);
        }
        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

        public int Count {  get { return _items.Count; } }

        public MySet<T> Union(MySet<T> other)
        {
            MySet<T> union = [.. other];
            foreach(T item in _items)
            {
                if (!union.Contains(item))
                    union.Add(item);
            }
            return union;
        }
        public MySet<T> Interesection(MySet<T> other)
        {
            MySet<T> interesection = new MySet<T>();
            foreach (T item in other)
            {
                if (_items.Contains(item))
                    interesection.Add(item);
            }
            return interesection;
        }
        public MySet<T> Difference(MySet<T> other)
        {
            MySet<T> difference = [.. _items];
            foreach (T item in other)
            {
                if (_items.Contains(item))
                    difference.Remove(item);
            }
            return difference;
        }
        public MySet<T> SymmetricalDifference(MySet<T> other)
        {
            MySet<T> intersection = Interesection(other);
            MySet<T> union = Union(other);

            return union.Difference(intersection);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
