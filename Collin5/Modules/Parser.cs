using Collin5.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Windows.ApplicationModel;

namespace Collin5.Modules
{

    public class Parser
    {
  

        public static async Task<ObservableCollection<current_status>> downloader(string URL)
        {
            string result = await Myhttpclient.DownloadPageAsync(URL);
            return testfunction(result);
            
        }
        //private ObservableCollection<current_status> recordings = new ObservableCollection<current_status>();
        //public ObservableCollection<current_status> Recordings { get { return this.recordings; } }

        public static ObservableCollection<current_status> testfunction(String document_xml)
        {
            ObservableCollection<current_status> tmp_currentstatus = new ObservableCollection<current_status>();

           //string peopleXMLPath = Path.Combine(Package.Current.InstalledLocation.Path, "Assets/PeopleData.xml");
            XDocument loadedData = XDocument.Parse(document_xml);
            
            var data = from query in loadedData.Descendants("pozycja")
                       select new current_status((string)query.Element("nazwa_waluty"), (string)query.Element("kod_waluty"), (string)query.Element("kurs_sredni"));             
            //listBox.ItemsSource = data;

            foreach (current_status tmp in data)
            {
                tmp_currentstatus.Add(tmp);
            }

            return tmp_currentstatus;
        }






        static void testttt(string[] args)
        {

            XmlReader xmlReader = XmlReader.Create("http://webservices.nextbus.com/service/publicXMLFeed?   command=routeConfig&a=sf-muni&r=N");
            List<string> aTitle = new List<string>();

            // Add as many as attributes you have in your "stop" element

            while (xmlReader.Read())
            {
                //keep reading until we see your element
                if (xmlReader.Name.Equals("stop") && (xmlReader.NodeType == XmlNodeType.Element))
                {
                    string title = xmlReader.GetAttribute("title");
                    aTitle.Add(title);

                    // Add code for all other attribute you would want to store in list.
                }
            }

            //String URLString = "http://www.nbp.pl/kursy/xml/a025z100205.xml";
            //XmlTextReader reader = new XmlTextReader(URLString);

            //current_status testowy = new current_status("testowa", "PLN", "3,456");
            
           


        }
    }
}
