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
using System.IO;


namespace Max.TCP.Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtFileName.Text = openFileDialog1.FileName;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Stream fileStream = File.OpenRead(txtFileName.Text);
            // Alocate memory space for the file  
            byte[] fileBuffer = new byte[fileStream.Length];
            fileStream.Read(fileBuffer, 0, (int)fileStream.Length);

            // Open a TCP/IP Connection and send the data  
            TcpClient clientSocket = new TcpClient(mtxtIP.Text,Convert.ToInt32(mtxtPort.Text));
            NetworkStream networkStream =  clientSocket.GetStream();
            networkStream.Write(fileBuffer,0,fileBuffer.GetLength(0));
            networkStream.Close(); 
        }
    }
}
