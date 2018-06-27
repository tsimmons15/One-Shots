using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePlayer
{
    class Miscellaneous
    {
        public static byte[] StringToBytes(string text)
        {
            byte[] buff = new byte[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                buff[i] = (byte)text[i];
            }

            return buff;
        }
    }
}
