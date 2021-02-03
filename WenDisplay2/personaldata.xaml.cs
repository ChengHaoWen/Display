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
using System.Windows.Shapes;

namespace WenDisplay2
{
    /// <summary>
    /// personaldata.xaml 的互動邏輯
    /// </summary>
    public partial class personaldata : Window
    {
        int a = 0;
        int malecheck = 0;
        int agecheck = 0;
        string namecheck;
        public personaldata()
        {
            InitializeComponent();
           
        }
        

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (a != 1)
                Application.Current.Shutdown();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            a = 1;
            first w = new first();
            this.Close();
            w.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            namecheck= name.Text;
            if (boy.IsChecked == true)
            {
                malecheck = 1;
            }
            if (girl.IsChecked == true)
            {
                malecheck = 2;
            }
            if (sixty.IsChecked == true)
            {
                agecheck = 1;
            }
            if (sixtyfive.IsChecked == true)
            {
                agecheck = 2;
            }
            if (seventy.IsChecked == true)
            {
                agecheck = 3;
            }
            if (seventyfive.IsChecked == true)
            {
                agecheck = 4;
            }
            if (eighty.IsChecked == true)
            {
                agecheck = 5;
            }
            if (eightyfive.IsChecked == true)
            {
                agecheck = 6;
            }
            if (ninty.IsChecked == true)
            {
                agecheck = 7;
            }


            a = 1;
            testnormal w = new testnormal(malecheck, agecheck, namecheck, "0", "0", 0);
            this.Close();
            w.Show();
        }
    }
}
