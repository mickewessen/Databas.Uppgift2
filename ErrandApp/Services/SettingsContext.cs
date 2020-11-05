using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ErrandApp.Services
{
    public static class SettingsContext
    {
        private static Settings _settings { get; set; }

        public class Settings
        {
            public int maxItemsCount { get; set; }
            public string[] status { get; set; }
            public int[] number { get; set; }
        }

        public static async void JsonSettings()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile jsonsettings = await storageFolder.CreateFileAsync("settings.json", CreationCollisionOption.ReplaceExisting);

            jsonsettings = await storageFolder.GetFileAsync("settings.json");
            await FileIO.WriteTextAsync(jsonsettings, "{\"status\": [\"New\", \"Active\", \"Closed\"], " +
                "\"number\": [\"1\",\"2\",\"3\",\"4\",\"5\",\"6\",\"7\",\"8\",\"9\",\"10\", \"11\", \"12\", \"13\", \"14\", \"15\"]," +
                " \"maxItemsCount\": 10}");

            _settings = JsonConvert.DeserializeObject<Settings>(await FileIO.ReadTextAsync(jsonsettings));
        }

        public static IEnumerable<string> NewGetStatus()
        {
            var list = new List<string>();

            foreach (var status in _settings.status)
            {
                list.Add(status);
            }
            return list;
        }

        public static async Task<IEnumerable<int>> SetMaxItemsCount()
        {
            var list = new List<int>();

            foreach (var number in _settings.number)
            {
                list.Add(number);
            }
            return list;
        }

        public static int MaxItemsCount()
        {
            return _settings.maxItemsCount;
        }

    }
}
