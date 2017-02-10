using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Accessing Generic Add Method");
            Program p = new Program();
            Console.WriteLine("Adding two integers: {0}", p.Add<int>(1, 2));
            Console.WriteLine("Adding two float: {0}", p.Add<float>(1.2f, 2.56f));
            Console.WriteLine("Adding two double: {0}", p.Add<double>(1.25686, 2.78963));
            Console.WriteLine("Adding two strings: {0}", p.Add<string>("Bharat", " Sontam"));

            Console.WriteLine("Enter your option for type of employee you want to add: \n 1. FullTime \n 2. Contract");
            //string str = Console.ReadLine();
            short choice = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter employee FirstName: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter employee LastName: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter employee SSN: ");
            long ssn = Convert.ToInt64(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    FullTimeEmployee ftEmp = new FullTimeEmployee
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        SSN = ssn
                    };

                    Console.WriteLine("Enter Employee Joining date (yyyy/mm/dd): ");
                    ftEmp.JoiningDate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Enter employee salary:");
                    ftEmp.Salary = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("You have entered the following details: ");
                    Console.WriteLine("Employee FullName: {0} {1} \n Joining Date: {2} \n Salary: ${3} \n Employee Type: {4}",
                        ftEmp.FirstName, ftEmp.LastName, ftEmp.JoiningDate.ToShortDateString(), ftEmp.Salary, ftEmp.Type);

                    break;
                case 2:
                    ContractEmployee ctEmp = new ContractEmployee
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        SSN = ssn
                    };
                    Console.WriteLine("Enter Employee contract start date (yyyy/mm/dd): ");
                    ctEmp.ContractStartDate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Enter Employee contract end date (yyyy/mm/dd): ");
                    ctEmp.ContractEndDate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Enter employee hourly salary:");
                    ctEmp.HourlySalary = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("You have entered the following details: ");
                    Console.WriteLine("Employee FullName: {0} {1} \n Contract Start Date: {2} \n Contract End Date: {3} \n Salary: ${4} \n Employee Type: {5}",
                        ctEmp.FirstName, ctEmp.LastName, ctEmp.ContractStartDate.ToShortDateString(),
                        ctEmp.ContractEndDate.ToShortDateString(), ctEmp.HourlySalary, ctEmp.Type);

                    break;
            }
        }

        public T Add<T>(T a, T b)
        {
            T result = (dynamic)a + (dynamic)b;
            return result;
        }
    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long SSN { get; set; }
        public EmployeeType Type { get; protected set; }
    }

    public class FullTimeEmployee : Employee
    {
        public FullTimeEmployee()
        {
            this.Type = EmployeeType.FullTime;
        }
        public double Salary { get; set; }
        public DateTime JoiningDate { get; set; }
    }

    public class ContractEmployee : Employee
    {
        public ContractEmployee()
        {
            this.Type = EmployeeType.Contract;
        }
        public double HourlySalary { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
    }

    public enum EmployeeType
    {
        FullTime,
        Contract
    }
}
