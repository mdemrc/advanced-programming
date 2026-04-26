using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4
{
    // static class with generic helper methods
    public static class GenericMethods
    {
        // 1) swap two values of the same type using ref
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        // 2) print types and values, then reset to default
        public static void PrintAndReset<T1, T2>(ref T1 first, ref T2 second)
        {
            Console.WriteLine("First type: " + first.GetType().Name + ", value: " + first.ToString());
            Console.WriteLine("Second type: " + second.GetType().Name + ", value: " + second.ToString());
            first = default(T1);
            second = default(T2);
        }

        // 3) create a new object using parameterless constructor
        public static T CreateNew<T>() where T : new()
        {
            return new T();
        }

        // 4) return the bigger one of two values
        public static T Bigger<T>(T a, T b) where T : IComparable<T>
        {
            // CompareTo returns positive when a is greater
            if (a.CompareTo(b) >= 0)
                return a;
            return b;
        }

        // 5) take any number of items and return them sorted as a List
        public static List<T> SortedList<T>(params T[] items) where T : IComparable<T>
        {
            List<T> list = new List<T>(items);
            list.Sort();
            return list;
        }

        // 6) build a dictionary with one entry. Key must be a struct, value must be a class
        public static Dictionary<TKey, TValue> MakeDictionary<TKey, TValue>(TKey key, TValue value)
            where TKey : struct
            where TValue : class
        {
            Dictionary<TKey, TValue> dict = new Dictionary<TKey, TValue>();
            dict.Add(key, value);
            return dict;
        }

        // 7) print all entries of a dictionary
        public static void PrintDictionary<TKey, TValue>(Dictionary<TKey, TValue> dict)
        {
            foreach (KeyValuePair<TKey, TValue> entry in dict)
            {
                Console.WriteLine("Key: " + entry.Key + " => Value: " + entry.Value);
            }
        }

        // 8) return a queue if less than 3 items, otherwise return a stack
        public static IEnumerable<T> QueueOrStack<T>(params T[] items)
        {
            if (items.Length < 3)
            {
                Queue<T> queue = new Queue<T>();
                foreach (T item in items)
                    queue.Enqueue(item);
                return queue;
            }
            else
            {
                Stack<T> stack = new Stack<T>();
                foreach (T item in items)
                    stack.Push(item);
                return stack;
            }
        }
    }
}
