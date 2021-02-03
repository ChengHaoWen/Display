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
    /// testnormal.xaml 的互動邏輯
    /// </summary>
    public partial class testnormal : Window
    {
        int a = 0;
        int malecheck_01;
        int argcheck_01;
        string workerid;
        string line;
        string name_01;
        string examinerid;
        int member = 0;        
        public testnormal(int malecheck01,int argcheck01,string name01,string id,string id2,int modecheck)
        {
            malecheck_01=malecheck01;
            argcheck_01 = argcheck01;
            workerid = id;
            examinerid = id2;
            name_01 = name01;
            member = modecheck;
            
            InitializeComponent();
            Namedisplay.Content = "測量者姓名:"+name_01;
        }

        private void Button_Click(object sender, RoutedEventArgs e)//30秒坐立
        {
            a = 1;
            Exmample_picture w = new Exmample_picture(malecheck_01, argcheck_01, name_01, workerid, examinerid, member, 3);
            this.Close();
            w.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//30秒手臂屈舉測量一般
        {
            a = 1;
            Exmample_picture w = new Exmample_picture(malecheck_01, argcheck_01, name_01, workerid, examinerid, member, 4);
            this.Close();
            w.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)//30秒手臂屈舉測量右手
        {
            a = 1;
            Exmample_picture w = new Exmample_picture(malecheck_01, argcheck_01, name_01, workerid, examinerid, member, 9);
            this.Close();
            w.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)//30秒手臂屈舉測量左手
        {
            a = 1;
            Exmample_picture w = new Exmample_picture(malecheck_01, argcheck_01, name_01, workerid, examinerid, member, 10);
            this.Close();
            w.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)//2分鐘站立抬膝測量一般
        {
            a = 1;
            Exmample_picture w = new Exmample_picture(malecheck_01, argcheck_01, name_01, workerid, examinerid, member, 5);
            this.Close();
            w.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//2分鐘站立抬膝測量右腳
        {
            a = 1;
            Exmample_picture w = new Exmample_picture(malecheck_01, argcheck_01, name_01, workerid, examinerid, member, 11);
            this.Close();
            w.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)//2分鐘站立抬膝測量左腳
        {
            a = 1;
            Exmample_picture w = new Exmample_picture(malecheck_01, argcheck_01, name_01, workerid, examinerid, member, 12);
            this.Close();
            w.Show();
        }

        private void Button_Click7(object sender, RoutedEventArgs e)//繞物測驗
        {
            a = 1;
            Exmample_picture w = new Exmample_picture(malecheck_01, argcheck_01, name_01, workerid, examinerid, member, 6);
            this.Close();
            w.Show();

        }

        private void Button_Click8(object sender, RoutedEventArgs e)//30秒二頭肌手臂屈舉測量 右手
        {
            a = 1;
            Exmample_picture w = new Exmample_picture(malecheck_01, argcheck_01, name_01, workerid, examinerid, member, 7);
            this.Close();
            w.Show();
        }
        private void Button_Click9(object sender, RoutedEventArgs e)//30秒二頭肌手臂屈舉測量 左手
        {
            a = 1;
            Exmample_picture w = new Exmample_picture(malecheck_01, argcheck_01, name_01, workerid, examinerid, member, 13);
            this.Close();
            w.Show();

        }



        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            a = 1;
            Exmample_picture w = new Exmample_picture(malecheck_01, argcheck_01, name_01, workerid, examinerid, member, 8);
            this.Close();
            w.Show();
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            a = 1;
            Exmample_picture w = new Exmample_picture(malecheck_01, argcheck_01, name_01, workerid, examinerid, member, 14);
            this.Close();
            w.Show();
        }

        private void Button_Click18(object sender, RoutedEventArgs e)
        {
            a = 1;
            first w = new first();
            this.Close();
            w.Show();
        }

       /* private void Button_Click12(object sender, RoutedEventArgs e)//動作提示
        {
            a = 1;
            Exmample_picture w = new Exmample_picture(malecheck_01, argcheck_01, name_01, workerid, examinerid, member,3);
            this.Close();
            w.Show();
        }*/

       

       

        

        

      
    }
}
