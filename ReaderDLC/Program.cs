using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Threading;
using System.Threading.Tasks;
using System.Text;


namespace DLC_List_Generator_by_Frazzlee
{
    class Program
    {
        private static string[] foldernames;

        public static object exactnamearray { get; private set; }

        static void Main(string[] args)
        {


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Changelog available on mod homepage");
            Thread.Sleep(1900);
            



            //Variables
            string half1 = @"		<Item>dlcpacks:\";
            string half2 = @"\</Item>";



            //Setting up Console appearance
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();


            // Reads the file as one string
            //System.String directory = System.IO.File.ReadAllText(@"INFO.txt");

            string directory1 = System.Reflection.Assembly.GetEntryAssembly().Location;

            string directory = directory1.Remove(directory1.Length - 14);

            Console.WriteLine(directory);


            /*if (!Directory.Exists(directory))
            {
                Console.WriteLine("Specified path does not exist, change directory in INFO.txt");
                Thread.Sleep(10000);
                Environment.Exit(0);
            }
            else
                Console.WriteLine("{0} is a valid directory", directory);
                Thread.Sleep(2000);
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Clear();*/




            //Getting foldernames here and everything to do with folders and gettings names/paths
            string[] allFolders = Directory.EnumerateDirectories(directory)
            .Select(d => new DirectoryInfo(d).Name).ToArray();

            foreach (string folder in allFolders)
                Console.WriteLine("{0}{1}{2}", half1, folder, half2);
                Console.WriteLine("		<Item>platform:\\dlcPacks\\mpBeach\\</Item>");
                Console.WriteLine("		<Item>platform:\\dlcPacks\\mpBusiness\\</Item>");
                Console.WriteLine("		<Item>platform:\\dlcPacks\\mpChristmas\\</Item>");
                Console.WriteLine("		<Item>platform:\\dlcPacks\\mpValentines\\</Item>");
                Console.WriteLine("		<Item>platform:\\dlcPacks\\mpBusiness2\\</Item>");
                Console.WriteLine("		<Item>platform:\\dlcPacks\\mpHipster\\</Item>");
                Console.WriteLine("		<Item>platform:\\dlcPacks\\mpIndependence\\</Item>");
                Console.WriteLine("		<Item>platform:\\dlcPacks\\mpPilot\\</Item>");
                Console.WriteLine("		<Item>platform:\\dlcPacks\\spUpgrade\\</Item>");
                Console.WriteLine("		<Item>platform:\\dlcPacks\\mpLTS\\</Item>");             
                System.IO.File.WriteAllLines("list.xml", allFolders);
                //string[] dlcList = ;

            Console.ReadLine();

        }
    }



}
