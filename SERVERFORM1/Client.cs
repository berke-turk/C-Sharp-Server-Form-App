using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace SERVERFORM1
{
    class Client
    {
        public int id;
        public TCP tcp;
        public Client(int _id)
        {
            id = _id;
            tcp = new TCP(id);
        }

        public class TCP
        {
            public readonly int id;
            public TcpClient socket;
            public NetworkStream stream;
            public int dataBufferSize = 4096;
            public bool isConnected = false;
            public byte[] buffer;
            public TCP(int _id)
            {
                id = _id;
            }

            public void Disconnect()
            {
                socket.Close();
                stream.Close();
                stream = null;
                socket = null;
                isConnected = false;
                buffer = null;
                ServerSettings.DisconnectClient(id);
            }

            public void Connect(TcpClient _socket)
            {
                socket = _socket;
                socket.ReceiveBufferSize = dataBufferSize;
                socket.SendBufferSize = dataBufferSize;

                stream = socket.GetStream();
                buffer = new byte[dataBufferSize];
                isConnected = true;
                stream.BeginRead(buffer, 0, dataBufferSize, ReceiveCallBack, null); // Projemize göre şimdilik Client'tan Server'a veri atmıyoruz fakat disconnect işlemleri için okuma oluşturacağım.
            }

            public void ReceiveCallBack(IAsyncResult asyncResult) // Oyuncudan server'a veri gelirse okumak için
            {
                try
                {
                    int gelenVeriUzunlugu = stream.EndRead(asyncResult);
                    if (gelenVeriUzunlugu <= 0)
                    {
                        // Disconnect
                        Disconnect();
                        return;
                    }

                    stream.BeginRead(buffer, 0, dataBufferSize, ReceiveCallBack, null); // <-- Eğer yukarda disconnect olmazsa diye diğer gelecek verileri de dinliyoruz.

                    // Eğer bir işlem yapacaksak gelen veri üzerinde işlem yaparız. (Gelen veri buffer'a atılmış oluyor)
                }
                catch (Exception)
                {
                    // Disconnect
                    Disconnect();
                    return;
                }
            }

            public void SendDataFromJson(string _json)
            {
                byte[] data = Encoding.UTF8.GetBytes(_json);
                try
                {
                    stream.BeginWrite(data, 0, data.Length, SendCallBack, null);
                }
                catch (Exception)
                {
                    // Disconnect
                    Disconnect();
                    return;
                }
            }

            public void SendCallBack(IAsyncResult asyncResult)
            {
                stream.EndWrite(asyncResult);
            }
        }
    }
}
