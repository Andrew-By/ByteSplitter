using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteSplitter
{
    class Program
    {
        static void Main(string[] args)
        {
            var bytes = new byte[] { 0x01, 0x02, 0x03, 0x04, (byte)'\r', (byte)'\n', 0x04, 0x03, 0x02, (byte)'\r', (byte)'\n', 0x02, 0x03, 0x04 };
            var s = new Splitter(Encoding.ASCII.GetBytes("\r\n"));
            s.Append(bytes);
            var chunks = s.PopChunks();
        }
    }
}
