using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace UnityExtensions
{
    public static partial class CryptUtility
    {
        private const string PasswordChars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static void EncryptAESWithECB(byte[] src, out byte[] dst, byte[] key)
        {
            using (RijndaelManaged rijndael = new RijndaelManaged())
            {
                rijndael.Padding = PaddingMode.PKCS7;
                rijndael.Mode = CipherMode.ECB;
                rijndael.Key = key;
                rijndael.BlockSize = 128;
                
                using (ICryptoTransform encryptor = rijndael.CreateEncryptor())
                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    cs.Write(src, 0, src.Length);
                    cs.FlushFinalBlock();
                    dst = ms.ToArray();
                }
            }
        }

        public static void EncryptAESWithECB(string src, out string dst, string key)
        {
            byte[] resultDst = null;
            EncryptAESWithECB(Encoding.UTF8.GetBytes(src), out resultDst, Encoding.UTF8.GetBytes(key));
            dst = Convert.ToBase64String(resultDst);
        }

        public static void DecryptAESWithECB(byte[] src, out byte[] dst, byte[] key)
        {
            dst = new byte[src.Length];
            using (RijndaelManaged rijndael = new RijndaelManaged())
            {
                rijndael.Padding = PaddingMode.PKCS7;
                rijndael.Mode = CipherMode.ECB;
                rijndael.Key = key;
                rijndael.BlockSize = 128;
                
                using (ICryptoTransform decryptor = rijndael.CreateDecryptor())
                using (MemoryStream ms = new MemoryStream(src))
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    cs.Read(dst, 0, dst.Length);
                }
            }
        }

        public static void DecryptAESWithECB(string src, out string dst, string key)
        {
            byte[] resultDst = null;
            DecryptAESWithECB(Convert.FromBase64String(src), out resultDst, Encoding.UTF8.GetBytes(key));
            dst = Encoding.UTF8.GetString(resultDst).Trim('\0');
        }

        public static void EncryptAESWithCBC(byte[] src, byte[] key, int encryptKeyCount, out byte[] iv, out byte[] dst)
        {
            iv = Encoding.UTF8.GetBytes(CreatePassword(encryptKeyCount));

            using (RijndaelManaged rijndael = new RijndaelManaged())
            {
                rijndael.Padding = PaddingMode.PKCS7;
                rijndael.Mode = CipherMode.CBC;
                rijndael.BlockSize = 128;

                using (ICryptoTransform encryptor = rijndael.CreateEncryptor(key, iv))
                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    cs.Write(src, 0, src.Length);
                    cs.FlushFinalBlock();
                    dst = ms.ToArray();
                }
            }
        }

        public static void EncryptAESWithCBC(string src, string key, int encryptKeyCount, out string iv, out string dst)
        {
            byte[] resultIv = null;
            byte[] resultDst = null;
            EncryptAESWithCBC(Encoding.UTF8.GetBytes(src), Encoding.UTF8.GetBytes(key), encryptKeyCount, out resultIv, out resultDst);
            iv = Encoding.UTF8.GetString(resultIv);
            dst = Convert.ToBase64String(resultDst);
        }

        public static void DecryptAESWithCBC(byte[] src, byte[] key, byte[] iv, out byte[] dst)
        {
            dst = new byte[src.Length];
            using (RijndaelManaged rijndael = new RijndaelManaged())
            {
                rijndael.Padding = PaddingMode.PKCS7;
                rijndael.Mode = CipherMode.CBC;
                rijndael.KeySize = 256;
                rijndael.BlockSize = 128;
                
                using (ICryptoTransform decryptor = rijndael.CreateDecryptor(key, iv))
                using (MemoryStream ms = new MemoryStream(src))
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    cs.Read(dst, 0, dst.Length);
                }
            }
        }

        public static void DecryptAESWithCBC(string src, string key, string iv, out string dst)
        {
            byte[] resultDst = null;
            DecryptAESWithCBC(Convert.FromBase64String(src), Encoding.UTF8.GetBytes(key), Encoding.UTF8.GetBytes(iv), out resultDst);
            dst = Encoding.UTF8.GetString(resultDst);
        }

        public static void EncryptCRC32(byte[] src, out byte[] dst)
        {
            CRC crc = new CRC();
            dst = crc.ComputeHash(src);
        }

        public static void EncryptCRC32(string src, out string dst)
        {
            byte[] resultDst = null;
            EncryptCRC32(Encoding.UTF8.GetBytes(src), out resultDst);
            dst = BitConverter.ToString(resultDst).Replace("-", string.Empty).ToLower();
        }

        private static string CreatePassword(int count)
        {
            System.Random rand = new System.Random();
            StringBuilder sb = new StringBuilder(count);
            for (int i = count - 1; i >= 0; i--)
            {
                char c = PasswordChars[rand.Next(0, PasswordChars.Length - 1)];
                sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
