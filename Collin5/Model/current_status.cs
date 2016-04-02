using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.UI.Xaml.Shapes;
using System.Xml.Linq;
using System.Xml;
using System.IO;

namespace Collin5.Model
{
    public class current_status
    {
        private string currency_name;
        private string currency_code;
        private string currency_avg;

        public current_status() { }
        public current_status(string name, string cur_code, string cur_avg)
        {
            this.currency_name = name;
            this.currency_code = cur_code;
            this.currency_avg = cur_avg;
        }

        public string OneLineSummary
        {
            get
            {
                return this.currency_name + "\t" + this.currency_code + "\t" + this.currency_avg;
            }
        }
        public string Name
        {
            get
            {
                return currency_name;
            }
        }
        public string Avg
        {
            get
            {
                return currency_avg;
            }
        }
        public string Code
        {
            get
            {
                return currency_code;
            }
        }


    }

}
