using System;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseDemo
{
    public class Class1
    {
        static string constr = "data source=DESKTOP-912JH4M\\SQLEXPRESS;initial catalog=DetailsEmployee;integrated security=True;";
        public void DisplayEmployees()
        {
            DataTable DT = ExecuteData("select * from emp");
            if(DT.Rows.Count>0)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("=====================================================================");
                Console.WriteLine("DATABASE RECORDS");
                Console.WriteLine("=====================================================================");
                foreach(DataRow row in DT.Rows)
                {
                    Console.WriteLine(row["eno"].ToString() + " " + row["empname"].ToString() + " " + row["sal"].ToString());
                }
                Console.WriteLine("======================================================================" + Environment.NewLine);
            }
            else
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("No employee found in database table!!!");
                Console.Write(Environment.NewLine);
            }
        }
        public DataTable ExecuteData(String Query)
        {
            DataTable result = new DataTable();

            try
            {
                using(SqlConnection sqlcon = new SqlConnection(constr))
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand(Query, sqlcon);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(result);
                    sqlcon.Close();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }
        public void AddEmpliyee()
        {
            string eno = string.Empty;
            string empname = string.Empty;
            string sal = string.Empty;

            Console.WriteLine("Insert ne employee: ");

            Console.Write("Enter Empno: ");
            eno = Console.ReadLine();

            Console.Write("Enter EmpName: ");
            empname = Console.ReadLine();

            Console.Write("Enter Salary: ");
            sal = Console.ReadLine();

            ExecuteCommand(String.Format("Insert into emp(eno,empname,sal) values ('{0}','{1}','{2}')", eno, empname, sal));
        }
        public bool ExecuteCommand(string queury)
        { 
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(constr))
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand(queury, sqlcon);
                    cmd.ExecuteNonQuery();
                    sqlcon.Close();
                  
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
                throw;
            }
            return true;
        }
        public void EditEmployee()
        {
            string eno = string.Empty;
            string empname = string.Empty;
            string sal = string.Empty;
            Console.WriteLine("Edit existing Employee:  ");
            Console.WriteLine("Insert ne employee: ");

            Console.Write("Enter Empno: ");
            eno = Console.ReadLine();

            Console.Write("Enter EmpName: ");
            empname = Console.ReadLine();

            Console.Write("Enter Salary: ");
            sal = Console.ReadLine();

            ExecuteCommand(String.Format("Update emp set empname = '{0}', sal = '{1}', eno = '{2}' where eno = '{2}'", empname, sal, eno));
        }

        public void DeleteEmployee()
        {
            string eno = string.Empty;

            Console.WriteLine("Delet Existing EMPLOYEE: ");

            Console.Write("Enter Empno: ");
            eno = Console.ReadLine();

            ExecuteCommand(String.Format("Delete from emp where eno = '{0}'", eno));

            Console.WriteLine("Employee details deleted from the database!" + Environment.NewLine);
        }
        
    }
}
