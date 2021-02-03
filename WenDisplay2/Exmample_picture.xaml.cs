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
using System.Windows.Threading;

namespace WenDisplay2
{
    /// <summary>
    /// Exmample_picture.xaml 的互動邏輯
    /// </summary>
    public partial class Exmample_picture : Window
    {
        int malecheck = 0;
        int agecheck = 0;
        string namecheck;
        string workerid;
        string examinerid;
        int member = 0;
        int start = 0;
        int TipCheck;//檢查動作編號
        
        DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
        public Exmample_picture(int testmalecheck, int testagecheck, string testname, string id, string id2, int modecheck, int Tip)
        {
            InitializeComponent();
            malecheck = testmalecheck;
            agecheck = testagecheck;
            namecheck = testname;
            workerid = id;
            examinerid = id2;
            member = modecheck;
            TipCheck = Tip;

            if (Tip == 3)//椅子坐立立
            {
                Tip1.Content = "檢測30秒內起立、坐下的次數，算一次";
                Tip_picture1.Visibility = Visibility.Visible;
                start = 5;
                timer.Tick += timer_Tick;
                timer.Start();

            }
            else if (Tip == 4)//抬手一般模式
            {
                Tip1.Content = "檢測30秒內，抬手、放下的次數，算一次";
                Tip_picture2.Visibility = Visibility.Visible;
                start = 5;
                timer.Tick += timer_Tick;
                timer.Start();
            }
            else if (Tip == 9)//抬手右手模式
            {
                Tip1.Content = "檢測30秒內，右手抬手、右手放下的次數，算一次";
                Tip_picture7.Visibility = Visibility.Visible;
                start = 5;
                timer.Tick += timer_Tick;
                timer.Start();
            }
            else if (Tip == 10)//抬手左手模式
            {
                Tip1.Content = "檢測30秒內，左手抬手、左手放下的次數，算一次";
                Tip_picture8.Visibility = Visibility.Visible;
                start = 5;
                timer.Tick += timer_Tick;
                timer.Start();
            }
            else if (Tip == 5)//抬膝一般模式
            {
                Tip1.Content = "檢測60秒內，完成踏步次數，左右腳抬起各算一次";
                Tip_picture3.Visibility = Visibility.Visible;
                start = 5;
                timer.Tick += timer_Tick;
                timer.Start();
            }
            else if (Tip == 11)//抬膝右腳模式
            {
                Tip1.Content = "檢測60秒內，完成踏步次數，右腳抬起算一次";
                Tip_picture9.Visibility = Visibility.Visible;
                start = 5;
                timer.Tick += timer_Tick;
                timer.Start();
            }
            else if (Tip == 12)//抬膝左腳模式
            {
                Tip1.Content = "檢測60秒內，完成踏步次數，左腳抬起算一次";
                Tip_picture10.Visibility = Visibility.Visible;
                start = 5;
                timer.Tick += timer_Tick;
                timer.Start();
            }
            else if (Tip == 6)
            {
                Tip1.Content = "檢測椅子坐立繞物，繞過障礙物，回椅子坐好";
                Tip_picture4.Visibility = Visibility.Visible;
                start = 5;
                timer.Tick += timer_Tick;
                timer.Start();
            }
            else if (Tip == 7)//二頭肌右手
            {
                Tip1.Content = "檢測30秒內，右手抬起放下算一次的次數(手稍微向外)";
                Tip_picture5.Visibility = Visibility.Visible;
                start = 5;
                timer.Tick += timer_Tick;
                timer.Start();
            }
            else if (Tip == 13)//二頭肌左手
            {
                Tip1.Content = "檢測30秒內，左手抬起放下算一次的次數(手稍微向外)";
                Tip_picture11.Visibility = Visibility.Visible;
                start = 5;
                timer.Tick += timer_Tick;
                timer.Start();
            }
            else if (Tip == 8)//右腳模式
            {
                Tip1.Content = "單腳站立，右腳抬起開始計算時間，放下計算結束";
                Tip_picture6.Visibility = Visibility.Visible;
                start = 5;
                timer.Tick += timer_Tick;
                timer.Start();
            }
            else if (Tip == 14)//左腳模式
            {
                Tip1.Content = "單腳站立，左腳抬起開始計算時間，放下計算結束";
                Tip_picture12.Visibility = Visibility.Visible;
                start = 5;
                timer.Tick += timer_Tick;
                timer.Start();
            }

        }

        private void Button_Click18(object sender, RoutedEventArgs e)
        {
            testnormal w = new testnormal(malecheck, agecheck, namecheck, workerid, examinerid, member);
            this.Close();
            timer.Stop();
            w.Show();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (start == 10)
            {
            }
            start--;
            if (start == 0 && TipCheck == 14)//單足立 左腳
            {
                test6 w = new test6(malecheck, agecheck, namecheck, 2, workerid, examinerid, member);
                this.Close();
                w.Show();
                timer.Stop();
            }
            if (start == 0 && TipCheck == 8)//單足立 右腳
            {
                test6 w = new test6(malecheck, agecheck, namecheck, 1, workerid, examinerid, member);
                this.Close();
                w.Show();
                timer.Stop();
            }
            if (start == 0 && TipCheck == 13)//二頭肌 左手
            {
                test5 w = new test5(malecheck, agecheck, namecheck, 2, workerid, examinerid, member);
                this.Close();
                w.Show();
                timer.Stop();
            }
            if (start == 0 && TipCheck == 7)//二頭肌 右手
            {
                test5 w = new test5(malecheck, agecheck, namecheck, 1, workerid, examinerid, member);
                this.Close();
                w.Show();
                timer.Stop();
            }
            if (start == 0 && TipCheck == 6)//繞物
            {
                test4 w = new test4(malecheck, agecheck, namecheck,  workerid, examinerid, member);
                this.Close();
                w.Show();
                timer.Stop();
            }
            if (start == 0 && TipCheck == 12)//抬膝 右腳
            {
                test3 w = new test3(malecheck, agecheck, namecheck, 2, workerid, examinerid, member);
                this.Close();
                w.Show();
                timer.Stop();
            }
            if (start == 0 && TipCheck == 11)//抬膝 右腳
            {
                test3 w = new test3(malecheck, agecheck, namecheck, 1, workerid, examinerid, member);
                this.Close();
                w.Show();
                timer.Stop();
            }
            if (start == 0 && TipCheck == 5)//抬膝 一般
            {
                test3 w = new test3(malecheck, agecheck, namecheck, 0, workerid, examinerid, member);
                this.Close();
                w.Show();
                timer.Stop();
            }
            if (start == 0 && TipCheck == 10)//舉手一般 左手
            {
                test2 w = new test2(malecheck, agecheck, namecheck, 2, workerid, examinerid, member);
                this.Close();
                w.Show();
                timer.Stop();
            }
            if (start == 0 && TipCheck == 9)//舉手一般 右手
            {
                test2 w = new test2(malecheck, agecheck, namecheck, 1, workerid, examinerid, member);
                this.Close();
                w.Show();
                timer.Stop();
            }
            if (start == 0&& TipCheck == 4)//舉手一般
            {
                test2 w = new test2(malecheck, agecheck, namecheck, 0, workerid, examinerid, member);
                this.Close();
                w.Show();
                timer.Stop();
            }
            if (start == 0 && TipCheck == 3)//椅子坐立
            {
                test1 w = new test1(malecheck, agecheck, namecheck, workerid, examinerid, member);
                this.Close();
                w.Show();
                timer.Stop();
            }


        }
    }
}
