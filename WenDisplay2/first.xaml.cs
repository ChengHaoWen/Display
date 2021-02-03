using System;
using System.Collections.Generic;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.Windows;
using System.ComponentModel;
using System.Timers;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using Microsoft.Win32;
using MySql.Data.MySqlClient;//連接資料庫

namespace WenDisplay2
{
    /// <summary>
    /// first.xaml 的互動邏輯
    /// </summary>
    public partial class first : Window
    {
        string namecheck;
        string agecheck;
        int male_int;//性別數字
        string malecheck;
        int age_int;//年齡數字
        int a = 0;
        string idcheck;
        string strT2;
        string strT1;
        string strT;
        private string faceName;
        private string ID;
        public string FaceName;
        System.DateTime currentTime = new System.DateTime();
        public first()
        {
            currentTime = DateTime.Now.ToLocalTime() ;
            strT2 = currentTime.ToString("hh:mm:ss");
            strT1 = currentTime.ToString("yyyy-MM-dd");
            strT = strT1+" "+strT2;
            InitializeComponent();
        }
        private void Window_Closing(object sender,System.ComponentModel.CancelEventArgs e)
        {
            if (a != 1)
                Application.Current.Shutdown();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)//試用功能
        {
            a = 1;
            personaldata w = new personaldata();
            this.Close();
            w.Show();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)//直接登入
        {
            a = 1;
            login w = new login();
            this.Close();
            w.Show();
        }

        private void Button_Click12(object sender, RoutedEventArgs e)//臉部辨識登入
        {
            string[] strArr = new string[2];//引數列表
            string sArguments = @"facerec_from_webcam_faster.py";//這裡是python的檔名字
            strArr[0] = "2";
            strArr[1] = "3";
            RunPythonScript(sArguments, "-u", strArr);

            sql();
        }

        private void Button_Click13(object sender, RoutedEventArgs e)//新增照片
        {
            a = 1;
            create_picture w = new create_picture();
            this.Close();
            w.Show();
        }

     
        Process p = new Process();
        public void RunPythonScript(string sArgName, string args = "", params string[] teps) //原本static
        {
           
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + sArgName;// 獲得python檔案的絕對路徑（將檔案放在c#的debug資料夾中可以這樣操作）
            path = @"C:\Users\nkust_f435\Desktop\Wen_Display2\WenDisplay2\WenDisplay2\bin\x64\Debug\Source\" + sArgName;//(因為我沒放debug下，所以直接寫的絕對路徑,替換掉上面的路徑了)
            p.StartInfo.FileName = @"python.exe";//沒有配環境變數的話，可以像我這樣寫python.exe的絕對路徑。如果配了，直接寫"python.exe"即可
            string sArguments = path;
            foreach (string sigstr in teps)
            {
                sArguments += " " + sigstr;//傳遞引數
            }

            sArguments += " " + args;

            p.StartInfo.Arguments = sArguments;

            p.StartInfo.UseShellExecute = false;

            p.StartInfo.RedirectStandardOutput = true;

            p.StartInfo.RedirectStandardInput = true;

            p.StartInfo.RedirectStandardError = true;

            p.StartInfo.CreateNoWindow = true;

            p.Start();
            p.BeginOutputReadLine();
            p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            p.WaitForExit();

            if (p != null)
            {
                p.Close();
                p.Dispose();
                p = null;
            }
        }
        //輸出列印的資訊
        void p_OutputDataReceived(object sender, DataReceivedEventArgs e) //原本有static
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                AppendText(e.Data + Environment.NewLine);
            }
        }
        public delegate void AppendTextCallback(string text);
        public void AppendText(string text) //原本有static
        {
            Console.WriteLine(text);//此處在控制檯輸出.py檔案print的結果
            faceName = text.Replace("\r\n", ""); ;
            Console.WriteLine(faceName);
        }

        public void sql()
        {
            String connetStr = "server=163.18.62.45;port=3306;user=wen;password=1234; database=wen";//資料庫
            MySqlConnection conn = new MySqlConnection(connetStr);
            ID = faceName;
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
                // Application.Current.Shutdown();
                this.Close();
                Lw.Show();
            }
        }
    }
}
