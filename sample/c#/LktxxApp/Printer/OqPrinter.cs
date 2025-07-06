using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;
using Newtonsoft.Json;

namespace Printer
{
    public enum ConnectionType
    {
        USB,
        IP,
        DRIVER
    }

    public class PrinterConfig
    {
        public ConnectionType connectionType = ConnectionType.USB;
        public string detail;
        public int subValue;

        /**
         * @brief USB 지원 프린터 설정
         * @param baudRate 4800 | 9600 | 19200| 38400 | 57600 | 115200 
         */
        public static PrinterConfig MakePrinterWithUSB(int baudRate = 38400)
        {
            return new PrinterConfig()
            { 
                connectionType = ConnectionType.USB, 
                subValue = baudRate
            };
        }

        public static PrinterConfig MakePrinterWithDriver(string driverName)
        {
            return new PrinterConfig()
            {
                connectionType = ConnectionType.DRIVER,
                detail = driverName
            };
        }

        public static PrinterConfig MakePrinterWithIp(string ip, int port = 9100)
        {
            return new PrinterConfig()
            {
                connectionType = ConnectionType.IP,
                detail = ip,
                subValue = port
            };
        }


        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static PrinterConfig FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<PrinterConfig>(json);
            }
            catch(Exception e)
            {
                Logger.Error(e.Message);
            }

            return new PrinterConfig();
        }
    }

    public interface OqPrinter
    {
        bool Prepare(PrinterConfig printerConfig);
        bool PrintBitmap(string filePath);
    }
}
