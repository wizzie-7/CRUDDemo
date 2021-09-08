using System;
using DatabaseDemo;

namespace CRUDDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 C = new Class1();
            C.DisplayEmployees();
            
            C.AddEmpliyee();
            C.DisplayEmployees();
            
            C.EditEmployee();
            C.DisplayEmployees();
            
            C.DeleteEmployee();
            C.DisplayEmployees();
        }
    }
}
