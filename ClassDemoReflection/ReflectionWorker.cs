using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace ClassDemoReflection
{
    internal class ReflectionWorker
    {
        public void Start()
        {
            Object o = new Person() { Id = 9, Name = "Peter" };
            Console.WriteLine("Person object ==> " + o);

            /*
            * Reflection
            */
            Type t = o.GetType();




        }


    }

    internal class Person
    {
        public String Name { get; set; }

        public int Id { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Id)}: {Id}";
        }
    }

}