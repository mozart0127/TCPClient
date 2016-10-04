using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class connection
    {
        public String receiveData = null;
        public string iPAddress;
        public int Port;
        public TcpClient tcpClient;


        public connection(string ipAddress, int port)
        {
            tcpClient = new TcpClient();
            iPAddress = ipAddress;
            Port = port;
            tcpClient.Connect(ipAddress, port);
        }
        public async Task<string> ReadData()
        {


                NetworkStream clientStream = tcpClient.GetStream();
                byte[] data = new byte[4096];
                Task<int> bytesRead;
            while (clientStream.CanRead)
            {
                try
                {

                    bytesRead = clientStream.ReadAsync(data, 0, 4096);
                    int bytesread = await bytesRead;
                    ASCIIEncoding encoder = new ASCIIEncoding();
                    receiveData = encoder.GetString(data, 0, bytesread);

                }
                catch (Exception ex)
                {
                    //Process the error, write to logs, etc. 
                }
                return receiveData;
            }
            return "done";
        }
        public void sentData(string msg)
        {
            NetworkStream stream = tcpClient.GetStream();
            Byte[] datad = System.Text.Encoding.ASCII.GetBytes(msg);


            stream.Write(datad, 0, datad.Length);
        }

    }
}
