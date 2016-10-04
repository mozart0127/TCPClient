using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public string receiveData, ipAddress, msg;
        public int Port;
        connection connect;

        
        
        public Form1()
        {
            InitializeComponent();

        }

        private void SentButton_Click_1(object sender, EventArgs e)
        {
            msg = EnterText.Text;
            connect.sentData(msg);

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string text = e.Argument as string;
            e.Result = text;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string text = e.Result as string;
            Receive.Text = text;
            KeepUpdating();
        }

        private void ConnectionButton_Click(object sender, EventArgs e)
        {
            ipAddress = ipaddress.Text;
            Port = Int32.Parse(port.Text);
            connect = new connection(ipAddress, Port);
            KeepUpdating();
            ConnectionButton.Hide();
        }
        public async void KeepUpdating()
        {
            receiveData = await connect.ReadData();
            backgroundWorker1.RunWorkerAsync(receiveData);
        }








    }
}
