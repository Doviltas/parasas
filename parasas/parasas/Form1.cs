using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace parasas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ASCIIEncoding ByteConverter = new ASCIIEncoding();
        RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();
       
        public static byte[] HashAndSignBytes(byte[] DataToSign, RSAParameters Key)
        {
            try
            {     
                RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();
                RSAalg.ImportParameters(Key);
                return RSAalg.SignData(DataToSign, SHA256.Create());
            }
            catch (CryptographicException e)
            {
                MessageBox.Show(e.Message);

                return null;
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            string dataString = textBox1.Text;
            RSAParameters Key = RSAalg.ExportParameters(true);
            byte[] originalData = ByteConverter.GetBytes(dataString);

            richTextBox1.Text = String.Join(" ", HashAndSignBytes(originalData, Key));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox1.Text;
        }
       
        

       
    }
}
