using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Text;


namespace DLC_List_Generator_by_Frazzlee
{   
    class Program
    {

        public static object exactnamearray { get; private set; }

        [STAThread]
        static void Main(string[] args)
        {
            

            //Variables
            string half1 = @"		<Item>dlcpacks:\";
            string half2 = @"\</Item>";
            var config = new IniFile("Config.ini");
            string gamePath = config.Read("gamePath");
            string xmlLoc = "dlclist.xml";

            if (!Directory.Exists(gamePath))
            { 
                Console.WriteLine(gamePath);
                Console.WriteLine("Directory does not exist");
                Console.ReadLine();
            }
            if(config.Read("getFrommods") == "False")
            {
                config.DeleteKey("getFrom");
                config.Write("getFrom", gamePath + @"\update\x64\dlcpacks");
            }
            else if (config.Read("getFrommods") == "True")
            {
                config.DeleteKey("getFrom");
                config.Write("getFrom", gamePath + @"\mods\update\x64\dlcpacks");
            }
            string directory = config.Read("getFrom");
            config.DeleteKey("getFrom");



                //Getting foldernames here and everything to do with folders and gettings names/paths
                string[] allFolders = Directory.EnumerateDirectories(directory)
            .Select(d => new DirectoryInfo(d).Name).ToArray();


            File.WriteAllText(xmlLoc, @"<?xml version=""1.0"" encoding=""UTF-8""?>
<SMandatoryPacksData>
	<Paths>
		<Item>dlcpacks:\rdrcloud\</Item>
		<Item>platform:\dlcPacks\mpBeach\</Item>
		<Item>platform:\dlcPacks\mpBusiness\</Item>
		<Item>platform:\dlcPacks\mpChristmas\</Item>
		<Item>platform:\dlcPacks\mpValentines\</Item>
		<Item>platform:\dlcPacks\mpBusiness2\</Item>
		<Item>platform:\dlcPacks\mpHipster\</Item>
		<Item>platform:\dlcPacks\mpIndependence\</Item>
		<Item>platform:\dlcPacks\mpPilot\</Item>
		<Item>platform:\dlcPacks\spUpgrade\</Item>
		<Item>platform:\dlcPacks\mpLTS\</Item>
");


            foreach (string folder in allFolders)
            {
                File.AppendAllText(xmlLoc, half1 + folder + half2);
                File.AppendAllText(xmlLoc, Environment.NewLine);
            }

            File.AppendAllText(xmlLoc, @"	</Paths>
</ SMandatoryPacksData > ");

            if (config.Read("copyToClipboard") == "True")
            {
                string clipboard = File.ReadAllText("dlclist.xml");
                Clipboard.SetText(clipboard);
            }




        }
    }



}
