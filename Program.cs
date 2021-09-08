using System;
using DatabaseDemo;

namespace CRUDDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 d = new Class1();
            d.DisplayEmployees();
            
            d.AddEmpliyee();
            d.DisplayEmployees();
            
            d.EditEmployee();
            d.DisplayEmployees();
            
            d.DeleteEmployee();
            d.DisplayEmployees();
        }
    }
}
