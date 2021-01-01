using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;

namespace infopcbattery
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Mustafa Koca | PC YÖNETİMİ";
            
            //BATARYA
            ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_Battery");
            foreach (ManagementObject item in mos.Get())
            {
                Console.WriteLine("Batarya adı: " + item["Name"]);
                Console.WriteLine("Durumu: " + item["EstimatedChargeRemaining"]);
            }
            Console.WriteLine("Kalan pil süresi : {0}", SystemInformation.PowerStatus.BatteryLifeRemaining);

            //SERVİS
            ManagementObjectSearcher moss = new ManagementObjectSearcher("Select * from Win32_Service Where State='Running' AND StartMode='Manual'");
            foreach (ManagementObject mo in moss.Get())
            {
                Console.WriteLine("Servis : {0}", mo["Name"]);
            }

            //ÇALIŞAN PROCESS LER
            ManagementObjectSearcher mosSS = new ManagementObjectSearcher("Select * from Win32_Process");
            foreach (ManagementObject mo in mosSS.Get())
            {
                Console.WriteLine("Process : {0}", mo["Name"]);
            }

            //İŞLEMCİ
            ManagementObjectSearcher moSs = new ManagementObjectSearcher("Select * from Win32_Processor");
            foreach (ManagementObject mo in moSs.Get())
            {
                Console.WriteLine("Process : {0}", mo["Name"]);
            }

            //WİFİ
            //ManagementObjectSearcher mosS = new ManagementObjectSearcher(@"root\WMI", "select * from MSNdis_80211_ReceivedSignalStrength");
            //foreach (ManagementObject mo in mosS.Get())
            //{
            //    Console.WriteLine("", mo["Ndis80211ReceivedSignalStrength"]);
            //}


            Console.ReadLine();
        }
    }
}
