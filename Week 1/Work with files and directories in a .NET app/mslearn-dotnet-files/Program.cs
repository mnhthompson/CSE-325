

using System.Security.Cryptography.X509Certificates;
 using System.Data;
 using System.Text;
using Newtonsoft.Json; 

var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory, "stores");

var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
Directory.CreateDirectory(salesTotalDir);   

var salesFiles = FindFiles(storesDirectory);

var salesTotal = CalculateSalesTotal(salesFiles);

File.AppendAllText(Path.Combine(salesTotalDir, "totals.txt"), $"{salesTotal}{Environment.NewLine}");



IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var file in foundFiles)
    {
        var extension = Path.GetExtension(file);
        if (extension == ".json")
        {
            salesFiles.Add(file);
        }
    }

    return salesFiles;
}

double CalculateSalesTotal(IEnumerable<string> salesFiles)
{
    double salesTotal = 0;
    
    // Loop over each file path in salesFiles
    foreach (var file in salesFiles)
    {      
        // Read the contents of the file
        string salesJson = File.ReadAllText(file);
    
        // Parse the contents as JSON
        SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);
    
        // Add the amount found in the Total field to the salesTotal variable
        salesTotal += data?.Total ?? 0;
    }
    
    return salesTotal;
}



Save(salesFiles);
// function to generates a sales summary report file.

// a detailed report of each the total sales.


 void Save(IEnumerable<string> salesFiles)
{
    Console.WriteLine("Saving");
    string filename = "SalesSummary";
    StringBuilder glue = new StringBuilder(); 
glue.AppendLine(string.Join(" ", "Sales Summary"));
glue.AppendLine(string.Join(" ", "----------------------------"));
glue.AppendLine(string.Join("Total Sales:", $"Total Sales:{CalculateSalesTotal(salesFiles)}"));
glue.AppendLine(string.Join(" ", "Details:"));
// The file should contain simple text that shows the actual sales total from the file 
    foreach (var file in salesFiles)
    {      
        // Read the contents of the file
        string salesJson = File.ReadAllText(file);
        // Parse the contents as JSON
        SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);
        glue.AppendLine(string.Join(" ", $"{file}:{data}"));
    }
File.WriteAllText(filename, glue.ToString());
}




record SalesData (double Total);
