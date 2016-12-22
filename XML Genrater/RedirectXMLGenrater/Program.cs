using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = false;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\URL Collection";
            string Sourcepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\URL Collection\FromURLS.txt";
            string Destinationpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\URL Collection\ToURLS.txt";
            string Output = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\URL Collection\output.xml";

            Directory.CreateDirectory(path);
            //File.Create(Sourcepath);
            //File.Create(Destinationpath);

            Console.WriteLine(("There Is a folder in Your Desktop \"URL Collection\" Please Create Two TEXT FIle named FromURLS.txt & ToURLS.txt with you all URL For Genrate XML").ToUpper());
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Press Y For proceed ");
            char ans = Console.ReadKey().KeyChar;
            if (ans == 'y' || ans == 'Y')
            {
                Console.WriteLine("");
                Console.WriteLine("KaBOOM...!");
                List<string> AllSourceUrl = File.ReadAllLines(Sourcepath).ToList();
                List<string> AlldDesteUrl = File.ReadAllLines(Destinationpath).ToList();
                if (AlldDesteUrl.Count == AllSourceUrl.Count)
                {
                    Console.WriteLine("Files Read Successfully Now Url Generation Is Began");
                    try
                    {
                        AllSourceUrl = AllSourceUrl.Select(ASU => ASU.Remove(0, 1)).ToList();
                        AlldDesteUrl = AlldDesteUrl.Select(ASU => ASU.Remove(0, 22)).ToList();

                        //genrateXML(AllSourceUrl, AlldDesteUrl);

                        for (int i = 0; i < AlldDesteUrl.Count; i++)
                        {
                            File.AppendAllText(Output, genrateXML(AllSourceUrl[i], AlldDesteUrl[i]) + Environment.NewLine);
                        }
                        flag = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                    }

                }
                else
                {
                    Console.WriteLine("URL count are miss match");
                }
            }
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Thats It From My Side go Get A Life and Press # for Exit");
            while (true)
            {
                char Exit = Console.ReadKey().KeyChar;
                if (Exit == '#')
                {
                    return;
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Press # not " + Exit);
                }
            }
        }

        private static string genrateXML(string AllSourceUrl, string AlldDesteUrl)
        {

            XmlDocument xmlDoc = new XmlDocument();

            XmlNode Rule = xmlDoc.CreateElement("Rule");
            xmlDoc.AppendChild(Rule);

            XmlAttribute Name = xmlDoc.CreateAttribute("Name");
            Name.Value = "redirect " + AllSourceUrl + " To " + AlldDesteUrl;
            Rule.Attributes.Append(Name);

            XmlAttribute Enabled = xmlDoc.CreateAttribute("Enabled");
            Enabled.Value = "true";
            Rule.Attributes.Append(Enabled);

            XmlAttribute stopProcessing = xmlDoc.CreateAttribute("stopProcessing");
            stopProcessing.Value = "true";
            Rule.Attributes.Append(stopProcessing);

            XmlNode Match = xmlDoc.CreateElement("Match");
            XmlAttribute Url = xmlDoc.CreateAttribute("Url");
            Url.Value = "(.*)" + AllSourceUrl;
            Match.Attributes.Append(Url);
            Rule.AppendChild(Match);

            XmlNode Action = xmlDoc.CreateElement("Action");

            XmlAttribute type = xmlDoc.CreateAttribute("type");
            XmlAttribute ActionUrl = xmlDoc.CreateAttribute("Url");
            XmlAttribute redirectType = xmlDoc.CreateAttribute("redirectType");

            type.Value = "Redirect";
            ActionUrl.Value = "{R:1}" + AlldDesteUrl;
            redirectType.Value = "Permanent";

            Action.Attributes.Append(type);
            Action.Attributes.Append(ActionUrl);
            Action.Attributes.Append(redirectType);

            Rule.AppendChild(Action);

            return xmlDoc.OuterXml;
        }
    }
}
