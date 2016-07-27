using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptFile
{
    class Program
    {
        static void Main(string[] args)
        {
            const int bufSize = 1000000;

            var input = @"input.txt";
            var encrypted = @"working.encrypted";
            var decrypted = @"output.txt";

            if (File.Exists(input))
                File.Delete(input);

            if (File.Exists(encrypted))
                File.Delete(encrypted);

            if (File.Exists(decrypted))
                File.Delete(decrypted);

            var size = 1000;
            if (args != null && args.Length > 0)
                int.TryParse(args[0], out size);

            GenerateRandomFile(input, size);

            // Create an RijndaelManaged object 
            // with the specified key and IV. 
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                var key = "blah";
                rijAlg.Key = MakeKey(key);
                rijAlg.IV = IV64Bytes;

                var sw = new Stopwatch();

                if (!File.Exists(encrypted))
                {

                    sw.Start();

                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                    using (var inputFileStream = File.OpenRead(input))
                    using (var outputFileStream = File.OpenWrite(encrypted))
                    using (CryptoStream csEncrypt = new CryptoStream(outputFileStream, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        var buf = new byte[bufSize];

                        int length = 0;
                        int offset = 0;
                        int loopCnt = 0;

                        do
                        {
                            length = inputFileStream.Read(buf, 0, buf.Length);
                            //Write all data to the stream.
                            csEncrypt.Write(buf, 0, length);
                            offset += length;
                            loopCnt++;
                        } while (length > 0);
                    }

                    sw.Stop();
                    Console.WriteLine("encrypted in {0}ms", sw.Elapsed.Milliseconds);
                }

                sw.Reset();
                sw.Start();

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption. 
                using (var msDecrypt = File.OpenRead(encrypted))
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var decryptedFile = File.OpenWrite(decrypted))
                {
                    var buf = new byte[bufSize];

                    int length = 0;
                    int offset = 0;
                    int loopCnt = 0;

                    do
                    {
                        length = csDecrypt.Read(buf, 0, buf.Length);
                        //Write all data to the stream.
                        decryptedFile.Write(buf, 0, length);
                        offset += length;
                        loopCnt++;
                    } while (length > 0);
                }

                sw.Stop();
                Console.WriteLine("decrypted in {0}ms", sw.Elapsed.Milliseconds);
            }

            Console.WriteLine("press enter to exit");
            Console.ReadLine();

        }

        private static void GenerateRandomFile(string filePath, int size)
        {
            var random = new Random();

            using (var stream = File.OpenWrite(filePath))
            {
                using (var writer = new StreamWriter(stream))
                {
                    for (var i = 0; i < size; i++)
                    {
                        var ch = (char)random.Next(48, 90);
                        writer.Write(ch);
                    }
                }
            }
        }

        private static string GenerateIV()
        {
            using (RijndaelManaged myRijndael = new RijndaelManaged())
            {
                myRijndael.GenerateIV();
                return Convert.ToBase64String(myRijndael.IV);
            }
        }

        const string iv64 = "qq3ThXDKVjyRwKRKhkyhlQ==";
        static byte[] _iv64Bytes = null;
        const string extraCharacters = "xyzae55a03794f139a175fc9a9c95323a1z7111z609f423a9z956bfc9b98ffff";

        private static byte[] IV64Bytes
        {
            get
            {
                if (_iv64Bytes == null)
                    _iv64Bytes = Convert.FromBase64String(iv64);
                return _iv64Bytes;
            }
        }

        private static byte[] MakeKey(string password)
        {
            password = password + extraCharacters;
            var bytes = Encoding.UTF8.GetBytes(password.ToCharArray(), 0, 32);
            return bytes;
        }
    }
}
