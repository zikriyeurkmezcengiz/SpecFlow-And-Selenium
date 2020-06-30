using System;
using System.IO;
using System.Text.RegularExpressions;

namespace VCManager.Core
{
    public class VideoFileParser
    {
        public static readonly Regex BasicRegex = new Regex(@"^[0-9]{2}[\-].+");

        public static VideoFilePart ParseFromSection(string part)
        {
            if (part == null || !BasicRegex.IsMatch(part))
                throw new ArgumentException();

            return ParsePart(part);
        }

        public static VideoFilePart ParseFromLecture(string part, bool inclueExt = true)
        {
            string regexStr = inclueExt ? @"^[0-9]{2}[\-].+.mp4$" : @"^[0-9]{2}[\-].";
            var regex = new Regex(regexStr);
            if (part == null || !regex.IsMatch(part))
                throw new ArgumentException();

            return ParsePart(part);
        }

        public static VideoFileName ParseFromFileNameInLongFormat(string fullFilePath)
        {
            string fileName = Path.GetFileName(fullFilePath);
            string[] parts = fileName.Split('-');
            return new VideoFileName(
                new VideoFilePart(int.Parse(parts[0]), parts[1]),
                new VideoFilePart(int.Parse(parts[2]), parts[3]));
        }



        private static VideoFilePart ParsePart(string part)
        {
            var number = int.Parse(part.Substring(0, 2));
            var name = part.Substring(3);

            return new VideoFilePart(number, name);
        }
    }
}