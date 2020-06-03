using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ConsoleAppConvert
{
    static class Converter
    {
        public static void Convert(string fromPath, string toPath)
        {
            //string[] strs = File.ReadAllLines(fromPath);

            //Excel.Application excelApp = new Excel.Application();
            //excelApp.Workbooks.Add();
            //Excel.Worksheet worksheet = excelApp.ActiveSheet;
            //worksheet.Cells[1, "A"] = "Fam";
            //worksheet.Cells[2, "B"] = "Name";
            //worksheet.Cells[3, "C"] = "Age";
            //for (int i = 0; i <= 5; i++)
            //{
            //    worksheet.Cells[i + 1, "A"] = $"Фамилия{i}";
            //    worksheet.Cells[i + 1, "B"] = $"{i}-е имя";
            //    worksheet.Cells[i + 1, "C"] = 18 + i;
            //}
            //worksheet.Range["A1"].AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2);
            //excelApp.Visible = true;
            //worksheet.SaveAs($@"{Environment.CurrentDirectory}\Test.xlsx");

            string[] strs =
            {
                "25.05.2020 0:00:55;42,9799995422363;25.05.2020 0:00:55;44,4000015258789;25.05.2020 0:00:55;54;25.05.2020 0:00:55;527;25.05.2020 0:00:55;82,2799987792969",
                "25.05.2020 0:01:55; 43,1800003051758; 25.05.2020 0:01:55; 44,4000015258789; 25.05.2020 0:01:55; 54; 25.05.2020 0:01:55; 528; 25.05.2020 0:01:55; 82,879997253418"
            };
            //var data = strs.Skip(1);
            Excel.Application application = new Excel.Application();
            application.Workbooks.Add();
            application.Visible = true;
            application.UserControl = true;
            //var workbook = application.Workbooks.Open(toPath, 0, true, 5, "", "", false);
            //Excel.Worksheet worksheet = workbook.Worksheets[0];
            //foreach (var el in strs)
            //{
            //    var split = el.Split(';');
            //    string Date = split[0];
            //    string Power = split[1];
            //    string Frenq = split[3];
            //    string Temp = split[5];
            //    string Voltage = split[7];
            //    string Currency = split[9];
            //    Console.WriteLine($"{Date}, {Power}, {Frenq}, {Temp}, {Voltage}, {Currency}");
            //}
            //workbook.Save();
            //workbook.Close();


        }
    }
}
