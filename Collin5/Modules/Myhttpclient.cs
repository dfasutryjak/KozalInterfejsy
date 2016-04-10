using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Collin5.Modules
{
    class Myhttpclient
    {
        public static async Task <string> DownloadPageAsync(string URL)
        {
            string page = URL;
            byte[] result;
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
              
            {
                result = await content.ReadAsByteArrayAsync();
            }
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding iso = Encoding.GetEncoding("ISO-8859-2");
            return iso.GetString(result);
        }
    }
}
