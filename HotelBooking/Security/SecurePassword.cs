using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography;


namespace HotelBooking.Security
{
    public class SecurePassword
    {
        public static string Encrypt(string input)
        {
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(input)));
        }

        private static byte[] Encrypt(byte[] plainText)
        {
            byte[] encrypted = null;

            try
            {
                using (AesManaged aesAlg = new AesManaged())
                {
                    byte[] salt = new byte[] { 0x43, 0x87, 0x23, 0x72, 0x45, 0x56, 0x68, 0x14, 0x62, 0x84 };
                    PasswordDeriveBytes pdb = new PasswordDeriveBytes("abceffffd", salt);

                    aesAlg.Key = pdb.GetBytes(aesAlg.KeySize / 8);
                    aesAlg.IV = pdb.GetBytes(aesAlg.BlockSize / 8);

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(plainText, 0, plainText.Length);
                        csEncrypt.Close();
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            }
            catch
            {
                Console.Write("加密失敗");
                encrypted = plainText;
            }
            return encrypted;
        }

        public static string Decrypt2(string input)
        {
            return Decrypt2(Convert.FromBase64String(input));
        }

        private static string Decrypt2(byte[] cipherText)
        {
            byte[] salt = new byte[] { 0x43, 0x87, 0x23, 0x72, 0x45, 0x56, 0x68, 0x14, 0x62, 0x84 };
            PasswordDeriveBytes pdb = new PasswordDeriveBytes("abceffffd", salt);

            string plaintext = null;

            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = pdb.GetBytes(aesAlg.KeySize / 8);
                aesAlg.IV = pdb.GetBytes(aesAlg.BlockSize / 8);

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }

        public static string Decrypt(string input)
        {
            return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(input)));
        }

        private static byte[] Decrypt(byte[] cipherText)
        {
            byte[] salt = new byte[] { 0x43, 0x87, 0x23, 0x72, 0x45, 0x56, 0x68, 0x14, 0x62, 0x84 };
            PasswordDeriveBytes pdb = new PasswordDeriveBytes("abceffffd", salt);
            
            byte[] plaintext = null;

            try
            {
                using (AesManaged aesAlg = new AesManaged())
                {
                    aesAlg.Key = pdb.GetBytes(aesAlg.KeySize / 8);
                    aesAlg.IV = pdb.GetBytes(aesAlg.BlockSize / 8);

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (MemoryStream msDecrypt = new MemoryStream())
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, aesAlg.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            csDecrypt.Write(cipherText, 0, cipherText.Length);
                            csDecrypt.Close();
                            plaintext = msDecrypt.ToArray();
                        }
                    }
                }
            }
            catch
            {
                Console.Write("解密失敗");
                plaintext = cipherText;
            }
            return plaintext;
        }

        public static bool IsBase64String(string str)
        {
            try
            {
                Convert.FromBase64String(str);
            }
            catch
            {
                return false;
            }

            if (str == Encrypt(Decrypt(str))) // 解密再加密與輸入相同，表示加密過。
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}