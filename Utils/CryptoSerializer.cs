using System.IO;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;

namespace TerapiaReembolso
{
    public class CryptoSerializer
    {
        private static byte[] key = { 53, 12, 43, 74, 95, 26, 117, 28 };
        private static byte[] iv = { 53, 12, 43, 74, 95, 26, 117, 28 };

        private static DESCryptoServiceProvider des = new DESCryptoServiceProvider();

        public static void Serialize<T>(string path, T _listaPacientes)
        {
            // Encryption
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            using (var cryptoStream = new CryptoStream(fs, des.CreateEncryptor(key, iv), CryptoStreamMode.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // This is where you serialize the class
                formatter.Serialize(cryptoStream, _listaPacientes);
            }
        }

        public static T DeSerialize<T>(string path)
        {
            // Decryption
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (var cryptoStream = new CryptoStream(fs, des.CreateDecryptor(key, iv), CryptoStreamMode.Read))
            {
                // This is where you deserialize the class
                BinaryFormatter formatter = new BinaryFormatter();
                T deserialized = (T)formatter.Deserialize(cryptoStream);
                return deserialized;
            }
        }
    }
}
