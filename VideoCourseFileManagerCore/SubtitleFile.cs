using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace VCManager.Core
{
    public class SubtitleFile
    {
        /// <summary>
        /// Sometimes, I encounter .srt files with lines
        /// which start from a timestamp and no text afterwards.
        /// Parsers and other programs don't like such files.
        /// This method removes such lines.
        /// </summary>
        /// <param name="filePath"></param>
        public static void FixEmptyEntries(string filePath)
        {
            var lines = File.ReadAllLines(filePath).ToList();
            for (int i = lines.Count - 1; i >= 0; i--)
            {
                if (IsTimeStamp(lines[i]) && i <= lines.Count - 1 && string.IsNullOrWhiteSpace(lines[i + 1]))
                    lines.RemoveAt(i);
            }
            File.WriteAllLines(filePath, lines);
        }

        private static bool IsTimeStamp(string str)
        {
            string pattern = "[0-9]{2}:[0-9]{2}:[0-9]{2}.[0-9]{3}.-->*";
            Regex regEx = new Regex(pattern);

            return regEx.IsMatch(str);
        }
    }
}
