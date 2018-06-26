using MudServer.Server_Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MudServer.Database
{
    class DBInterface
    {
        private void Encrypt(string password)
        {
            SHA512Managed test = new SHA512Managed();
            byte[] hash = test.ComputeHash(Miscellaneous.StringToBytes(password));

        }
    }
}
