using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using Microsoft.VisualBasic.FileIO;
using System.Text;

namespace WebApi
{
    public static class ProcessCsv
    {
        public static List<VehicleSales> CsvResult(Stream inputStream) {
            List<VehicleSales> csvResult = new List<VehicleSales>();
            VehicleSales rowResult = new VehicleSales();
            StreamReader srCsv = new StreamReader(inputStream);
            string[] csvColumns;
            using (TextFieldParser parser = new TextFieldParser(inputStream))
            {
                parser.SetDelimiters(new string[] { "," });
                parser.HasFieldsEnclosedInQuotes = true;
                // Get header line.
                csvColumns = parser.ReadLine().Split(",");
                if (Enumerable.SequenceEqual(csvColumns, GeneralFunctions.RetrieveColumnNamesOfClass(rowResult)))
                {
                    //Is a Valid CSV
                    while (!parser.EndOfData)
                    {
                        csvColumns = parser.ReadFields( );
                        rowResult = new VehicleSales
                        {
                            DealNumber = Convert.ToInt32(csvColumns[0].ToString()),
                            CustomerName = csvColumns[1].ToString(),
                            DealershipName = csvColumns[2].ToString(),
                            Vehicle = csvColumns[3].ToString(),
                            Price = Convert.ToDecimal(csvColumns[4].ToString()),
                            Date = Convert.ToDateTime(csvColumns[5].ToString())
                        };
                        csvResult.Add(rowResult);
                    }
                }
                else {
                    throw new Exception("Invalid CSV Format");
                }
                return csvResult;
            }
        }
    }
}
