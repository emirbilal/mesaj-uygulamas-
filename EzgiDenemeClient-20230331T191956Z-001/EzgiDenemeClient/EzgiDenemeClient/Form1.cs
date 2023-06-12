using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Tulpep.NotificationWindow;


namespace DenemeClient
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        //EzgiDenemeClient.Form1 frm = new EzgiDenemeClient.Form1();
        //((TextBox)frm.Controls["textBox1"]).Text= "";
        private void Form1_Load(object sender, EventArgs e)
        {
            List<Class.Item> ıtems = new List<Class.Item>();
            Class.Item ıtem;

            ıtem = new Class.Item();
            ıtem.ItemCode = "192.168.1.67";
            ıtem.ItemName = "Bilal";
            ıtems.Add(ıtem);

            ıtem = new Class.Item();
            ıtem.ItemCode = "192.127.1.36";
            ıtem.ItemName = "Emir";
            ıtems.Add(ıtem);

            ıtem = new Class.Item();
            ıtem.ItemCode = "11.129.48";
            ıtem.ItemName = "ahmet";
            ıtems.Add(ıtem);

            ıtem = new Class.Item();
            ıtem.ItemCode = "15.124.48";
            ıtem.ItemName = "deneme";
            ıtems.Add(ıtem);

            ıtem = new Class.Item();
            ıtem.ItemCode = "11.124.48";
            ıtem.ItemName = "suna";
            ıtems.Add(ıtem);
            cbokisiler.DisplayMember = "ItemName";
            cbokisiler.ValueMember = "ItemCode";

            cbokisiler.DataSource = ıtems;
        }
        private void cbokişiler_SelectIndexChanged(object sender, EventArgs e)
        {
            lblID.Text = cbokisiler.SelectedValue.ToString();
            lblName.Text = cbokisiler.Text;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string mesajGonderilecekIp = lblID.Text;
            string gonderilecekMesaj = txtAd.Text;
            UdpClient udpClient = new UdpClient();
            try
            {
                udpClient.Connect(mesajGonderilecekIp, 8071);
                Byte[] senddata = Encoding.ASCII.GetBytes(gonderilecekMesaj);
                udpClient.Send(senddata, senddata.Length);

                //PopupNotifier popup = new PopupNotifier();
                //popup.TitleText = "popup deneme";
                //popup.ContentText = "gönderildi";
                //popup.Popup();
            }
            catch
            {
                //PopupNotifier popup = new PopupNotifier();
                //popup.TitleText = "popup deneme";
                //popup.ContentText = "gönderilemedi";
                //popup.Popup();
            }
        }

        

        private void txtAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

     
        
            
        
    }
    }

