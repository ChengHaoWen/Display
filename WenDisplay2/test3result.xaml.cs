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
    /// test3result.xaml 的互動邏輯
    /// </summary>
    public partial class test3result : Window
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

        public test3result(int yzm, int malecheck, int agecheck_int, string id, string id2, int modecheck, string namecheck, int modetype)
        {


         
            
            InitializeComponent();
            age_check2 = agecheck_int;//傳回normal
            malecheck2 = malecheck;//傳回normal
            namecheck2 = namecheck;//傳回normal

            workerid = id;
            yzmcheck = yzm;
            currentTime = DateTime.Now.ToLocalTime();
            strT2 = currentTime.ToString("hh:mm:ss");
            strT1 = currentTime.ToString("yyyy-MM-dd");
            strT = strT1 + " " + strT2;
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

            avg.Content = agecheck_int;

            if (yzm < 49 && malecheck == 2 && agecheck == 1)
            {
                goodornot.Content = "有待加強";
                notgood.Visibility = Visibility.Visible;
                avg.Content = "60~64歲女性平均成績：50";

            }

            if (yzm >= 49 && yzm < 57 && malecheck == 2 && agecheck == 1)
            {
                goodornot.Content = "很好";
                good.Visibility = Visibility.Visible;
                avg.Content = "60~64歲女性平均成績：50";
            }

            if (yzm >= 57 && malecheck == 2 && agecheck == 1)
            {
                goodornot.Content = "太厲害了";
                verygood.Visibility = Visibility.Visible;
                avg.Content = "60~64歲女性平均成績：50";
            }







            if (yzm < 49 && malecheck == 2 && agecheck == 2)
            {
                goodornot.Content = "有待加強";
                notgood.Visibility = Visibility.Visible;
                avg.Content = "65~69歲女性平均成績：50";

            }

            if (yzm >= 49 && yzm < 57 && malecheck == 2 && agecheck == 2)
            {
                goodornot.Content = "很好";
                good.Visibility = Visibility.Visible;
                avg.Content = "65~69歲女性平均成績：50";
            }

            if (yzm >= 57 && malecheck == 2 && agecheck == 2)
            {
                goodornot.Content = "太厲害了";
                verygood.Visibility = Visibility.Visible;
                avg.Content = "65~69歲女性平均成績：50";
            }







            if (yzm < 49 && malecheck == 2 && agecheck == 3)
            {
                goodornot.Content = "有待加強";
                notgood.Visibility = Visibility.Visible;
                avg.Content = "70~74歲女性平均成績：50";

            }

            if (yzm >= 49 && yzm < 54 && malecheck == 2 && agecheck == 3)
            {
                goodornot.Content = "很好";
                good.Visibility = Visibility.Visible;
                avg.Content = "70~74歲女性平均成績：50";
            }

            if (yzm >= 54 && malecheck == 2 && agecheck == 3)
            {
                goodornot.Content = "太厲害了";
                verygood.Visibility = Visibility.Visible;
                avg.Content = "70~74歲女性平均成績：50";
            }







            if (yzm < 45 && malecheck == 2 && agecheck == 4)
            {
                goodornot.Content = "有待加強";
                notgood.Visibility = Visibility.Visible;
                avg.Content = "75~79歲女性平均成績：46";

            }

            if (yzm >= 45 && yzm < 52 && malecheck == 2 && agecheck == 4)
            {
                goodornot.Content = "很好";
                good.Visibility = Visibility.Visible;
                avg.Content = "75~79歲女性平均成績：46";
            }

            if (yzm >= 52 && malecheck == 2 && agecheck == 4)
            {
                goodornot.Content = "太厲害了";
                verygood.Visibility = Visibility.Visible;
                avg.Content = "75~79歲女性平均成績：46";
            }







            if (yzm < 39 && malecheck == 2 && agecheck == 5)
            {
                goodornot.Content = "有待加強";
                notgood.Visibility = Visibility.Visible;
                avg.Content = "80~84歲女性平均成績：40";

            }

            if (yzm >= 39 && yzm < 49 && malecheck == 2 && agecheck == 5)
            {
                goodornot.Content = "很好";
                good.Visibility = Visibility.Visible;
                avg.Content = "80~84歲女性平均成績：40";
            }

            if (yzm >= 49 && malecheck == 2 && agecheck == 5)
            {
                goodornot.Content = "太厲害了";
                verygood.Visibility = Visibility.Visible;
                avg.Content = "80~84歲女性平均成績：40";
            }







            if (yzm < 38 && malecheck == 2 && agecheck == 6)
            {
                goodornot.Content = "有待加強";
                notgood.Visibility = Visibility.Visible;
                avg.Content = "85~89歲女性平均成績：42";

            }

            if (yzm >= 38 && yzm < 52 && malecheck == 2 && agecheck == 6)
            {
                goodornot.Content = "很好";
                good.Visibility = Visibility.Visible;
                avg.Content = "85~89歲女性平均成績：42";
            }

            if (yzm >= 52 && malecheck == 2 && agecheck == 6)
            {
                goodornot.Content = "太厲害了";
                verygood.Visibility = Visibility.Visible;
                avg.Content = "85~89歲女性平均成績：42";
            }







            if (yzm < 29 && malecheck == 2 && agecheck == 7)
            {
                goodornot.Content = "有待加強";
                notgood.Visibility = Visibility.Visible;
                avg.Content = "90以上歲女性平均成績：32";

            }

            if (yzm >= 29 && yzm < 45 && malecheck == 2 && agecheck == 7)
            {
                goodornot.Content = "很好";
                good.Visibility = Visibility.Visible;
                avg.Content = "90以上歲女性平均成績：32";
            }

            if (yzm >= 45 && malecheck == 2 && agecheck == 7)
            {
                goodornot.Content = "太厲害了";
                verygood.Visibility = Visibility.Visible;
                avg.Content = "90以上歲女性平均成績：32";
            }
























            if (yzm < 49 && malecheck == 1 && agecheck == 1)
            {
                goodornot.Content = "有待加強";
                notgood.Visibility = Visibility.Visible;
                avg.Content = "60~64歲男性平均成績：54";

            }

            if (yzm >= 49 && yzm < 55 && malecheck == 1 && agecheck == 1)
            {
                goodornot.Content = "很好";
                good.Visibility = Visibility.Visible;
                avg.Content = "60~64歲男性平均成績：54";
            }

            if (yzm >= 55 && malecheck == 1 && agecheck == 1)
            {
                goodornot.Content = "太厲害了";
                verygood.Visibility = Visibility.Visible;
                avg.Content = "60~64歲男性平均成績：54";
            }







            if (yzm < 49 && malecheck == 1 && agecheck == 2)
            {
                goodornot.Content = "有待加強";
                notgood.Visibility = Visibility.Visible;
                avg.Content = "65~69歲男性平均成績：50";

            }

            if (yzm >= 49 && yzm < 55 && malecheck == 1 && agecheck == 2)
            {
                goodornot.Content = "很好";
                good.Visibility = Visibility.Visible;
                avg.Content = "65~69歲男性平均成績：50";
            }

            if (yzm >= 55 && malecheck == 1 && agecheck == 2)
            {
                goodornot.Content = "太厲害了";
                verygood.Visibility = Visibility.Visible;
                avg.Content = "65~69歲男性平均成績：50";
            }







            if (yzm < 47 && malecheck == 1 && agecheck == 3)
            {
                goodornot.Content = "有待加強";
                notgood.Visibility = Visibility.Visible;
                avg.Content = "70~74歲男性平均成績：49";

            }

            if (yzm >= 47 && yzm < 55 && malecheck == 1 && agecheck == 3)
            {
                goodornot.Content = "很好";
                good.Visibility = Visibility.Visible;
                avg.Content = "70~74歲男性平均成績：49";
            }

            if (yzm >= 55 && malecheck == 1 && agecheck == 3)
            {
                goodornot.Content = "太厲害了";
                verygood.Visibility = Visibility.Visible;
                avg.Content = "70~74歲男性平均成績：49";
            }







            if (yzm < 48 && malecheck == 1 && agecheck == 4)
            {
                goodornot.Content = "有待加強";
                notgood.Visibility = Visibility.Visible;
                avg.Content = "75~79歲男性平均成績：49";

            }

            if (yzm >= 48 && yzm < 53 && malecheck == 1 && agecheck == 4)
            {
                goodornot.Content = "很好";
                good.Visibility = Visibility.Visible;
                avg.Content = "75~79歲男性平均成績：49";
            }

            if (yzm >= 53 && malecheck == 1 && agecheck == 4)
            {
                goodornot.Content = "太厲害了";
                verygood.Visibility = Visibility.Visible;
                avg.Content = "75~79歲男性平均成績：49";
            }







            if (yzm < 46 && malecheck == 1 && agecheck == 5)
            {
                goodornot.Content = "有待加強";
                notgood.Visibility = Visibility.Visible;
                avg.Content = "80~84歲男性平均成績：47";

            }

            if (yzm >= 46 && yzm < 52 && malecheck == 1 && agecheck == 5)
            {
                goodornot.Content = "很好";
                good.Visibility = Visibility.Visible;
                avg.Content = "80~84歲男性平均成績：47";
            }

            if (yzm >= 52 && malecheck == 1 && agecheck == 5)
            {
                goodornot.Content = "太厲害了";
                verygood.Visibility = Visibility.Visible;
                avg.Content = "80~84歲男性平均成績：47";
            }







            if (yzm < 40 && malecheck == 1 && agecheck == 6)
            {
                goodornot.Content = "有待加強";
                notgood.Visibility = Visibility.Visible;
                avg.Content = "85~89歲男性平均成績：43";

            }

            if (yzm >= 40 && yzm < 52 && malecheck == 1 && agecheck == 6)
            {
                goodornot.Content = "很好";
                good.Visibility = Visibility.Visible;
                avg.Content = "85~89歲男性平均成績：43";
            }

            if (yzm >= 52 && malecheck == 1 && agecheck == 6)
            {
                goodornot.Content = "太厲害了";
                verygood.Visibility = Visibility.Visible;
                avg.Content = "85~89歲男性平均成績：43";
            }







            if (yzm < 36 && malecheck == 1 && agecheck == 7)
            {
                goodornot.Content = "有待加強";
                notgood.Visibility = Visibility.Visible;
                avg.Content = "90以上歲男性平均成績：38";

            }

            if (yzm >= 36 && yzm < 46 && malecheck == 1 && agecheck == 7)
            {
                goodornot.Content = "很好";
                good.Visibility = Visibility.Visible;
                avg.Content = "90以上歲男性平均成績：38";
            }

            if (yzm >= 46 && malecheck == 1 && agecheck == 7)
            {
                goodornot.Content = "太厲害了";
                verygood.Visibility = Visibility.Visible;
                avg.Content = "90以上歲男性平均成績：38";
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

                command.Parameters.AddWithValue("@動作名稱", "2分鐘站立抬膝測量");
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

                command.Parameters.AddWithValue("@動作名稱", "2分鐘站立抬膝測量");
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
