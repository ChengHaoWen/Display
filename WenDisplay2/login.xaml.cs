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
using MySql.Data.MySqlClient;//連接資料庫


namespace WenDisplay2
{
    /// <summary>
    /// login.xaml 的互動邏輯
    /// </summary>
    /// 
    public partial class login : Window
    {
        string namecheck;
        string agecheck;
        int male_int;//性別數字
        string malecheck;
        int age_int;//年齡數字
        int a = 0;
        string idcheck;
        string ID;
        System.DateTime currentTime = new System.DateTime();//自動取得時間
        public login()
        {
            InitializeComponent();


         

            currentTime =System.DateTime.Now;
            string strT = currentTime.ToString("g");
            //label2.Content = strT;

            

        }

        /*private void Button_Click_1(object sender, RoutedEventArgs e)//寫入
        {
            
            String connetStr = "server=163.18.62.45;port=3306;user=wen;password=1234; database=wen";//資料庫
            MySqlConnection conn = new MySqlConnection(connetStr);
            namecheck = name.Text;
            idcheck = id.Text;
            agecheck = age.Text;
           try
            {
                conn.Open();//開啟通道，建立連線，可能出現異常,使用try catch語句
                Console.WriteLine("已經建立連線");
                string queryString = "INSERT INTO user(ID,Name,Gender,Age) VALUES(@ID,@name,@male,@age)";
                MySqlCommand command = new MySqlCommand(queryString, conn);
                //conn.Open();
                if (boy.IsChecked == true)
                {
                    command.Parameters.AddWithValue("@male", "男");
                }
                if (girl.IsChecked == true)
                {
                    command.Parameters.AddWithValue("@male", "女");
                }
                command.Parameters.AddWithValue("@name", namecheck);
                command.Parameters.AddWithValue("@ID", idcheck);
                command.Parameters.AddWithValue("@age", agecheck);

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
            
            conn.Close();
        }*/



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            String connetStr = "server=163.18.62.45;port=3306;user=wen;password=1234; database=wen";//資料庫
            MySqlConnection conn = new MySqlConnection(connetStr);
            ID = id.Text;
            try
            {
                conn.Open();
                Console.WriteLine("已經建立連線");

                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "select * from user where ID= '" + ID + "' ";
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                agecheck = reader["Age"].ToString();
                malecheck = reader["Gender"].ToString();
                namecheck = reader["Name"].ToString();
                idcheck = reader["Id"].ToString();
                age_int = Convert.ToInt32(agecheck);

                if (malecheck == "男")
                {
                    male_int = 1;
                }
                else if (malecheck == "女")
                {
                    male_int = 2;
                }
                a = 1;
            }

            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        MessageBox.Show("沒有登入成功");
                        a = 2;
                        break;
                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
            }
            conn.Close();
            if (a == 1)
            {
                //a = 1;
                testnormal w = new testnormal(male_int, age_int, namecheck, idcheck, "0", 0);
                GC.SuppressFinalize(this);
                this.Close();
                w.Show();
            }
            else


            if (a == 2)
            {
                first Lw = new first();

                //GC.SuppressFinalize(this);
                Application.Current.Shutdown();
                this.Close();
                Lw.Show();
            }

        }
    }
}
