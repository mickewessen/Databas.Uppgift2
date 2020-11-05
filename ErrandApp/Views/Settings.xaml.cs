using ErrandApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ErrandApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Settings : Page
    {
        private static SetSettings _setSettings { get; set; }

        public class SetSettings
        {
            public List<string> status { get; set; }
            public List<int> number { get; set; }
            public int maxItemsCount { get; set; }
        }

        public Settings()
        {
            this.InitializeComponent();
            LoadMaxItemAsync().GetAwaiter();        
        }

        private async Task LoadSettings()
        {
            SetSettings settingsInfo = new SetSettings()
            {
                status = new List<string>()
                {
                    "New",
                    "Active",
                    "Closed",
                },
                number = new List<int>()
                {
                    1,
                    2,
                    3,
                    4,
                    5,
                    6,
                    7,
                    8,
                    9,
                    10,
                    11,
                    12,
                    13,
                    14,
                    15
                },
                maxItemsCount = Convert.ToInt32(cmbsetmaxItemsActive.SelectedItem.ToString())                
            };
            string json = JsonConvert.SerializeObject(settingsInfo);
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile jsonsettings = await storageFolder.CreateFileAsync("settings.json", CreationCollisionOption.ReplaceExisting);

            jsonsettings = await storageFolder.GetFileAsync("settings.json");
            await FileIO.WriteTextAsync(jsonsettings, json);

            _setSettings = JsonConvert.DeserializeObject<SetSettings>(await FileIO.ReadTextAsync(jsonsettings));        
                           
        }

        public static int SetItemsMax()
        {
            return _setSettings.maxItemsCount;
        }

        private async Task LoadMaxItemAsync()
        {
            cmbsetmaxItemsActive.ItemsSource = await SettingsContext.SetMaxItemsCount();       
        }

        private void loadSettings_Click(object sender, RoutedEventArgs e)
        {
            LoadSettings().GetAwaiter();
        }
    }
}
