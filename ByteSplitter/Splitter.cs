using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteSplitter
{
    public class Splitter
    {
        private List<byte> _bytes;
        private byte[] _delimeter;

        public Splitter(byte[] delimiter)
        {
            _bytes = new List<byte>();
            _delimeter = delimiter;
        }

        public void Append(byte[] bytes)
        {
            _bytes.AddRange(bytes);
        }

        public byte[][] PopChunks()
        {
            var parts = new List<byte[]>();
            var index = 0;
            for (var i = 0; i < _bytes.Count; ++i)
            {
                if (Equals(i))
                {
                    parts.Add(_bytes.GetRange(index, i - index).ToArray());
                    index = i + _delimeter.Length;
                    i += _delimeter.Length - 1;
                }
            }
            //parts.Add(_bytes.GetRange(index, _bytes.Count - index).ToArray());
            _bytes.RemoveRange(0, index);
            return parts.ToArray();
        }

        private bool Equals(int index)
        {
            for (int i = 0; i < _delimeter.Length; ++i)
                if (index + i >= _bytes.Count || _bytes[index + i] != _delimeter[i])
                    return false;
            return true;
        }
    }
}
