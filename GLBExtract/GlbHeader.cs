using System.IO;
using System.Text;

namespace GLBExtract
{
    public class GlbHeader
    {
        public string FormatID { get; private set; }
        public int FileCount { get; private set; }

        private GlbHeader() { }

        public static GlbHeader Read(BinaryReader binaryReader)
        {
            var glbHeader = new GlbHeader
            {
                FormatID = Encoding.UTF8.GetString(binaryReader.ReadBytes(8)),
                FileCount = binaryReader.ReadInt32()
            };

            return glbHeader;
        }
    }
}
