namespace HomeWork08
{
    internal class Program
    {
        static void Main(string[] args)
        {
        
            var people = new List<Person>
            {
                new Person { Name = "Анна", Age = 25 },
                new Person { Name = "Борис", Age = 30 },
                new Person { Name = "Виктор", Age = 22 },
                new Person { Name = "Галина", Age = 35 }
            };

            var oldest = people.GetMax<Person>(p => p.Age);
            if (oldest != null)
            {
                Console.WriteLine($"Самый старший: {oldest.Name} {oldest.Age}");
            }

        }
    }
}
