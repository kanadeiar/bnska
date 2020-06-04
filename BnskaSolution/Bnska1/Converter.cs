using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Bnska1
{
    static class Converter
    {
        public static void ConvertCSVToXLSX(string fromPath, string toPath)
        {
            string[] strsRaw = File.ReadAllLines(fromPath);

            string[] strs = strsRaw.Skip(1).ToArray();
            Excel.Application application = new Excel.Application();
            var workbook = application.Workbooks.Open(toPath, 0, true, 5, "", "", false);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];
            int currLine = 0;

            int rowCount = strs.Length;
            int colCount = 6;
            object[,] cells = new object[rowCount + 1000, colCount];
            foreach (var el in strs)
            {
                var split = el.Split(';');
                string Date = split[0].Remove(split[0].LastIndexOf(':'));
                string Power = split[1];
                string Frenq = split[3];
                string Temp = split[5];
                string Voltage = split[7];
                string Currency = split[9];
                cells[currLine, 0] = Date;
                cells[currLine, 1] = Power.Replace(',', '.');
                cells[currLine, 2] = Frenq.Replace(',', '.');
                cells[currLine, 3] = Temp.Replace(',', '.');
                cells[currLine, 4] = Voltage.Replace(',', '.');
                cells[currLine, 5] = Currency.Replace(',', '.');
                currLine++;
            }
            for (int i = rowCount; i < rowCount + 1000; i++)
            {
                cells[currLine, 0] = "";
                cells[currLine, 1] = "";
                cells[currLine, 2] = "";
                cells[currLine, 3] = "";
                cells[currLine, 4] = "";
                cells[currLine, 5] = "";
                currLine++;
            }
            worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[2, 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[rowCount + 1 + 1000, colCount])).Value = cells;


            ((Excel.Worksheet)workbook.Sheets[2]).Activate();
            application.Visible = true;
            application.UserControl = true;
            workbook.Save();
            workbook.Close();
            application.Quit();
        }
    }
}
