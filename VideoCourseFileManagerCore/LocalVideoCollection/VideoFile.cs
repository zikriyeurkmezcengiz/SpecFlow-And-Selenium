using System;
using System.IO;

namespace VCManager.Core
{
    public class VideoFile
    {
        private VideoFile(string fullFilePath, VideoFileName fileName)
        {
            FullFilePath = fullFilePath;
            FileName = fileName;
        }

        public string FullFilePath { get; }
        public VideoFileName FileName { get; }

        public static VideoFile CreateFromFullPath(string fullFilePath)
        {            
            var di = new DirectoryInfo(fullFilePath);
            return new VideoFile(fullFilePath,
                new VideoFileName(VideoFileParser.ParseFromSection(di.Parent?.Name),
                                  VideoFileParser.ParseFromLecture(di.Name)));
        }

        public static VideoFile CreateFromFileNameInLongFormat(string fullFilePath)
        {
            return new VideoFile(fullFilePath, VideoFileParser.ParseFromFileNameInLongFormat(fullFilePath));            
        }        
    }

    public class VideoFileName
    {
        public VideoFilePart Section { get; }
        public VideoFilePart Lecture { get; }

        public VideoFileName(VideoFilePart section, VideoFilePart lecture)
        {
            Section = section ?? throw new ArgumentNullException(nameof(section));
            Lecture = lecture ?? throw new ArgumentNullException(nameof(lecture));
        }
    }
}