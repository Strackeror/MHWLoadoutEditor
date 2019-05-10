namespace MHWLoadoutEdit.SaveData
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    partial class SaveFile
    {
        private readonly string key = "xieZjoe#P2134-3zmaghgpqoe0z8$3azeq";
        private byte[] data;

        public byte[] Data
        {
            get => data;
        }

        private static byte[] SwapBytes(byte[] data)
        {
            var swapped = new byte[data.Length];
            for (var i = 0; i < data.Length; i += 4)
            {
                swapped[i] = data[i + 3];
                swapped[i + 1] = data[i + 2];
                swapped[i + 2] = data[i + 1];
                swapped[i + 3] = data[i];
            }

            return swapped;
        }

        private void Decrypt()
        {
            data = SwapBytes(data);
            data = new Blowfish(Encoding.Default.GetBytes(key)).Decrypt_ECB(data);
            data = SwapBytes(data);
        }

        private byte[] EncryptData()
        {
            var encryptedData = data;
            Array.Copy(
                SHA1.Create().ComputeHash(encryptedData.Skip(64).ToArray()), 0,
                encryptedData, 64,
                encryptedData.Length - 64);
            encryptedData = SwapBytes(encryptedData);
            encryptedData = new Blowfish(Encoding.Default.GetBytes(key)).Encrypt_ECB(encryptedData);
            encryptedData = SwapBytes(encryptedData);
            return encryptedData;
        }
    }
}