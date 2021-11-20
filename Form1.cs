using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vigenere_Cipher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
     private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void Encrypt(ref StringBuilder sb, string key)
        {
            for (int i = 0; i < sb.Length; i++)
            {
                sb[i] = char.ToUpper(sb[i]);
            }
            key = key.ToUpper();
            int j = 0;
            for (int i = 0; i < sb.Length; i++)
            {
                if (char.IsLetter(sb[i]))
                {
                    sb[i] = (char)(sb[i] + key[i] - 'A');
                    if (sb[i] > 'Z') {
                        sb[i] = (char)(sb[i] - 'Z' + 'A' - 1);
                            }
                    j = j + 1 == key.Length ? 0 : j + 1;
                }
            }

        }
        public void Decrypt(ref StringBuilder sb, string key)
        {
            for(int i = 0; i < sb.Length; i++)
            {
                sb[i] = char.ToUpper(sb[i]);
            }
            key = key.ToUpper();
            int j = 0;
            for(int i = 0; i < sb.Length; i++)
            {
                if (char.IsLetter(sb[i]))
                {
                    sb[i] = sb[i] >= key[j] ? (char)(sb[i] - key[j] + 'A') :
                        (char)('A' + ('Z' - key[j] + sb[i] - 'A') + 1);
                }
                j = j + 1 == key.Length ? 0 : j + 1;
            }
            
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                StreamReader sr = new StreamReader(File.OpenRead(filePath));
                txtEncrypted.Text = sr.ReadToEnd();
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder(txtEncrypted.Text);
                string key = txtKey.Text;

                lblKey.Text = key;
                Encrypt(ref sb, key);
                txtDecrypted.Text = Convert.ToString(sb);
            }
            catch
            {
                MessageBox.Show("ERROR");
            }

        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder(txtEncrypted.Text);
                string key = txtKey.Text;

                lblKey.Text = key;
                Decrypt(ref sb, key);
                txtDecrypted.Text = Convert.ToString(sb);
            }
            catch
            {
                MessageBox.Show("ERROR");
            }

        }


    }
}
