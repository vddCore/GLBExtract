using System.Collections.Generic;
using System.IO;

namespace GLBExtract
{
    public class GlbFile
    {
        private FileStream FileStream { get; set; }
        private BinaryReader BinaryReader { get; set; }

        public GlbHeader Header { get; private set; }
        public List<ArchFile> FileTable { get; }
        public List<FileData> FileData { get; }

        public GlbFile(string fileName)
        {
            FileTable = new List<ArchFile>();
            FileData = new List<FileData>();

            Parse(fileName);
            ReadFileData();
        }

        private void Parse(string fileName)
        {
            FileStream = new FileStream(fileName, FileMode.Open);
            BinaryReader = new BinaryReader(FileStream);

            Header = GlbHeader.Read(BinaryReader);
            for (var i = 0; i < Header.FileCount; i++)
            {
                FileTable.Add(ArchFile.Read(BinaryReader));
            }
        }

        private void ReadFileData()
        {
            foreach (var file in FileTable)
            {
                if (file.Flags != 0) continue;

                FileStream.Seek(file.Offset, SeekOrigin.Begin);
                var data = BinaryReader.ReadBytes(file.Length);

                FileData.Add(new FileData(data, file.FileName));
            }   
        }
    }
}
