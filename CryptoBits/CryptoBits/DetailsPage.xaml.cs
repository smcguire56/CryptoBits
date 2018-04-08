using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CryptoBits
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Details_age : Page
    {
        public Details_age()
        {
            this.InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            int max = 200;
            ObservableCollection<string> listItems = new ObservableCollection<string>();


            RootObject myCoin = await CoinProxy.getCoin();

            while (count <= (max - 1))
            {

                listItems.Add("\nCoin: " + (count + 1) + "\n name: " + myCoin.ico.finished[count].name + "\n Description: " + myCoin.ico.finished[count].description + "\n Price: " + myCoin.ico.finished[count].price_usd
                    + "\n URL: " + myCoin.ico.finished[count].icowatchlist_url + "\n Start time: " + myCoin.ico.finished[count].start_time + "\n Website: " + myCoin.ico.finished[count].website_link);

                count++;
            }
            // Create a new list view, add content, 
            ListView itemListView = new ListView();
            itemListView.ItemsSource = listItems;
            stackPanel1.Children.Add(itemListView);

            count = 0;
        }

        private async void button_Click2(object sender, RoutedEventArgs e)
        {
            int count = 0;
            int max = 90;
            ObservableCollection<string> listItems2 = new ObservableCollection<string>();


            RootObject myCoin = await CoinProxy.getCoin();

            while (count <= (max - 1))
            {

                listItems2.Add("\nCoin: " + (count + 1) + "\n name: " + myCoin.ico.live[count].name + "\n Description: " + myCoin.ico.live[count].description + "\n timezone: " + myCoin.ico.live[count].timezone
                    + "\n URL: " + myCoin.ico.live[count].icowatchlist_url + "\n Start time: " + myCoin.ico.live[count].start_time + "\n Website: " + myCoin.ico.live[count].website_link);

                count++;
            }
            // Create a new list view, add content, 
            ListView itemListView = new ListView();
            itemListView.ItemsSource = listItems2;
            stackPanel1.Children.Add(itemListView);
        }

        private async void button_Click3(object sender, RoutedEventArgs e)
        {
            int count = 0;
            int max = 50;
            ObservableCollection<string> listItems = new ObservableCollection<string>();


            RootObject myCoin = await CoinProxy.getCoin();

            while (count <= (max - 1))
            {

                listItems.Add("\nCoin: " + (count + 1) + "\n name: " + myCoin.ico.upcoming[count].name + "\n Description: " + myCoin.ico.upcoming[count].description + "\n Timezone: " + myCoin.ico.upcoming[count].timezone
                    + "\n URL: " + myCoin.ico.upcoming[count].icowatchlist_url + "\n Start time: " + myCoin.ico.upcoming[count].start_time + "\n Website: " + myCoin.ico.upcoming[count].website_link);

                count++;
            }
            // Create a new list view, add content, 
            ListView itemListView = new ListView();
            itemListView.ItemsSource = listItems;
            stackPanel1.Children.Add(itemListView);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
            this.Frame.Navigate(typeof(Details_age));

        }
    }
}
