using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BALANCA
{
    class Program
    {
        static void Main(string[] args)
        {
            
            SerialPort mySerialPort = new SerialPort("COM1");

            mySerialPort.BaudRate = 2400;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.None;
            mySerialPort.Open();
            //Receita do pó mágico
            byte[] buf = new byte[] {
                5,
                13
            };
            //Jogando o pó mágico õõõõ
            mySerialPort.Write(buf, 0, buf.Length);
            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

           
            Console.WriteLine("Press any key to continue...");
            Console.WriteLine();
            Console.ReadKey();
            mySerialPort.Close();
        }

        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            
            string indata = sp.ReadExisting();
            Console.WriteLine("Data Received:");
            //Mostrando o resultado, apagando os delimitadores
            Console.WriteLine(indata.Substring(1,indata.Length - 2));
            
            Console.ReadKey();
        }
    }
}
