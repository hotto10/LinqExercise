using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine("Sum of all numbers:");
            Console.WriteLine(numbers.Sum());

            //TODO: Print the Average of numbers
            Console.WriteLine("Average:");
            Console.WriteLine(numbers.Average());

            //TODO: Order numbers in ascending order and print to the console
            Console.WriteLine("numbers in ascending order");
            numbers.Where(x => x > 0).ToList().ForEach(x => Console.WriteLine(x));

            //TODO: Order numbers in decsending order and print to the console
            Console.WriteLine("numbers in descending order");
            numbers.OrderByDescending(x => x).ToList().ForEach(x => Console.WriteLine(x));

            //TODO: Print to the console only the numbers greater than 6

            Console.WriteLine("Numbers greater than 6");
            numbers.Where(x => x > 6).ToList().ForEach(x => Console.WriteLine(x));

            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**

            Console.WriteLine("printing 4 numbers");
            numbers.Take(4).ToList().ForEach(x => Console.WriteLine(x));

            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order

            Console.WriteLine("to my age going in descending order");
            numbers[4] = 33;
            numbers.OrderByDescending(numbers => numbers).ToList().ForEach(x => Console.WriteLine(x));

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            Console.WriteLine("Attempt of C or S names in ascending order" );


            var results = employees.Where(x => x.FirstName.StartsWith("c", StringComparison.CurrentCultureIgnoreCase) || x.FirstName.StartsWith("s", StringComparison.CurrentCultureIgnoreCase)).ToList();
            
            foreach (var employee in results)
            {
                Console.WriteLine($"{employee.FullName}");
            }
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            
            Console.WriteLine("employess that are over the age of 26:");
            var myEmployee = employees.Where(x => x.Age > 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName);
            
            foreach (var employee in myEmployee)
            {
                Console.WriteLine($"{employee.Age}, {employee.FirstName}");
            }

            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            
            var average = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            Console.WriteLine("Sum and Average Experiece of Employees:");
            Console.WriteLine($"Total years of experiece: {average.Sum(x => x.YearsOfExperience)}");
            Console.WriteLine($"Average of years of experience: {average.Average(x => x.YearsOfExperience)}");

            //TODO: Add an employee to the end of the list without using employees.Add()
            var employeeAdd = employees.Append(new Employee { FirstName = "Suzie", LastName = "Q", YearsOfExperience = 2, Age = 45 });
            foreach (var item in employeeAdd)
            {
                Console.WriteLine($"Name: {item.FullName}, Years of Experience: {item.YearsOfExperience}, Age: {item.Age} ");
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
