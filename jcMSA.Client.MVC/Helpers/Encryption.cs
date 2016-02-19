using System.IO;
using System.Security.Cryptography;

namespace jcMSA.Client.MVC.Helpers {
    public class Encryption {
        public static byte[] Encrypt(string unencryptedString) {
            using (var myRijndael = new RijndaelManaged()) {
                myRijndael.GenerateKey();
                myRijndael.GenerateIV();

                return EncryptStringToBytes(unencryptedString, myRijndael.Key, myRijndael.IV);
            }
        }

        public static string Decrypt(byte[] encryptedString) {
            using (var myRijndael = new RijndaelManaged()) {
                myRijndael.GenerateKey();
                myRijndael.GenerateIV();

                return DecryptStringFromBytes(encryptedString, myRijndael.Key, myRijndael.IV);
            }
        }

        static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV) {
            string plaintext = null;

            using (var rijAlg = new RijndaelManaged()) {
                rijAlg.Key = Key;
                rijAlg.IV = IV;
                
                var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
                
                using (var msDecrypt = new MemoryStream(cipherText)) {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)) {
                        using (var srDecrypt = new StreamReader(csDecrypt)) {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;
        }
        
        static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV) {
            byte[] encrypted;

            using (var rijAlg = new RijndaelManaged()) {
                rijAlg.Key = Key;
                rijAlg.IV = IV;
                
                var encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);
                
                using (var msEncrypt = new MemoryStream()) {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)) {
                        using (var swEncrypt = new StreamWriter(csEncrypt)) {
                            swEncrypt.Write(plainText);
                        }

                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return encrypted;
        }
    }
}