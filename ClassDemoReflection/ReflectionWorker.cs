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

            Console.WriteLine("Navn: " + t.FullName);
            Console.WriteLine("Interface? " + t.IsInterface);
            Console.WriteLine("Class? " + t.IsClass);
            Console.WriteLine("Base " + t.BaseType);


            Console.WriteLine("    Properties ");
            foreach (PropertyInfo pinfo in t.GetProperties())
            {
                Console.WriteLine(pinfo);
            }

            Console.WriteLine("    Methods ");
            foreach (MethodInfo minfo in t.GetMethods())
            {
                Console.WriteLine(minfo);
            }


            /*
             * Call of method
             */
            MethodInfo setIdMethod = t.GetMethods().First(m => m.Name == "set_Id");

            Console.WriteLine("Object before " + o);
            setIdMethod.Invoke(o, new object[] {23});
            Console.WriteLine("Object after " + o);


            PropertyInfo pi = t.GetProperty("Id");
            Console.WriteLine($"Name {pi.Name} + value {pi.GetValue(o)}");


            /*
             * Call extension method
             */
            Person p = o as Person;
            Console.WriteLine("Person upper name " + p.GetUpperName());

            /*
             * new  'anonyous' classes
             */
            var personNew = new {p.Name, OddNumber = p.Id % 2 == 1};
            Console.WriteLine($"Name {personNew.Name} have odd number {personNew.OddNumber}");



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

    internal static class PersonExtension
    {
        public static string GetUpperName(this Person p)
        {
            return p.Name.ToUpper();
        }

    } 

}