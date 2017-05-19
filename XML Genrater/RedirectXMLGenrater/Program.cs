using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication
{
    public class URLPARTS
    {
        public string URLHOST = string.Empty;
        public string URLPATH = string.Empty;
        public string QueryString = string.Empty;
        public Dictionary<string, string> QueryStringlist = new Dictionary<string, string>();
    }
    class Program
    {
        static void Main(string[] args)
        {
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
                List<Uri> AllSourceUrl = File.ReadAllLines(Sourcepath).Select(x => new Uri(x)).ToList();
                List<string> AlldDesteUrl = File.ReadAllLines(Destinationpath).ToList();
                Dictionary<URLPARTS, string> URLMap = new Dictionary<URLPARTS, string>();
                for (int i = 0; i < AlldDesteUrl.Count; i++)
                {
                    URLPARTS _URLPARTS = new URLPARTS();
                    _URLPARTS.URLHOST = AllSourceUrl[i].Host;
                    _URLPARTS.URLPATH = AllSourceUrl[i].AbsolutePath;

                    if (AllSourceUrl[i].ToString().Contains('&') && AllSourceUrl[i].ToString().Contains('=') && AllSourceUrl[i].ToString().Contains('?'))
                        _URLPARTS.QueryStringlist = AllSourceUrl[i].Query.Remove(0, 1).Split('&').Select(part => part.Split('=')).ToDictionary(split => split[0], split => split[1]);
                    if (AllSourceUrl[i].ToString().Contains('?'))
                        _URLPARTS.QueryString = AllSourceUrl[i].Query.Remove(0, 1);
                    URLMap.Add(_URLPARTS, AlldDesteUrl[i]);
                }


                if (AlldDesteUrl.Count == AllSourceUrl.Count)
                {
                    Console.WriteLine("Files Read Successfully Now Url Generation Is Began");
                    try
                    {
                        //AllSourceUrl = AllSourceUrl.Select(ASU => ASU.Remove(0, 1)).ToList();
                        //AlldDesteUrl = AlldDesteUrl.Select(ASU => ASU.Remove(0, 25)).ToList();
                        //var count = 0;
                        //foreach (var a in AlldDesteUrl)
                        //{
                        //    try
                        //    {
                        //        a.Remove(0, 25);
                        //        count++;
                        //    }
                        //    catch
                        //    {
                        //        var b = a;
                        //        var c = count;
                        //    }
                        //}

                        //genrateXML(AllSourceUrl, AlldDesteUrl);


                        int totalcount = 0;
                        for (int i = 0; i < AlldDesteUrl.Count; i++)
                        {

                            if (URLMap.Keys.ElementAt(i).ToString().StartsWith("http://"))
                            {
                                totalcount++;
                                //File.AppendAllText(Output, genrateXML(URLMap.Keys.ElementAt(i), URLMap.Values.ElementAt(i)) + Environment.NewLine);

                            }
                        }


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
        public HttpStatusCode GetHeaders(string url)
        {
            HttpStatusCode result = default(HttpStatusCode);

            var request = HttpWebRequest.Create(url);
            request.Method = "HEAD";
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                if (response != null)
                {
                    result = response.StatusCode;
                    response.Close();
                }
            }

            return result;
        }

        private static string genrateXML(string AllSourceUrl, string AlldDesteUrl)
        {

            XmlDocument xmlDoc = new XmlDocument();

            XmlNode Rule = xmlDoc.CreateElement("rule");
            xmlDoc.AppendChild(Rule);

            XmlAttribute Name = xmlDoc.CreateAttribute("name");
            Name.Value = "redirect " + AllSourceUrl + " To " + AlldDesteUrl;
            Rule.Attributes.Append(Name);

            XmlAttribute Enabled = xmlDoc.CreateAttribute("enabled");
            Enabled.Value = "true";
            Rule.Attributes.Append(Enabled);

            XmlAttribute stopProcessing = xmlDoc.CreateAttribute("stopProcessing");
            stopProcessing.Value = "true";
            Rule.Attributes.Append(stopProcessing);

            XmlNode Match = xmlDoc.CreateElement("match");
            XmlAttribute Url = xmlDoc.CreateAttribute("url");
            Url.Value = AllSourceUrl;
            Match.Attributes.Append(Url);
            Rule.AppendChild(Match);

            XmlNode Action = xmlDoc.CreateElement("action");

            XmlAttribute type = xmlDoc.CreateAttribute("type");
            XmlAttribute ActionUrl = xmlDoc.CreateAttribute("url");
            XmlAttribute redirectType = xmlDoc.CreateAttribute("redirectType");

            type.Value = "Redirect";
            ActionUrl.Value = AlldDesteUrl;
            redirectType.Value = "Permanent";

            Action.Attributes.Append(type);
            Action.Attributes.Append(ActionUrl);
            Action.Attributes.Append(redirectType);

            Rule.AppendChild(Action);

            return xmlDoc.OuterXml;
        }
    }
}
