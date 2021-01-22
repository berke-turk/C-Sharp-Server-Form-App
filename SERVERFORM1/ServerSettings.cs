using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace SERVERFORM1
{
    class ServerSettings : Form
    {
        public static int MAXPLAYERS;
        public static int PORTADDRESS;
        public static TcpListener serverListener;
        public static bool isStarted = false;
        public static Dictionary<int, Client> clients = new Dictionary<int, Client>();

        // Form yönetimi
        public static Form2 frm2;

        public static void SetupServer(int newMAXPLAYERS,int newPORTADDRESS)
        {
            MAXPLAYERS = newMAXPLAYERS;
            PORTADDRESS = newPORTADDRESS;
            serverListener = new TcpListener(IPAddress.Any,PORTADDRESS);
            IntializeServer(); // Oyuncu koltukları ;)
        }

        public static void StartServer()
        {
            serverListener.Start();
            isStarted = true;
            serverListener.BeginAcceptTcpClient(new AsyncCallback(AcceptTcpClientCallBack), null); // Client Kabul işlemi
            frm2 = new Form2();
            frm2.Show();
            frm2.listBox_console.Items.Add($"Server başlatıldı... \n PORT : {PORTADDRESS} , MAKSİMUM OYUNCU : {MAXPLAYERS}");
        }

        public static void AcceptTcpClientCallBack(IAsyncResult asyncResult)
        {
            try
            {
                TcpClient socket = serverListener.EndAcceptTcpClient(asyncResult); // Bağlanan socketi aldık.
                serverListener.BeginAcceptTcpClient(new AsyncCallback(AcceptTcpClientCallBack), null); // Diğer gelenleri, gelecekleri kabul et.
                for (int i = 1; i <= MAXPLAYERS; i++)
                {
                    if (clients[i].tcp.socket == null && !clients[i].tcp.isConnected)
                    {
                        // Koltuğa oturt
                        clients[i].tcp.Connect(socket); // :))
                        frm2.listBox_console.Items.Add("Bir kullanıcı katıldı.");
                        frm2.listBox_Update_ADD(i, $"Kullanıcı : {i}");
                        frm2.label_usersCount.Text = $"Kullanıcı sayısı : {ConnectedUsers_Count()}";
                        frm2.comboBox_users.Items.Add($"Kullanıcı : {i}");
                        return; // Metodu kes.
                    }
                }

                // Metod kesilmediyse, koltuğa oturtulmamışsa, disconnect olsun.
                socket.Close();
                frm2.listBox_console.Items.Add("Oda dolu.");
                return;
            }
            catch (Exception)
            {
                return;
            }
        }

        public static void IntializeServer()
        {
            for(int i = 1; i <= MAXPLAYERS; i++)
            {
                clients.Add(i, new Client(i));
            }
        }

        public static int ConnectedUsers_Count()
        {
            int sayac = 0;
            for (int i = 1; i <= MAXPLAYERS; i++)
            {
                if(clients[i].tcp.socket != null && clients[i].tcp.isConnected)
                {
                    sayac++;
                }
            }
            return sayac;
        }

        public static void DisconnectServer()
        {
            serverListener.Stop();
        }

        public static void DisconnectClient(int _id)
        {
            frm2.comboBox_users.Items.RemoveAt(_id - 1); // <-- İtems'de birinci nesne 0 'indexe sahiptir fakat ben IntializeServer() metodunda clients nesnemin içini doldururken 1 den başlıyorum. O yüzden böyle bir mantık yürüttüm.
            frm2.listBox_users.Items.RemoveAt(_id - 1); // <-- Üstekiyle Aynı mantık
            frm2.label_usersCount.Text = $"Kullanıcı sayısı : {ConnectedUsers_Count()}";
            frm2.listBox_console.Items.Add($"Çıktı, no : {_id}.");
        }

        public static void Send_IMAGEPOSITION(int _id,int _LEFT,int _RIGHT,int _UP,int _DOWN)
        {
            Handlers.ImagePositionPacket sendPacket = Handlers.CreateImagePositionPacket(_id, (int)Handlers.ServerHandler.ImagePosition, _LEFT, _RIGHT, _UP, _DOWN); // Paketi oluşturdum
            // Şimdi ise gerekli yere göndermek kaldı. Aldığımız _id değişkenin değerine sahip olan client nesnemizin send metoduna gircez :)
            // Tabi önce bu packeti json string'e çevirmeliyiz. Bunun için Newtonsoft Json Kütüphanesine ihtiyacımız var. Nuget paketlerinden import ettim. 
            string json = JsonConvert.SerializeObject(sendPacket);
            // Çevirdik. Şimdi gönderelim ! Hatta göndermeden önce Debug liste ekleyelim test amaçlı :)

            frm2.listBox_console.Items.Add(json); // <---

            clients[_id].tcp.SendDataFromJson(json); // clients' dizisinin arasında istediğimiz id'ye sahip olan client'in gönderme metodunu çalıştırdım. :)
        }
    }
}
