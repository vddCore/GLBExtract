using System.IO;
using System.Text;

namespace GLBExtract
{
    public class ArchFile
    {
        public int Flags { get; private set; }
        public int Offset { get; private set; }
        public int Length { get; private set; }
        public string FileName { get; private set; }

        private ArchFile() { }

        public static ArchFile Read(BinaryReader binaryReader)
        {
            var archFile = new ArchFile
            {
                Flags = binaryReader.ReadInt32(),
                Offset = binaryReader.ReadInt32(),
                Length = binaryReader.ReadInt32(),
                FileName = Encoding.UTF8.GetString(binaryReader.ReadBytes(16))
            };

            return archFile;
        }
    }
}
