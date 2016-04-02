using Collin5.Model;
using System.Collections.ObjectModel;
using Collin5.Modules;
using System.Threading.Tasks;

namespace Collin5.VModel
{
    public class RecordingViewModel
    {

        private ObservableCollection<current_status> current_status = new ObservableCollection<current_status>();
        public ObservableCollection<current_status> Current_status { get { return this.current_status; } }
       
        public RecordingViewModel()
        {
            //current_status= Parser.testfunction("http://www.nbp.pl/kursy/xml/a025z100205.xml");
            test_func();
        }

        public async void test_func()
        {
            //await Parser.downloader("http://www.nbp.pl/kursy/xml/a025z100205.xml");
            var tmp_current_status= Parser.downloader("http://www.nbp.pl/kursy/xml/a025z100205.xml");
            await Task.Run(() => tmp_current_status);
            foreach (current_status tmp in tmp_current_status.Result)
            {
                current_status.Add(tmp);
            }
            //current_status = tmp_current_status.Result;
        }
    }
}




