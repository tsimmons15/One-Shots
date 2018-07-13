using System.Security.Cryptography;

namespace SinglePlayer.Database
{
    class DatabaseInteraction
    {
        //Is there anything that needs to be encrypted?
        private void Encrypt(string password)
        {
            SHA512Managed test = new SHA512Managed();
            byte[] hash = test.ComputeHash(Miscellaneous.StringToBytes(password));
        }
    }
}
