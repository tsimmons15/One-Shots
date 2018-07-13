using System;

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

        public static string GenerateID()
        {
            Guid id = Guid.NewGuid();
            return id.ToString("N");
        }
    }
}
