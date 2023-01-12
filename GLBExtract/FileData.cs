namespace GLBExtract
{
    public class FileData
    {
        public byte[] Data { get; set; }
        public string ActualFilename { get; set; }

        public FileData(byte[] data, string rawFileName)
        {
            Data = data;
            ActualFilename = ConvertFileName(rawFileName);
        }

        private string ConvertFileName(string rawFileName)
        {
            var underScoreIndex = rawFileName.IndexOf('_');

            if (underScoreIndex < 0)
                return rawFileName;

            var fileType = rawFileName.Substring(0, underScoreIndex);
            var fileName = rawFileName.Substring(underScoreIndex + 1, rawFileName.Length - underScoreIndex - 1);

            switch (fileType)
            {
                case "MID":
                    return $"{fileName}.mid";
                case "W":
                    return $"{fileName}.wav";
                case "S":
                    return $"{fileName}.spr";
                default:
                    return $"{fileName}.{fileType}";
            }
        }
    }
}
