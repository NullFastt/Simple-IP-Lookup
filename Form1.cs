using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace SimpleIPLookup
{
    public partial class Form1 : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        WindowsMediaPlayer sonido;
        website websiteip;
        public Form1()
        {
            InitializeComponent();
        }
        public static bool CheckIPValid(string strIP)
        {
            IPAddress result = null;
            return
                !String.IsNullOrEmpty(strIP) &&
                IPAddress.TryParse(strIP, out result);
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {

            if (CheckIPValid(target_input.Text))
            {
                string api = $"https://ip-geolocation.whoisxmlapi.com/api/v1?apiKey=at_kAFXO0mbYmXrMT7Hr3Hg9zXUjweGB&ipAddress=" + target_input.Text;
                var client = new WebClient();
                var json = client.DownloadString(api);
                dynamic ip = JsonConvert.DeserializeObject(json);


                Output.Text = "IP: " + ip.ip + Environment.NewLine + "Country: " + ip.location.country + Environment.NewLine + "Region: " + ip.location.region + Environment.NewLine + "City: " + ip.location.city + Environment.NewLine + "Lat: " + ip.location.lat + Environment.NewLine + "Long: " + ip.location.lng + Environment.NewLine + "Postal Code: " + ip.location.postalCode + Environment.NewLine + "Time Zone" + ip.location.timezone + Environment.NewLine + "Geo Name ID: " + ip.location.geonameId + Environment.NewLine + "ISP: " + ip.isp + Environment.NewLine + "Connection Type: " + ip.connectionType + Environment.NewLine + "Domains: " + ip.domains;
            }
            else
            {
                MessageBox.Show("Invalid IP, try again");
            }
        }

        private void Output_TextChanged(object sender, EventArgs e)
        {

        }
       

        private void Output_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void Output_MouseUp(object sender, MouseEventArgs e)
        {
      
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(sonido == null)
            {
                sonido = new WindowsMediaPlayer();
                sonido.URL = Application.StartupPath + @"\backmusic.mp3";
                sonido.controls.play();
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (sonido == null)
            {
                sonido = new WindowsMediaPlayer();
                sonido.URL = Application.StartupPath + @"\backmusic.mp3";
                sonido.controls.play();
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            Process.Start("https://linktr.ee/HugoFastt");
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/CyuRNuxNWz");
        }

        private void Output_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2HtmlLabel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/HugoFastDEV/Simple-IP-Lookup");
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            websiteip = new website();
            websiteip.ShowDialog();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Disclaimer:\nThis project is made for educate no for public damages\nI take no responsibility for the damages that can occur");
        }
    }
}
