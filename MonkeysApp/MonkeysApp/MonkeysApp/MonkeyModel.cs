using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;

namespace MonkeysApp
{
    public class MonkeyModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public string Image { get; set; }
        public int Population { get; set; }
    }

    public class MonkeyViewModel
    {
        private ObservableCollection<MonkeyModel> monkeys = null;
        public ObservableCollection<MonkeyModel> Monkeys
        {
            get
            {
                if (monkeys == null)
                    monkeys = new ObservableCollection<MonkeyModel>();

                return monkeys;
            }
        }

        public async Task GetMonkeysAsync()
        {
            try
            {
                var client = new HttpClient();
                var json = await client.GetStringAsync("http://montemagno.com/monkeys.json");

                var items = JsonConvert.DeserializeObject<List<MonkeyModel>>(json);

                foreach (var item in items)
                    Monkeys.Add(item);
            }
            catch (Exception ex) 
            {

                Debug.WriteLine(ex);
            }

        }
    }

}
