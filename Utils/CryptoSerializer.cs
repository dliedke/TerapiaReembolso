/* *******************************************************************************************************************
 * Aplicação: TerapiaReembolso
 * 
 * Autor:  Daniel Liedke
 * 
 * Copyright © Daniel Liedke 2022
 * Usage and reproduction in any manner whatsoever without the written permission of Daniel Liedke is strictly forbidden.
 *  
 * Propósito: Salvar e carregar classes em arquivo criptografado
 *           
 * *******************************************************************************************************************/

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

        public static void Serialize<T>(string path, T objeto)
        {
            // Criptografia
            using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            using (var cryptoStream = new CryptoStream(fileStream, des.CreateEncryptor(key, iv), CryptoStreamMode.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Serializa o objeto como binario pro disco
                formatter.Serialize(cryptoStream, objeto);
            }
        }

        public static T DeSerialize<T>(string path)
        {
            // Decriptografa
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (var cryptoStream = new CryptoStream(fs, des.CreateDecryptor(key, iv), CryptoStreamMode.Read))
            {
                // Deserializa o objeto
                BinaryFormatter formatter = new BinaryFormatter();
                T deserialized = (T)formatter.Deserialize(cryptoStream);
                return deserialized;
            }
        }
    }
}
