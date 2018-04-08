using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace CryptoBits
{
    public sealed partial class MainPage : Page
    {
        public int count = 0;
        public int max = 100;
        public int notificationCounter = 0;

        ObservableCollection<string> listItems = new ObservableCollection<string>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        public object JsonConvert { get; private set; }

        private async void button_Click(object sender, RoutedEventArgs e)
        {

            RootObject myCoin = await CoinProxy.getCoin();

            textBlock.Text = "Displaying coins...";
            while (count <= (max - 1))
            {

                //textBlock.Text += "\nCoin: " + (count + 1) + " name: " + myCoin.ico.finished[count].name + " Description: " + myCoin.ico.finished[count].description + " Price: " + myCoin.ico.finished[count].price_usd;
                // Create a new ListView and add content. 
                listItems.Add("\nCoin: " + (count + 1) + "\nname: " + myCoin.ico.finished[count].name + "\nPrice: " + myCoin.ico.finished[count].price_usd + "\nDescription: " + myCoin.ico.finished[count].description );

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

        private async void button_Click3(object sender, RoutedEventArgs e)
        {

            RootObject myCoin = await CoinProxy.getCoin();

            ShowToastNotification(myCoin.ico.upcoming[notificationCounter].name, myCoin.ico.upcoming[notificationCounter].description);
            notificationCounter++;
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

        private async void send(object sender, RoutedEventArgs e)
        {
            var contactPicker = new Windows.ApplicationModel.Contacts.ContactPicker();

            contactPicker.DesiredFieldsWithContactFieldType.Add(Windows.ApplicationModel.Contacts.ContactFieldType.Email);

            Contact contact = await contactPicker.PickContactAsync();

            if (contact != null)
            {
                name.Text = contact.DisplayName;
            }
            else
            {
                name.Text = "Sent";

            }
        }

        private async Task ComposeEmail(Windows.ApplicationModel.Contacts.Contact recipient, string subject, string messageBody)
        {
            var emailMessage = new Windows.ApplicationModel.Email.EmailMessage();
            emailMessage.Body = messageBody;

            var email = recipient.Emails.FirstOrDefault<Windows.ApplicationModel.Contacts.ContactEmail>();
            if (email != null)
            {
                var emailRecipient = new Windows.ApplicationModel.Email.EmailRecipient(email.Address);
                emailMessage.To.Add(emailRecipient);
                emailMessage.Subject = subject;
            }

            await Windows.ApplicationModel.Email.EmailManager.ShowComposeNewEmailAsync(emailMessage);
        }

    }
}
