using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    // person owning a list of cars. Implements IEnumerable<Car> and IComparable<Person>
    public class Person : IEnumerable<Car>, IComparable<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public List<Car> Cars { get; set; }

        // default constructor
        public Person()
        {
            FirstName = "";
            LastName = "";
            Age = 0;
            Cars = new List<Car>();
        }

        // constructor with parameters
        public Person(string firstName, string lastName, int age, List<Car> cars)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Cars = cars ?? new List<Car>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(FirstName + " " + LastName + ", age " + Age + ", cars: ");
            if (Cars.Count == 0)
            {
                sb.Append("none");
            }
            else
            {
                for (int i = 0; i < Cars.Count; i++)
                {
                    sb.Append(Cars[i].ToString());
                    if (i < Cars.Count - 1) sb.Append("; ");
                }
            }
            return sb.ToString();
        }

        // sum of all car prices, used for comparing two people
        public double TotalCarsValue()
        {
            double sum = 0;
            foreach (Car c in Cars) sum += c.Price;
            return sum;
        }

        // compare based on total cars value
        public int CompareTo(Person other)
        {
            if (other == null) return 1;
            return this.TotalCarsValue().CompareTo(other.TotalCarsValue());
        }

        // generic enumerator over cars
        public IEnumerator<Car> GetEnumerator()
        {
            return Cars.GetEnumerator();
        }

        // non generic enumerator required by interface
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
