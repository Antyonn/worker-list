using System.Globalization;

namespace Company
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.Write("How many employees will be registered? ");
      int rooms = int.Parse(Console.ReadLine());
      List<Employee> employee = new List<Employee>();
      for (int i = 0; i < rooms; i++)
      {
        Console.WriteLine($"Employee #{i + 1}");
        Console.Write("Id: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Salary: ");
        double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        employee.Add(new Employee(id, name, salary));
      }
      Console.Write("Enter the employee id that will have salary increase: ");
      int idEmployee = int.Parse(Console.ReadLine());

      Employee emp = employee.Find(x => x.Id == idEmployee);

      if (emp != null)
      {
        Console.Write("Enter the percentage: ");
        double percentage = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        emp.increaseSalary(percentage);
      }
      else
      {
        Console.WriteLine("Id does not exist!");
        Environment.Exit(0);
      }
      Console.WriteLine("Updated list of employees:");
      foreach (var room in employee)
      {
        Console.WriteLine(room);
      }
    }
  }
  class Employee
  {
    public int Id { get; set; }
    public string Name { get; set; }
    private double Salary { get; set; }

    public Employee(int id, string name, double salary)
    {
      Id = id;
      Name = name;
      Salary = salary;
    }

    public void increaseSalary(double percentage)
    {
      Salary += Salary * (percentage / 100.0);
    }
    public override string ToString()
    {
      return $"{Id}, {Name}, {Salary.ToString("F2", CultureInfo.InvariantCulture)}";
    }
  }
}
