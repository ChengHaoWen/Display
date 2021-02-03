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
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Threading;
using System.Threading;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Net;

namespace WenDisplay2
{
    /// <summary>
    /// test6.xaml 的互動邏輯
    /// </summary>
    public partial class test6 : Window
    {
        static MqttClient mqttClient;
        static Socket client;
        static byte TypeNumber = 25;//關節數量
        static string[] TypeName = {"None",
                 "Head", "Neck", "Torso", "Waist",
                 "LeftCollar", "LeftShoulder", "LeftElbow", "LeftWrist", "LeftHand", "LeftFingertip",
                 "RightCollar", "RightShoulder", "RightElbow", "RightWrist", "RightHand", "RightFingertip",
                 "LeftHip", "LeftKnee", "LeftAnkle", "LeftFoot",
                 "RightHip", "RightKnee", "RightAnkle", "RightFoot"};
        string ReceiveBuf;
        int a = 0;
        bool update = false;
        public float StrToFloat(object FloatString) { float result; if (FloatString != null) { if (float.TryParse(FloatString.ToString(), out result)) return result; else { return (float)0.00; } } else { return (float)0.00; } } 
        int malecheck = 0;
        int agecheck = 0;
        string namecheck;
        string workerid;
        string examinerid;
        int member = 0;
        int modetype = 0;
        int change = 0;
        int set = 1;
        int counting = 0;
        int startagain = 0;
        int sec = 4;
        int start = 0;
        int sec2 = 0;
        JObject obj;
        Thread t1;

        DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
        DispatcherTimer timer2 = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(0.1) };

        Process myProcess;
        string fileName = "C:\\Users\\nkust_f435\\Desktop\\RealSenseTest\\RealSenseTest\\bin\\x64\\Debug\\RealSenseTest.exe";//骨架攝影機

        public test6(int testmalecheck, int testagecheck, string testname, int mode, string id, string id2, int modecheck)
        {
            InitializeComponent();
            Awake();

            myProcess = Process.Start(fileName);//骨架攝影機開啟
            // myProcess.StartInfo.CreateNoWindow = true;//骨架攝影機 不顯示CMD
            malecheck = testmalecheck;
            agecheck = testagecheck;
            namecheck = testname;
            workerid = id;
            examinerid = id2;
            modetype = mode;
            member = modecheck;
            Name_02.Content = namecheck;
            timer.Tick += timer_Tick;
            timer2.Tick += timer2_Tick;
            timer2.Start();
            timer.Start();
            t1 = new Thread(ServerReceive);
            t1.Start();
        }
        void Awake()
        {
            try
            {
                //連結伺服器
                mqttClient = new MqttClient("163.18.62.45", 1883, false, null, null, null);//1883//"163.18.62.45"
                                                                                           //註冊伺服器返回資訊接受函數
                mqttClient.MqttMsgPublishReceived += new MqttClient.MqttMsgPublishEventHandler(messageReceive);
                //用戶端ID
                string clientId = Guid.NewGuid().ToString();
                mqttClient.Connect(clientId);

                //訂閱
                mqttClient.Subscribe(new string[] { "/F435/3" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
            }
            catch
            {
                Console.WriteLine("MQTT連線失敗");
            }
        }
        void ServerReceive()
        {
            IPEndPoint ipont = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 55021);//將IP位址和Port宣告為服務的連接點(所有網路介面卡 IP,20 Port)

            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//宣告一個Socket通訊介面(使用IPv4協定,通訊類型,通訊協定)

            newsock.Bind(ipont); //建立本機連線

            newsock.Listen(10);//偵測連接(最大連接數)

            client = newsock.Accept();//宣告一個Socket等於新建立的連線

            IPEndPoint clientip = (IPEndPoint)client.RemoteEndPoint; //宣告一個連接點為socket端的連接點

            while (client.IsBound)
            {

                byte[] data = new byte[1024 * 15]; //定義一個資料緩衝區接收長度最大為(1024)\
                int len = 0;
                try
                {
                    len = client.Receive(data);//接收資料至緩衝區中並回傳成功街收位元數
                }
                catch
                {

                    //client.Shutdown(SocketShutdown.Both);
                    //client.Close();
                    //client.Disconnect(true);
                    newsock.Close();
                    // client.Dispose();
                    //client = null;

                }

                if (len == 0) break;//若成功接收位元數為0則跳出迴圈

                ReceiveBuf = System.Text.Encoding.Default.GetString(data);
                /*for (int i = 0; i < len; i++)
                {
                    Console.Write (ReceiveBuf[i]);
                }
                Console.Write("\n\n");*/
                try
                {
                    obj = JObject.Parse(ReceiveBuf);

                    for (int i = 0; i < TypeNumber; i++)
                    {
                        string typename = TypeName[i];//要讀取的關節名稱
                                                      // Console.WriteLine(typename + "(x,y):" + obj[typename]["x"] + "," + obj[typename]["y"]);
                                                      /* float ws = StrToFloat(obj["Waist"]["y"].ToString());
                                                        float hly = StrToFloat(obj["LeftHip"]["y"].ToString());
                                                        float hry = StrToFloat(obj["RightHip"]["y"].ToString());
                                                        Console.WriteLine("wsy:"+ws);
                                                        Console.WriteLine("hly:" + hly);
                                                        Console.WriteLine("hry:" + hry);*/
                    }
                    update = true;//資料旗標致能
                }
                catch
                {
                    Console.WriteLine("Json格式錯誤或關節參數不正確");
                }
            }
        }
        void messageReceive(object sender, MqttMsgPublishEventArgs e)
        {
            ReceiveBuf = System.Text.Encoding.Default.GetString(e.Message);
            try
            {
                JObject obj = JObject.Parse(ReceiveBuf);

                for (int i = 0; i < TypeNumber; i++)
                {
                    string typename = TypeName[i];//要讀取的關節名稱
                                                  // Console.WriteLine(typename + "(x,y):" + obj[typename]["x"] + "," + obj[typename]["y"]);
                                                  /* float ws = StrToFloat(obj["Waist"]["y"].ToString());
                                                    float hly = StrToFloat(obj["LeftHip"]["y"].ToString());
                                                    float hry = StrToFloat(obj["RightHip"]["y"].ToString());
                                                    Console.WriteLine("wsy:"+ws);
                                                    Console.WriteLine("hly:" + hly);
                                                    Console.WriteLine("hry:" + hry);*/
                }
                update = true;//資料旗標致能

                //test2();
            }
            catch
            {
                Console.WriteLine("Json格式錯誤或關節參數不正確");
            }
        }
        void timer2_Tick(object sender, EventArgs e)
        {
            if (update)
            {
                Knee_up();
                update = false;
            }
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (start == 1)
            {
                if (sec == 4)
                    hint.Content = "3秒後開始";
                if (sec == 3)
                    hint.Content = "2秒後開始";
                if (sec == 2)
                    hint.Content = "1秒後開始";
                if (sec == 1)
                {
                    if (modetype == 2)
                    {
                        hint.Content = "請抬左腳";
                    }
                    if (modetype == 1)
                    {
                        hint.Content = "請抬右腳";

                    }
                   /* if (modetype == 0)
                    {
                        hint.Content = "請抬右腳";

                    }*/
                }

                if (sec == 0)
                {
                    sec = 121;
                    startagain = 1;
                    start = 0;
                }
                sec--;

            }
            if (sec > 0 && change == 1)
            {
                sec--;
                counting++;
                count.Content = counting.ToString();//計算秒數
                
                countdown.Content = sec.ToString();  //timerText是介面上的一個TextBlock

            }
            if ( startagain == 2||counting==120)
            {
                a = 1;
                test6result w = new test6result(counting, malecheck, agecheck, workerid, examinerid, member, namecheck, modetype);
                myProcess.CloseMainWindow();
                //myProcess.Close();//骨架攝影機關閉˙
                myProcess.Kill();
                client.Shutdown(SocketShutdown.Both);
                client.Close();
                // client.Disconnect(true);
                t1.Abort();
                client.Dispose();
                this.Close();
                w.Show();
                timer.Stop();
            }
        }
        void Knee_up()//2分鐘單足立
        {
            
            float LKY = StrToFloat(obj["LeftKnee"]["y"].ToString());
            float RKY = StrToFloat(obj["RightKnee"]["y"].ToString());
            float LFY = StrToFloat(obj["LeftFoot"]["y"].ToString());
            float RFY = StrToFloat(obj["RightFoot"]["y"].ToString());
            float LHY = StrToFloat(obj["LeftHip"]["y"].ToString());
            float RHY = StrToFloat(obj["RightHip"]["y"].ToString());
            //double RKY1 = RKY - 0.08;
            //double LKY1 = LKY - 0.08;
            double LH = (LKY - LHY) / 2;
            double RH = (RKY - RHY) / 2;
            double LKY1 = LKY - LH;
            double RKY1 = RKY - RH;
            // double RKY2 = RKY - 0.07;
            // double LKY2 = LKY - 0.07;
            double RKY2 = RKY - 0.03;
            double LKY2 = LKY - 0.03;
            /*   if (modetype == 0)
               {

                   if (change == 0 && RKY < LKY1 && startagain == 1)
                   {

                       counting++;
                       change = 1;
                       hint.Content = "請先放下右腳在抬起左腳";

                   }
                   if (change == 1 && RKY1 > LKY && startagain == 1)
                   {

                       counting++;
                       change = 0;
                       hint.Content = "請先放下左腳在抬起右腳";

                   }

               }*/
            if (modetype == 1&& label4.Content != "Label" )//右腳
            {
                if(startagain!=1)
                start = 1;
                if ( RKY < LKY1 && startagain == 1)
                {

                    hint.Content = "測驗時間中";
                    Tip_picture1.Visibility = Visibility.Visible;
                    Tip_picture2.Visibility = Visibility.Hidden;
                    change = 1;
                }
                
                if  (RKY > LKY2&&change==1 )
                {
                    startagain = 2;


                    
                }
            }
            if (modetype == 2 && label4.Content != "Label")//左腳
            {
                if (startagain != 1)
                    start = 1;
                if ( LKY < RKY1 && startagain == 1)
                {
                    hint.Content = "測驗時間中";
                    Tip_picture2.Visibility = Visibility.Visible;
                    Tip_picture1.Visibility = Visibility.Hidden;
                    change = 1;
                }
               
                if ( LKY > RKY2 && change == 1)
                {

                    startagain = 2;
                    
                }

            }
            label4.Content = LKY;
            

                

        }
    }
}
