﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SISCO.App
{
    public class SymmetricCryptor
    {
        private const string ENCRYPTION_KEY = "GlonalindoDuaSatuEkspres_PuloGadung";
 
        #region Encryption/decryption
        /// <summary>
        /// The salt value used to strengthen the encryption.
        /// </summary>
        private static readonly byte[] Salt = Encoding.ASCII.GetBytes(ENCRYPTION_KEY.Length.ToString());
 
        /// <summary>
        /// Encrypts any string using the Rijndael algorithm.
        /// </summary>
        /// <param name="inputText">The string to encrypt.</param>
        /// <returns>A Base64 encrypted string.</returns>
        public static string Encrypt(string inputText)
        {
            var rijndaelCipher = new RijndaelManaged();
            byte[] plainText = Encoding.Unicode.GetBytes(inputText.Replace(" ", "+"));
            //Rfc2898DeriveBytes secretKey1 = new Rfc2898DeriveBytes(ENCRYPTION_KEY, SALT);
            var SecretKey = new PasswordDeriveBytes(ENCRYPTION_KEY, Salt);
            using (
            ICryptoTransform encryptor = rijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32),
            SecretKey.GetBytes(16)))
            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainText, 0, plainText.Length);
                    cryptoStream.FlushFinalBlock();
                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }   
        }
 
        /// <summary>
        /// Decrypts a previously encrypted string.
        /// </summary>
        /// <param name="inputText">The encrypted string to decrypt.</param>
        /// <returns>A decrypted string.</returns>
        public static string Decrypt(string inputText)
        {
            var rijndaelCipher = new RijndaelManaged();
            byte[] encryptedData = Convert.FromBase64String(inputText);
            //Rfc2898DeriveBytes secretKey1 = new Rfc2898DeriveBytes(ENCRYPTION_KEY, SALT);
            var secretKey = new PasswordDeriveBytes(ENCRYPTION_KEY, Salt);
            using (ICryptoTransform decryptor = rijndaelCipher.CreateDecryptor(secretKey.GetBytes(32), secretKey.GetBytes(16)))
            {
                using (var memoryStream = new MemoryStream(encryptedData))
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        var plainText = new byte[encryptedData.Length];
                        int decryptedCount = cryptoStream.Read(plainText, 0, plainText.Length);
                        return Encoding.Unicode.GetString(plainText, 0, decryptedCount).Replace("+", " ");
                    }
                }
            }
        }
 
        #endregion
    }
}
