using System;
using System.Collections.ObjectModel;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace CryptoBits
{
    public sealed partial class MainPage : Page
    {
        public int count = 0;
        public int max = 10;
        ObservableCollection<string> listItems = new ObservableCollection<string>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        public object JsonConvert { get; private set; }

        private async void button_Click(object sender, RoutedEventArgs e)
        {

            RootObject myCoin = await CoinProxy.getCoin();

            textBlock.Text = "Displaying coins";
            while (count <= (max - 1))
            {

                //textBlock.Text += "\nCoin: " + (count + 1) + " name: " + myCoin.ico.finished[count].name + " Description: " + myCoin.ico.finished[count].description + " Price: " + myCoin.ico.finished[count].price_usd;
                // Create a new ListView and add content. 
                listItems.Add("\nCoin: " + (count + 1) + " name: " + myCoin.ico.finished[count].name + " Description: " + myCoin.ico.finished[count].description + " Price: " + myCoin.ico.finished[count].price_usd);

                count++;
            }
            // Create a new list view, add content, 
            ListView itemListView = new ListView();
            itemListView.ItemsSource = listItems;
            stackPanel1.Children.Add(itemListView);

            count = 0;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, "[^0-9]"))
            {
                textBlock.Text = "Please enter only numbers.";
                textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
            }
            else {
                max = Int32.Parse(textBox.Text);
            }
        }

        private void button_Click2(object sender, RoutedEventArgs e)
        {
            listItems.Clear();
            ListView itemListView = new ListView();
            itemListView.ItemsSource = listItems;
            stackPanel1.Children.Add(itemListView);
            count = 0;
        }

        private void button_Click3(object sender, RoutedEventArgs e)
        {
            ShowToastNotification("title", "content");
        }

        private void ShowToastNotification(string title, string stringContent)
        {
            ToastNotifier ToastNotifier = ToastNotificationManager.CreateToastNotifier();
            Windows.Data.Xml.Dom.XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            Windows.Data.Xml.Dom.XmlNodeList toastNodeList = toastXml.GetElementsByTagName("text");
            toastNodeList.Item(0).AppendChild(toastXml.CreateTextNode(title));
            toastNodeList.Item(1).AppendChild(toastXml.CreateTextNode(stringContent));
            Windows.Data.Xml.Dom.IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            Windows.Data.Xml.Dom.XmlElement audio = toastXml.CreateElement("audio");
            audio.SetAttribute("src", "ms-winsoundevent:Notification.SMS");

            ToastNotification toast = new ToastNotification(toastXml);
            toast.ExpirationTime = DateTime.Now.AddSeconds(4);
            ToastNotifier.Show(toast);
        }

        private void listView1_ItemClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Details_age));

        }
    }
}
