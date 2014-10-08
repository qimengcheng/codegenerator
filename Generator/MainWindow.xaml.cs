using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Generator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private string GeneratePassword(string mac)
        {
            SHA256Managed en = new SHA256Managed();
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(mac);
            byteArray = en.ComputeHash(byteArray);

            string password = Math.Abs(BitConverter.ToInt32(byteArray, 0) % 999999).ToString();
            if (password.Length < 6)
            {
                password = ("00000" + password).Substring(password.Length - 1, 6);
            }
            return password;

        }  

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            string text = Mac.Text + Append.Text;
            pass.Content = GeneratePassword(text);
            pass.Visibility = Visibility;
        }
    }
}
