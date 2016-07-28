using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Accessors
{
    public interface IFileReader
    {
        string Read(string filePath, int start);
        int NumberOfParts(string path);
    }

    class FileReader : BaseResourceAccessor, IFileReader
    {
        const int count = 10000;

        public int NumberOfParts(string path)
        {
            var f = new FileInfo(path);
            return (int)f.Length / count;
        }

        public string Read(string filePath, int start)
        {
            int offset = start * count;
            var buf = new byte[count];

            using (var stream = File.OpenRead(filePath))
            {
                stream.Seek(offset, SeekOrigin.Begin);
                stream.Read(buf, 0, count);

                return System.Text.Encoding.Default.GetString(buf);
            }
        }
    }
}
