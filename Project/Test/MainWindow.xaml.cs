using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Test
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConverWord_Click(object sender, RoutedEventArgs e)
        {
            ConverToWord.Content= GetConverWord(InputWord.Text);
        }
        private void ConverString_Click(object sender, RoutedEventArgs e)
        {
            string converString = "";
            List<string> _list = InputString.Text.Split(' ').ToList();
            foreach (string _s in _list)
            {
                converString += GetConverWord(_s) + " ";
            }
            ConverToString.Content = converString.Substring(0, converString.Length - 1);
        }
        private string GetConverWord(string word) {
            string converWord = "";
            if (!string.IsNullOrEmpty(word))
            {
                for (int iCount = 0; iCount < word.Length; iCount++)
                {
                    converWord += word.Substring(word.Length - 1-iCount, 1);
                }
            }
            return converWord;
        }
        private bool IsAdd(int number) {
            bool isAdd = true;
            bool is3 = false;
            bool is5 = false;
            if (number % 3 == 0) is3 = true;
            if (number % 5 == 0) is5 = true;
            if (is3 && !is5) isAdd = false;
            if (!is3 && is5) isAdd = false;
            return isAdd;
        }

        private void CountNumber_Click(object sender, RoutedEventArgs e)
        {
            int number = 0;
            int count = 0;
            if (int.TryParse(InputNumber.Text, out number)) {
                for (int iCount = 1; iCount <= number; iCount++) {
                    if (IsAdd(iCount)) count += 1;
                }
            }
            if (count == 0)
            {
                CountResult.Content = "";
            }
            else {
                CountResult.Content = count;
            }
        }
    }
}
