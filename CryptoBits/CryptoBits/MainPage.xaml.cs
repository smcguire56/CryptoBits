using System;
using System.Collections.Generic;
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
            textBlock.Text = "test";
            max = 10;
            count = 0;
        }
    }
}
