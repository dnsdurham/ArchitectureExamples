using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptFile
{
    class Program
    {
        const int bufSize = 100000;

        static void Main(string[] args)
        {
            var input = @"input.txt";

            var compress = @"working.compress";
            var decompress = @"output.txt";

            var encrypted = @"working.encrypted";
            var decrypted = @"working.decrypted";

            if (File.Exists(input))
                File.Delete(input);

            if (File.Exists(encrypted))
                File.Delete(encrypted);

            if (File.Exists(decrypted))
                File.Delete(decrypted);

            if (File.Exists(compress))
                File.Delete(compress);

            if (File.Exists(decompress))
                File.Delete(decompress);

            var size = 1000;
            if (args != null && args.Length > 0)
                int.TryParse(args[0], out size);

            Console.WriteLine("size = " + size.ToString());

            GenerateRandomFile(input, size);

            CompressFile(input, compress);
            EncryptFile(compress, encrypted);
            DecryptFile(encrypted, decrypted);
            DecompressFile(decrypted, decompress);

            Console.WriteLine("press enter to exit");
            Console.ReadLine();

        }

        private static void CompressFile(string input, string output)
        {
            var sw = new Stopwatch();
            sw.Start();

            using (var inFile = File.OpenRead(input))
            using (var outFile = File.Create(output))
            using (var Compress = new GZipStream(outFile, CompressionMode.Compress))
            {
                byte[] buffer = new byte[bufSize];
                int numRead;
                while ((numRead = inFile.Read(buffer, 0, buffer.Length)) != 0)
                {
                    Compress.Write(buffer, 0, numRead);
                }
            }

            sw.Stop();
            Console.WriteLine("compressed in {0}ms", sw.Elapsed.TotalMilliseconds);
        }

        private static void DecompressFile(string input, string output)
        {
            var sw = new Stopwatch();
            sw.Start();

            using (var inFile = File.OpenRead(input))
            using (var outFile = File.Create(output))
            using (var compress = new GZipStream(inFile, CompressionMode.Decompress))
            {
                byte[] buffer = new byte[bufSize];
                int numRead;
                while ((numRead = compress.Read(buffer, 0, buffer.Length)) != 0)
                {
                    outFile.Write(buffer, 0, numRead);
                }
            }

            sw.Stop();
            Console.WriteLine("decompressed in {0}ms", sw.Elapsed.TotalMilliseconds);
        }

        private static void EncryptFile(string input, string output)
        {
            var sw = new Stopwatch();
            sw.Start();

            // Create an RijndaelManaged object 
            // with the specified key and IV. 
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                var key = "blah";
                rijAlg.Key = MakeKey(key);
                rijAlg.IV = IV64Bytes;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                using (var inputFileStream = File.OpenRead(input))
                using (var outputFileStream = File.OpenWrite(output))
                using (var csEncrypt = new CryptoStream(outputFileStream, encryptor, CryptoStreamMode.Write))
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
                Console.WriteLine("encrypted in {0}ms", sw.Elapsed.TotalMilliseconds);
            }

        }

        public static void DecryptFile(string input, string output)
        {
            var sw = new Stopwatch();
            sw.Start();

            // Create an RijndaelManaged object 
            // with the specified key and IV. 
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                var key = "blah";
                rijAlg.Key = MakeKey(key);
                rijAlg.IV = IV64Bytes;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption. 
                using (var msDecrypt = File.OpenRead(input))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var decryptedFile = File.OpenWrite(output))
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
                Console.WriteLine("decrypted in {0}ms", sw.Elapsed.TotalMilliseconds);
            }
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
