﻿using System.Net.Sockets;
using System.Text;

namespace SP_1._1
{
    internal class Program
    {
        static async Task Main()
        {
            ConnectToServer();
        }
        static void ConnectToServer()
        {
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 8888);
                Console.WriteLine("Привет, сервер!");

                NetworkStream stream = client.GetStream();

                byte[] data = new byte[256];
                StringBuilder responseData = new StringBuilder();
                int bytes;


                do
                {
                    bytes = stream.Read(data, 0, data.Length);
                    responseData.Append(Encoding.ASCII.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable);


                Console.WriteLine("Текущее время с сервера: " + responseData.ToString());


                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }
}
