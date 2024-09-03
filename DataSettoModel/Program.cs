// See https://aka.ms/new-console-template for more information

// Create and populate a DataSet
using DataSettoModel;
using System.Data;

var dataSet = new DataSet();

// Create and populate DataTables
var tableB = new DataTable();
tableB.Columns.Add("Id", typeof(int));
tableB.Columns.Add("Name", typeof(string));
tableB.Rows.Add(1, "Alice");
tableB.Rows.Add(2, "Bob");

var tableC = new DataTable();
tableC.Columns.Add("Id", typeof(int));
tableC.Columns.Add("Description", typeof(string));
tableC.Rows.Add(1, "Description1");
tableC.Rows.Add(2, "Description2");

dataSet.Tables.Add(tableB);
dataSet.Tables.Add(tableC);

// Convert DataSet to object of class A
A myObject = DataSetConverter.ConvertDataSetToClass<A>(dataSet);

// Output the result
Console.WriteLine("List B:");


Console.WriteLine("Hello, World!");
