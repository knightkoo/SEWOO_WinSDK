using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;
using System.Management;

namespace Printer
{
    public class PrinterAgent : Singleton<PrinterAgent>
    {
        List<OqPrinter> mActivePrinters = new List<OqPrinter>();

        public static string[] GetPrinterDevices()
        {
            List<string> printers = new List<string>();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                printers.Add(printer);
            }

            return printers.ToArray();
        }

        public bool Prepare()
        {
            GetPrinterDevices();

            var lkPrinter = new LKPrint();
            if( lkPrinter.Prepare(PrinterConfig.MakePrinterWithUSB()))
                AddPrinter(lkPrinter);

            return true;
        }

        public void AddPrinter(OqPrinter printer)
        {
            mActivePrinters.Add(printer);
        }

        public bool PrintBitmap(string filePath)
        {
            foreach (var printer in mActivePrinters)
            {
                printer.PrintBitmap(filePath);
            }
            return true;
        }
    }
}
