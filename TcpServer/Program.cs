using System.Net.Sockets;
using System.Net;
using System.Text;

namespace TcpServer
{
    class Program
    {
        static void Main()
        {
            StartServer();
        }

        public static void StartServer()
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int port = 8888;
            TcpListener listener = new TcpListener(ipAddress, port);

            try
            {
                listener.Start();
                Console.WriteLine("Сервер запущен...");

                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    Console.WriteLine("Привет, клиент!");

                    NetworkStream stream = client.GetStream();

                    string currentTime = DateTime.Now.ToString();
                    byte[] data = Encoding.ASCII.GetBytes(currentTime);

                    stream.Write(data, 0, data.Length);
                    Console.WriteLine("Отправлено время: " + currentTime);

                    client.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            finally
            {
                listener.Stop();
            }
        }
    }
}

