using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERVERFORM1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            
        }
        public int id;
        public void SetUpForm(int _id,string _title)
        {
            id = _id;
            Text = _title;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Sol
            ServerSettings.Send_IMAGEPOSITION(id,5,0,0,0); // Sadece Left e değer verdim
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Sağ
            ServerSettings.Send_IMAGEPOSITION(id, 0, 5, 0, 0); // Sadece Rıght e değer verdim
        }

        private void button3_Click(object sender, EventArgs e) 
        {
            // Yukarı
            ServerSettings.Send_IMAGEPOSITION(id, 0, 0, 5, 0); // Sadece UP e değer verdim
        }
        private void button4_Click(object sender, EventArgs e)
        {
            // Aşağı
            ServerSettings.Send_IMAGEPOSITION(id, 0, 0, 0, 5); // Sadece DOWN e değer verdim
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
