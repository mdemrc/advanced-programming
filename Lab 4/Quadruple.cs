using System;
using System.Collections.Generic;

namespace Lab4
{
    // generic class holding four values of possibly different types.
    // first one acts as identifier and is used for sorting
    public class Quadruple<T1, T2, T3, T4> : IComparable<Quadruple<T1, T2, T3, T4>>
        where T1 : IComparable<T1>
    {
        private T1 id;
        private T2 second;
        private T3 third;
        private T4 fourth;

        public T1 Id { get { return id; } set { id = value; } }
        public T2 Second { get { return second; } set { second = value; } }
        public T3 Third { get { return third; } set { third = value; } }
        public T4 Fourth { get { return fourth; } set { fourth = value; } }

        public Quadruple()
        {
            id = default(T1);
            second = default(T2);
            third = default(T3);
            fourth = default(T4);
        }

        public Quadruple(T1 id, T2 second, T3 third, T4 fourth)
        {
            this.id = id;
            this.second = second;
            this.third = third;
            this.fourth = fourth;
        }

        public override string ToString()
        {
            return "[" + id + ", " + second + ", " + third + ", " + fourth + "]";
        }

        public override bool Equals(object obj)
        {
            if (obj is Quadruple<T1, T2, T3, T4> other)
            {
                return EqualityComparer<T1>.Default.Equals(id, other.id)
                    && EqualityComparer<T2>.Default.Equals(second, other.second)
                    && EqualityComparer<T3>.Default.Equals(third, other.third)
                    && EqualityComparer<T4>.Default.Equals(fourth, other.fourth);
            }
            return false;
        }

        public override int GetHashCode()
        {
            // combine hash codes of all fields
            int h1 = id == null ? 0 : id.GetHashCode();
            int h2 = second == null ? 0 : second.GetHashCode();
            int h3 = third == null ? 0 : third.GetHashCode();
            int h4 = fourth == null ? 0 : fourth.GetHashCode();
            return h1 ^ (h2 << 4) ^ (h3 << 8) ^ (h4 << 12);
        }

        // compare by id field
        public int CompareTo(Quadruple<T1, T2, T3, T4> other)
        {
            if (other == null) return 1;
            return this.id.CompareTo(other.id);
        }
    }
}
