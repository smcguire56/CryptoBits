using System;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace CryptoBits
{
    public sealed partial class MainPage : Page
    {
        public int count = 0;
        public int max = 10;
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
                textBlock.Text += "\nCoin: " + (count + 1) + " name: " + myCoin.ico.finished[count].name + " Description: " + myCoin.ico.finished[count].description + " Price: " + myCoin.ico.finished[count].price_usd;
                count++;
            }
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
            textBlock.Text = "";
            max = 10;
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
    }
}
