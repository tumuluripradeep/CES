using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleAppDecrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            string clientSecret = Decrypt("TXwc6nLf8kGUMGndh+Sjd682d46VqlVGkP6Cyx/htLx8XoH/AzgXES2M1eiPnLYl/JvR6067qFfFRNJnFF3XozI1AcPotoprtB4FVbnjtxo=");
        }



        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "&xvz7]k(Evd+8[<";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}
