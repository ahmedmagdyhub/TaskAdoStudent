using Microsoft.Data.SqlClient;
using System.Data;

namespace TaskAdoStudent
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string conn = "Server=.;Database=Ado;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true";
            SqlConnection connection = new SqlConnection(conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Student", connection);
            SqlCommandBuilder sqlCommandBuilder = new (sqlDataAdapter);


            DataTable result = new DataTable();


            sqlDataAdapter.Fill(result);
          
            while (true)
            {
                Console.WriteLine("Enter 1 To Add Student ");
                Console.WriteLine("Enter 2 To Delete Student ");
                Console.WriteLine("Enter 3 To Display All Students ");
                Console.WriteLine("Enter 4 To Search Student ");
                Console.WriteLine("Enter 5 To Edit Student");
                Console.WriteLine("Enter 6 To Exit ");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (n == 1)
                {
                    DataRow newRow = result.NewRow();


                    Console.WriteLine("Enter ID Student");
                    newRow["id"] = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter Name Student");
                    
                    newRow["name"] = Console.ReadLine();

                    Console.WriteLine("Enter Age Student");
                     
                    newRow["age"] = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter Grade Student");
                    newRow["grades"] = Convert.ToDecimal(Console.ReadLine());

                    result.Rows.Add(newRow);
                    sqlDataAdapter.Update(result);

                    Console.WriteLine("Student Add successful");
                    Console.Clear();
                }
                if (n == 2)
                {
                    Console.Clear();

                    Console.WriteLine("Enter Student Id To Delete");
                    int id = Convert.ToInt32(Console.ReadLine());
                    DataRow row = result.Select($"id = {id}")[0];

                    row.Delete();
                    sqlDataAdapter.Update(result);
                    Console.WriteLine("Student Delete successful");

                 
                }
                if (n == 3)
                {
                    Console.Clear();

                    foreach (DataRow item in result.Rows)
                    {
                        Console.WriteLine($"Id = {item["id"]}  Name = {item["name"]}  Age = {item["age"]}  Grades = {item["grades"]} ");
                    }
                    Console.WriteLine();
                    

                }

                if (n == 4)
                {
                    Console.Clear();

                    Console.WriteLine("ENter Id Student To Search");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    DataRow[] rows = result.Select($"id = {id}");

                    if (rows.Length > 0)
                    {
                        DataRow row = rows[0];

                        Console.WriteLine($"Id = {row["id"]}");
                        Console.WriteLine($"Name = {row["name"]}");
                        Console.WriteLine($"Age = {row["age"]}");
                        Console.WriteLine($"Grades = {row["grades"]}");
                    }
                    else
                    {
                        Console.WriteLine("Student not found");
                    }

                    Console.WriteLine("------------------------------------------------");

                }
                if (n == 5)
                {
                    Console.Clear();
                    Console.WriteLine("Enter Student Id To Edit");
                    int id = Convert.ToInt32(Console.ReadLine());




                    DataRow[] rows = result.Select($"id = {id}");

                    if (rows.Length > 0)
                    {
                        DataRow row = rows[0];
                        Console.WriteLine("Enter New Name Student");


                        row["name"] = Console.ReadLine();
                        Console.WriteLine("Enter New Age Student");
           
                        row["age"] = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter New Grade Student");

                        row["grades"] = Convert.ToDecimal(Console.ReadLine());


                        sqlDataAdapter.Update(result);
                        Console.WriteLine("Student Edit successful");

                    }
                    else
                    {
                        Console.WriteLine("Student not found");
                    }
                 
                }
                if (n == 6)
                {
                    break;
                }
            }

        }
    }
}
