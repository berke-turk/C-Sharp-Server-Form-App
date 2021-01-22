using System;
using System.Collections;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_ServerStart_Click(object sender, EventArgs e)
        {
            if(textBox_port_1.Text != null && textBox_port_1.Text != "" && textBox_maxPlayer_1.Text != null && textBox_maxPlayer_1.Text != "")
            {
                ServerSettings.SetupServer(Convert.ToInt32(textBox_maxPlayer_1.Text),Convert.ToInt32(textBox_port_1.Text)); // Max player ve Port numarasını girdik.
                ServerSettings.StartServer(); // Serveri başlat.
                this.Hide();
            }
        }

    }
}
