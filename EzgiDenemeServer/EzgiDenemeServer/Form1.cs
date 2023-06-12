using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Tulpep.NotificationWindow;



namespace DenemeServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker1.MaxDate = DateTime.Now.AddDays(15);
        }
        string returnData = "";

        public void serverThread()
        {
            UdpClient udpClient = new UdpClient(8071);
            while (true)
            {
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                 returnData = Encoding.ASCII.GetString(receiveBytes);
                //lbConnections.Items.Add(RemoteIpEndPoint.Address.ToString() + ":" + returnData.ToString());
                //textBox1.Text = RemoteIpEndPoint.Address.ToString() + ":" + returnData.ToString();
                 //returnData =  returnData.ToString();
                SetText(returnData.ToString());

                
            }
        }


        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.textBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox1.Text = text;
                PopupNotifier popup = new PopupNotifier();
                popup.TitleText = "Yeni Mesaj Alındı";
                popup.ContentText = returnData;
                popup.Popup();
            }
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
           
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            Thread thdUDPServer = new Thread(new
           ThreadStart(serverThread));
            thdUDPServer.Start();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
