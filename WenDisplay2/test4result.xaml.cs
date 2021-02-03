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
using MySql.Data.MySqlClient;

namespace WenDisplay2
{
    /// <summary>
    /// test4result.xaml 的互動邏輯
    /// </summary>
    public partial class test4result : Window
    {
        int a = 0;
        string line;
        string workerid;
        string examinerid;
        int member = 0;
        string namecheckname;
        int agecheck;
        int yzmcheck;
        System.DateTime currentTime = new System.DateTime();//自動取得時間
        string strT;
        string strT2;
        string strT1;

        int age_check2;
        int malecheck2;
        string namecheck2;

        public test4result(int yzm, int malecheck, int agecheck_int, string id, string id2, int modecheck, string namecheck)
        {
            InitializeComponent();

            workerid = id;
            yzmcheck = yzm;
            currentTime = DateTime.Now.ToLocalTime();
            strT2 = currentTime.ToString("hh:mm:ss");
            strT1 = currentTime.ToString("yyyy-MM-dd");
            strT = strT1 + " " + strT2;

            age_check2 = agecheck_int;//傳回normal
            malecheck2 = malecheck;//傳回normal
            namecheck2 = namecheck;//傳回normal

            result.Content = yzm;
            namecheck1.Content = namecheck;


            if (agecheck_int >= 60 && agecheck_int < 65)//判斷年齡
            {
                agecheck = 1;
            }
            else if (agecheck_int >= 65 && agecheck_int < 70)
            {
                agecheck = 2;
            }
            else if (agecheck_int >= 70 && agecheck_int < 75)
            {
                agecheck = 3;
            }
            else if (agecheck_int >= 75 && agecheck_int < 80)
            {
                agecheck = 4;
            }
            else if (agecheck_int >= 80 && agecheck_int < 85)
            {
                agecheck = 5;
            }
            else if (agecheck_int >= 85 && agecheck_int < 90)
            {
                agecheck = 6;
            }
            else if (agecheck_int >= 90)
            {
                agecheck = 7;
            }


            if (yzm > 6 && malecheck == 2 && agecheck == 1)
            {
                goodornot.Content = "有待加強";
                notgood.Visibility = Visibility.Visible;
                avg.Content = "60~64歲女性平均成績：5";

            }

            if (yzm == 6 && malecheck == 2 && agecheck == 1)
            {
                goodornot.Content = "很好";
                good.Visibility = Visibility.Visible;
                avg.Content = "60~64歲女性平均成績：5";
            }

            if (yzm < 6 && malecheck == 2 && agecheck == 1)
            {
                goodornot.Content = "太厲害了";
                verygood.Visibility = Visibility.Visible;
                avg.Content = "60~64歲女性平均成績：5";
            }







            if (yzm > 6 && malecheck == 2 && agecheck == 2)
            {
                goodornot.Content = "有待加強";
                notgood.Visibility = Visibility.Visible;
                avg.Content = "65~69歲女性平均成績：5.3";

            }

            if (yzm == 6 && malecheck == 2 && agecheck == 2)
            {
                goodornot.Content = "很好";
                good.Visibility = Visibility.Visible;
                avg.Content = "65~69歲女性平均成績：5.3";
            }

            if (yzm < 6 && malecheck == 2 && agecheck == 2)
            {
                goodornot.Content = "太厲害了";
                verygood.Visibility = Visibility.Visible;
                avg.Content = "65~69歲女性平均成績：5.3";
            }







            if (yzm > 6 && malecheck == 2 && agecheck == 3)
            {
                goodornot.Content = "有待加強";
                notgood.Visibility = Visibility.Visible;
                avg.Content = "70~74歲女性平均成績：5.6";

            }

            if (yzm == 6 && malecheck == 2 && agecheck == 3)
            {
                goodornot.Content = "很好";
                good.Visibility = Visibility.Visible;
                avg.Content = "70~74歲女性平均成績：5.6";
            }

            if (yzm < 6 && malecheck == 2 && agecheck == 3)
            {
                goodornot.Content = "太厲害了";
                verygood.Visibility = Visibility.Visible;
                avg.Content = "70~74歲女性平均成績：5.6";
            }







            if (yzm > 7 && malecheck == 2 && agecheck == 4)
            {
                goodornot.Content = "有待加強";
                notgood.Visibility = Visibility.Visible;
                avg.Content = "75~79歲女性平均成績：6";

            }

            if (yzm == 7 && malecheck == 2 && agecheck == 4)
            {
                goodornot.Content = "很好";
                good.Visibility = Visibility.Visible;
                avg.Content = "75~79歲女性平均成績：6";
            }

            if (yzm < 7 && malecheck == 2 && agecheck == 4)
            {
                goodornot.Content = "太厲害了";
                verygood.Visibility = Visibility.Visible;
                avg.Content = "75~79歲女性平均成績：6";
            }







            if (yzm > 7 && malecheck == 2 && agecheck == 5)
            {
                goodornot.Content = "有待加強";
                notgood.Visibility = Visibility.Visible;
                avg.Content = "80~84歲女性平均成績：6.5";

            }

            if (yzm == 7 && malecheck == 2 && agecheck == 5)
            {
                goodornot.Content = "很好";
                good.Visibility = Visibility.Visible;
                avg.Content = "80~84歲女性平均成績：6.5";
            }

            if (yzm < 7 && malecheck == 2 && agecheck == 5)
            {
                goodornot.Content = "太厲害了";
                verygood.Visibility = Visibility.Visible;
                avg.Content = "80~84歲女性平均成績：6.5";
            }







            if (yzm > 6 && malecheck == 2 && agecheck == 6)
            {
                goodornot.Content = "有待加強";
                notgood.Visibility = Visibility.Visible;
                avg.Content = "85~89歲女性平均成績：7.1";

            }

            if (yzm == 6 && malecheck == 2 && agecheck == 6)
            {
                goodornot.Content = "很好";
                good.Visibility = Visibility.Visible;
                avg.Content = "85~89歲女性平均成績：7.1";
            }

            if (yzm < 6 && malecheck == 2 && agecheck == 6)
            {
                goodornot.Content = "太厲害了";
                verygood.Visibility = Visibility.Visible;
                avg.Content = "85~89歲女性平均成績：7.1";
            }







            if (yzm > 6 && malecheck == 2 && agecheck == 7)
            {
                goodornot.Content = "有待加強";
                notgood.Visibility = Visibility.Visible;
                avg.Content = "90以上歲女性平均成績：8";

            }

            if (yzm == 6 && malecheck == 2 && agecheck == 7)
            {
                goodornot.Content = "很好";
                good.Visibility = Visibility.Visible;
                avg.Content = "90以上歲女性平均成績：8";
            }

            if (yzm < 6 && malecheck == 2 && agecheck == 7)
            {
                goodornot.Content = "太厲害了";
                verygood.Visibility = Visibility.Visible;
                avg.Content = "90以上歲女性平均成績：8";
            }
























            if (yzm > 5 && malecheck == 1 && agecheck == 1)
            {
                goodornot.Content = "有待加強";
                notgood.Visibility = Visibility.Visible;
                avg.Content = "60~64歲男性平均成績：4.8";

            }

            if (yzm == 5  && malecheck == 1 && agecheck == 1)
            {
                goodornot.Content = "很好";
                good.Visibility = Visibility.Visible;
                avg.Content = "60~64歲男性平均成績：4.8";
            }

            if (yzm < 5 && malecheck == 1 && agecheck == 1)
            {
                goodornot.Content = "太厲害了";
                verygood.Visibility = Visibility.Visible;
                avg.Content = "60~64歲男性平均成績：4.8";
            }







            if (yzm > 5 && malecheck == 1 && agecheck == 2)
            {
                goodornot.Content = "有待加強";
                notgood.Visibility = Visibility.Visible;
                avg.Content = "65~69歲男性平均成績：5.1";

            }

            if (yzm == 5 && malecheck == 1 && agecheck == 2)
            {
                goodornot.Content = "很好";
                good.Visibility = Visibility.Visible;
                avg.Content = "65~69歲男性平均成績：5.1";
            }

            if (yzm < 5 && malecheck == 1 && agecheck == 2)
            {
                goodornot.Content = "太厲害了";
                verygood.Visibility = Visibility.Visible;
                avg.Content = "65~69歲男性平均成績：5.1";
            }







            if (yzm > 6 && malecheck == 1 && agecheck == 3)
            {
                goodornot.Content = "有待加強";
                notgood.Visibility = Visibility.Visible;
                avg.Content = "70~74歲男性平均成績：5.5";

            }

            if (yzm == 6 && malecheck == 1 && agecheck == 3)
            {
                goodornot.Content = "很好";
                good.Visibility = Visibility.Visible;
                avg.Content = "70~74歲男性平均成績：5.5";
            }

            if (yzm < 6 && malecheck == 1 && agecheck == 3)
            {
                goodornot.Content = "太厲害了";
                verygood.Visibility = Visibility.Visible;
                avg.Content = "70~74歲男性平均成績：5.5";
            }







            if (yzm > 6 && malecheck == 1 && agecheck == 4)
            {
                goodornot.Content = "有待加強";
                notgood.Visibility = Visibility.Visible;
                avg.Content = "75~79歲男性平均成績：5.9";

            }

            if (yzm == 6 && malecheck == 1 && agecheck == 4)
            {
                goodornot.Content = "很好";
                good.Visibility = Visibility.Visible;
                avg.Content = "75~79歲男性平均成績：5.9";
            }

            if (yzm < 6 && malecheck == 1 && agecheck == 4)
            {
                goodornot.Content = "太厲害了";
                verygood.Visibility = Visibility.Visible;
                avg.Content = "75~79歲男性平均成績：5.9";
            }







            if (yzm > 6 && malecheck == 1 && agecheck == 5)
            {
                goodornot.Content = "有待加強";
                notgood.Visibility = Visibility.Visible;
                avg.Content = "80~84歲男性平均成績：6.4";

            }

            if (yzm == 6 && malecheck == 1 && agecheck == 5)
            {
                goodornot.Content = "很好";
                good.Visibility = Visibility.Visible;
                avg.Content = "80~84歲男性平均成績：6.4";
            }

            if (yzm < 6 && malecheck == 1 && agecheck == 5)
            {
                goodornot.Content = "太厲害了";
                verygood.Visibility = Visibility.Visible;
                avg.Content = "80~84歲男性平均成績：6.4";
            }







            if (yzm > 7 && malecheck == 1 && agecheck == 6)
            {
                goodornot.Content = "有待加強";
                notgood.Visibility = Visibility.Visible;
                avg.Content = "85~89歲男性平均成績：7.1";

            }

            if (yzm == 7 && malecheck == 1 && agecheck == 6)
            {
                goodornot.Content = "很好";
                good.Visibility = Visibility.Visible;
                avg.Content = "85~89歲男性平均成績：7.1";
            }

            if (yzm < 7 && malecheck == 1 && agecheck == 6)
            {
                goodornot.Content = "太厲害了";
                verygood.Visibility = Visibility.Visible;
                avg.Content = "85~89歲男性平均成績：7.1";
            }







            if (yzm > 6 && malecheck == 1 && agecheck == 7)
            {
                goodornot.Content = "有待加強";
                notgood.Visibility = Visibility.Visible;
                avg.Content = "90以上歲男性平均成績：8";

            }

            if (yzm == 6 && yzm < 12 && malecheck == 1 && agecheck == 7)
            {
                goodornot.Content = "很好";
                good.Visibility = Visibility.Visible;
                avg.Content = "90以上歲男性平均成績：8";
            }

            if (yzm < 6 && malecheck == 1 && agecheck == 7)
            {
                goodornot.Content = "太厲害了";
                verygood.Visibility = Visibility.Visible;
                avg.Content = "90以上歲男性平均成績：8";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String connetStr = "server=163.18.62.45;port=3306;user=wen;password=1234; database=wen";//資料庫
            MySqlConnection conn = new MySqlConnection(connetStr);
            try
            {
                conn.Open();//開啟通道，建立連線，可能出現異常,使用try catch語句
                Console.WriteLine("已經建立連線");
                string queryString = "INSERT INTO action(ID,動作名稱,次數,日期) VALUES(@ID,@動作名稱,@次數,@日期)";
                MySqlCommand command = new MySqlCommand(queryString, conn);
                //conn.Open();

                command.Parameters.AddWithValue("@ID", workerid);

                command.Parameters.AddWithValue("@動作名稱", "2.44米繞物測量");
                command.Parameters.AddWithValue("@次數", yzmcheck);
                command.Parameters.AddWithValue("@日期", strT);

                command.ExecuteNonQuery();
                //在這裡使用程式碼對資料庫進行增刪查改
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;
                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
            }
            /* finally
             {
                 
             }
            */
            conn.Close();
            a = 1;
            
            this.Close();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            String connetStr = "server=163.18.62.45;port=3306;user=wen;password=1234; database=wen";//資料庫
            MySqlConnection conn = new MySqlConnection(connetStr);
            try
            {
                conn.Open();//開啟通道，建立連線，可能出現異常,使用try catch語句
                Console.WriteLine("已經建立連線");
                string queryString = "INSERT INTO action(ID,動作名稱,次數,日期) VALUES(@ID,@動作名稱,@次數,@日期)";
                MySqlCommand command = new MySqlCommand(queryString, conn);
                //conn.Open();

                command.Parameters.AddWithValue("@ID", workerid);

                command.Parameters.AddWithValue("@動作名稱", "2.44米繞物測量");
                command.Parameters.AddWithValue("@次數", yzmcheck);
                command.Parameters.AddWithValue("@日期", strT);

                command.ExecuteNonQuery();
                //在這裡使用程式碼對資料庫進行增刪查改
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;
                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
            }
            /* finally
             {
                 
             }
            */
            conn.Close();
            testnormal w = new testnormal(malecheck2, age_check2, namecheck2, workerid, "0", 0);

            this.Close();
            w.Show();
        }
    }
}
