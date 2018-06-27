using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SinglePlayer.Database
{
    class DatabaseInteraction
    {
        private void Encrypt(string password)
        {
            SHA512Managed test = new SHA512Managed();
            byte[] hash = test.ComputeHash(Miscellaneous.StringToBytes(password));

        }
    }
}
