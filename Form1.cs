using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
namespace ftp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FtpWebRequest dalecalor = (FtpWebRequest)FtpWebRequest.Create("ftp://files.000webhost.com/public_html/" + "/" + Path.GetFileName(@"C:\Users\hector\Desktop\a20136615.txt"));
            dalecalor.Method = WebRequestMethods.Ftp.UploadFile;
            dalecalor.Credentials = new NetworkCredential("test1pweb", "computadora321");
            dalecalor.UsePassive = true;
            dalecalor.UseBinary = true;
            dalecalor.KeepAlive = false;

            FileStream stream = File.OpenRead(@"C:\Users\hector\Desktop\a20136615.txt");
            byte[] buffer = new byte[stream.Length];

            stream.Read(buffer, 0, buffer.Length);
            stream.Close();
            Stream reqStream = dalecalor.GetRequestStream();
            reqStream.Write(buffer, 0, buffer.Length);
            reqStream.Close();
            MessageBox.Show("Uploaded Successfully");
        }

    }
}
