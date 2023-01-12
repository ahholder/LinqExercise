using System;
using System.Collections.Generic;
using System.Linq;

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
            var sum = numbers.Sum();
            Console.WriteLine("SUM: " + sum);

            //TODO: Print the Average of numbers
            Console.WriteLine("");
            var avg = numbers.Average();
            Console.WriteLine("AVG: " + avg);

            //TODO: Order numbers in ascending order and print to the console
            Console.WriteLine("");
            Console.Write("Ascending: ");
            var asc = numbers.OrderBy(num => num);
            Console.WriteLine("");
            foreach (var num in asc)
            {
                Console.WriteLine(num);
            }

            //TODO: Order numbers in decsending order and print to the console
            Console.WriteLine("");
            Console.Write("Descending: ");
            Console.WriteLine("");
            var desc = numbers.OrderByDescending(numb => numb);
            foreach (var numb in desc)
            {
                Console.WriteLine(numb);
            }

            //TODO: Print to the console only the numbers greater than 6
            Console.WriteLine("");
            var gSix = numbers.Where(num => num > 6);
            Console.WriteLine("Greater than 6:");
            foreach (var num in gSix) Console.WriteLine(num);

            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("");
            Console.WriteLine("Take 4:");
            var firstFour = numbers.OrderBy(num => num).Take(4);
            foreach (var num in firstFour) Console.WriteLine(num);

            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 27;
            var ageNums = numbers.OrderByDescending(num => num);
            Console.WriteLine("");
            Console.WriteLine("Age at 4, then Descending:");
            foreach (var num in ageNums) Console.WriteLine(num);

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var cNames = employees.Where(name => name.FirstName.StartsWith('C') || name.FirstName.StartsWith('S')).OrderBy(name => name.FirstName);
            Console.WriteLine("Employees with 'C' or 'S':");
            foreach (var boi in cNames) Console.WriteLine(boi.FullName);

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var aged = employees.Where(name => name.Age > 26).OrderBy(name => name.Age).ThenBy(name => name.FirstName);
            Console.WriteLine("");
            Console.WriteLine("Employees Age 26+:");
            foreach (var boi in aged) Console.WriteLine(boi.FullName);

            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.WriteLine("");
            var exp = employees.Where(name => name.YearsOfExperience <= 10 && name.Age > 35);
            //foreach (var boi in exp) Console.WriteLine($"YOE: {exp.Sum(num => num.YearsOfExperience)} SUM, {exp.Average(num => num.YearsOfExperience)} AVERAGE");
            Console.WriteLine($"Select Years of Experience: {exp.Sum(num => num.YearsOfExperience)} SUM, {exp.Average(num => num.YearsOfExperience)} AVERAGE");

            //TODO: Add an employee to the end of the list without using employees.Add()
            /*var noob = new Employee();
            noob.YearsOfExperience = 0;
            noob.FirstName = "Alex";
            noob.LastName = "Holder";
            noob.Age = 27;
            employees.Append(noob);*/
            var everyone = employees.Append(new Employee("Alex","Holder",27,0));
            Console.WriteLine("");
            Console.WriteLine("All Employees:");
            foreach (var imp in everyone) Console.WriteLine($"{imp.FullName}: {imp.YearsOfExperience} YOE at Age {imp.Age}");


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
