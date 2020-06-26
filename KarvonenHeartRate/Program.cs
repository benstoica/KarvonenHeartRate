using System;
using System.Data;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KarvonenHeartRate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Project: Karvonen Heart Rate");
            Console.WriteLine("Hello! Today we're going to calculate your target heart rate!");
            Console.WriteLine();

            int age;
            int restingHeartRate;
            double intensity;
            int targetHeartRate;

            Console.WriteLine("What is your age?");
            while (!Int32.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Please enter a valid number:");
            }

            Console.WriteLine("What is your resting heart rate?");
            while (!Int32.TryParse(Console.ReadLine(), out restingHeartRate))
            {
                Console.WriteLine("Please enter a valid number:");
            }

            Console.WriteLine();

            //create table
            DataTable resultsTable = new DataTable();

            DataColumn intensityColumn = new DataColumn();
            intensityColumn.ColumnName = "Intensity";
            intensityColumn.DataType = Type.GetType("System.String");
            resultsTable.Columns.Add(intensityColumn);

            DataColumn rateColumn = new DataColumn();
            rateColumn.ColumnName = "Rate";
            rateColumn.DataType = Type.GetType("System.String");
            resultsTable.Columns.Add(rateColumn);


            //calculate target rate for every intensity level
            for (intensity = .55; intensity < 1; intensity += 0.05)
            {
                targetHeartRate = (int)((((220 - age) - restingHeartRate) * intensity) + restingHeartRate);
                resultsTable.Rows.Add((int)(intensity * 100) + "%", targetHeartRate + " bpm");
            }

            foreach (DataColumn column in resultsTable.Columns) 
            {
                Console.Write(column.ColumnName + "| ".PadRight(7, ' '));
            }

            Console.WriteLine();
            Console.WriteLine("--------------------------");

            foreach (DataRow row in resultsTable.Rows)
            {
                System.IO.StringWriter sw = new System.IO.StringWriter();
                foreach (DataColumn col in resultsTable.Columns)
                    sw.Write(row[col].ToString() + " \t | ".PadRight(7, ' '));
                string output = sw.ToString();
                Console.WriteLine(output);
            }
        }
    }
}
