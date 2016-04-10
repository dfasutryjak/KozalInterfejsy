using Collin5.Model;
using System.Collections.ObjectModel;
using Collin5.Modules;
using System.Threading.Tasks;
using System;
using System.Net.Http;

namespace Collin5.VModel
{
    public class RecordingViewModel
    {

        private ObservableCollection<current_status> current_status = new ObservableCollection<current_status>();
        public ObservableCollection<current_status> Current_status { get { return this.current_status; } }


       
        public static async Task <string> test_url(string URL)
        {
            //string page = URL;
            //string = "http://www.nbp.pl/kursy/xml/a068z160409.xml";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(URL);

            var response_code_tmp = response.StatusCode;
            string response_code = response_code_tmp.ToString();
            return response_code;
        }

        static DateTime GetYesterday()
        {
            double number = -1;
            return DateTime.Today.AddDays(number);
        }
        public string set_url()
        {
            
            string url="";
            string string_Datetime;
            DateTime y = GetYesterday();
            string_Datetime = y.ToString();
            string[] date = string_Datetime.Split('/');
            string day = date[0];
            string month = date[1];
            string[] tmp_year = date[2].Split(' ');
            string year = tmp_year[0];
            year =year.Remove(0,2);
            url = year + month + day + ".xml";
            string test = "http://www.nbp.pl/kursy/xml/a025z" + url;
            return "http://www.nbp.pl/kursy/xml/a025z"+url;
        }
        public RecordingViewModel()
        {
            
            test_func(set_url());
        }

        public async void test_func(string url)
        {
            var tmp_current_status= Parser.downloader("http://www.nbp.pl/kursy/xml/a025z100205.xml");
            //var tmp_current_status = Parser.downloader(url);
            await Task.Run(() => tmp_current_status);
            foreach (current_status tmp in tmp_current_status.Result)
            {
                current_status.Add(tmp);
            }  
        }
    }
}




