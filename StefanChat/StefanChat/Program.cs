using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace StefanChat
{
    //By Stefan Christiansson 2018-01-15

    class Program
    {
        private const int ListenPort = 11000;

        static void Main(string[] args)
        {

        }

        static void Listener()
        {
            var listener = new UdpClient(ListenPort);

            try
            {
                while (true)
                {
                    var groupEP = new IPEndPoint(IPAddress.Any, ListenPort);
                    var bytes = listener.Receive(ref groupEP);
                    Console.WriteLine("Revieved broadcast from {0} : {1}\n", groupEP.ToString(),
                        Encoding.UTF8.GetString(bytes, 0, bytes.Length));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            finally
            {
                listener.Close();
            }
        }
    }
}
