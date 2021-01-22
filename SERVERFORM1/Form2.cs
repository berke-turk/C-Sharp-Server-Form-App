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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false; // Static bir classtan asenkron şekilde bu formu kontrol ettiğimiz için program patlıyor. Bunun için çapraz thread'ı false yapıyorum.
        }

        public void listBox_Update_ADD(int id,string name){
            listBox_users.Items.Add(name);
        }

        public void listBox_Update_DELETE(int id)
        {
            listBox_users.Items.RemoveAt(id -1);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            // Disconnect Server and Close
            ServerSettings.DisconnectServer(); // Server'ı kapattık.
            Application.Exit(); // Uygulamadan çıktık
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kontrol edilecek client seçilmiştir :)
            // listBox_console.Items.Add(comboBox_users.SelectedIndex);
            Form3 frm3 = new Form3();
            frm3.Show();
            frm3.SetUpForm(comboBox_users.SelectedIndex + 1, $"Kullanıcı {comboBox_users.SelectedItem}");
        }
    }
}
