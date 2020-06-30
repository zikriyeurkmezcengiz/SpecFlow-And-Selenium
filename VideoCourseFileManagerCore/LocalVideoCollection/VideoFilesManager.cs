using System;
using System.Collections.Generic;
using System.IO;
using CSharpFunctionalExtensions;

namespace VCManager.Core
{
    public static class VideoFileFormatter
    {
        public static string ToFullFormat(this VideoFileName fileName)
        {
            return fileName.Section + "-" + fileName.Lecture;
        }

        public static string ToLectureName(this VideoFileName fileName)
        {
            return fileName.Lecture.Name;
        }

        public static string ToFullLecture(this VideoFileName fileName)
        {
            return fileName.Lecture.ToString();
        }

        public static string ToFullSection(this VideoFileName fileName)
        {
            return fileName.Section.ToString();
        }

        public static string ToSectionLectureNoNumbers(this VideoFileName fileName)
        {
            return fileName.Section.Name + " - " + fileName.Lecture.Name;
        }
    }
    public class VideoFilesManager
    {      
        public static Dictionary<VideoFilePart, List<VideoFilePart>> Collect(string courseRootPath)
        {           
            var dict = new Dictionary<VideoFilePart, List<VideoFilePart>>();
            IEnumerable<string> files = Directory.EnumerateFiles(courseRootPath, "*.mp4", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                try
                {
                    var videoFile = VideoFile.CreateFromFullPath(file);
                    if (dict.ContainsKey(videoFile.FileName.Section))
                    {
                        dict[videoFile.FileName.Section].Add(videoFile.FileName.Lecture);
                    }
                    else
                    {
                        dict.Add(videoFile.FileName.Section, new List<VideoFilePart> {videoFile.FileName.Lecture});
                    }                    
                }
                catch (Exception ex)
                {
                    Logger.Write($"Error parsing file->{file}. Exception:{ex}");
                }
            }
            return dict;
        }

        public static List<VideoFile> Collect2(string courseRootPath)
        {
            var list = new List<VideoFile>();
            foreach (var file in Directory.EnumerateFiles(courseRootPath, "*.mp4", SearchOption.AllDirectories))
            {
                try
                {
                    list.Add(VideoFile.CreateFromFullPath(file));
                }
                catch (Exception ex)
                {
                    Logger.Write($"Error parsing file->{file}. Exception:{ex}");
                }
            }
            return list;
        }

        public static string CopyTmp(VideoFile videoFile, bool outlineAndConclusionWithSectionPrefixes = false)
        {
            string fileDir = Path.GetDirectoryName(videoFile.FullFilePath);
            string targetDir = fileDir + "\\tmp";

            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }

            string targetFile;

            if (IsOutlineOrConclusion(videoFile) && outlineAndConclusionWithSectionPrefixes)
            {
                targetFile = Path.Combine(targetDir, videoFile.FileName.ToSectionLectureNoNumbers());
            }
            else
            {
                targetFile = Path.Combine(targetDir, videoFile.FileName.Lecture.Name);
            }
            
            File.Copy(videoFile.FullFilePath, targetFile, true);

            return targetFile;
        }

        private static bool IsOutlineOrConclusion(VideoFile videoFile)
        {
            return string.Compare(Path.GetFileNameWithoutExtension(videoFile.FileName.Lecture.Name), "outline", StringComparison.OrdinalIgnoreCase) == 0 ||
                   string.Compare(Path.GetFileNameWithoutExtension(videoFile.FileName.Lecture.Name), "conclusion", StringComparison.OrdinalIgnoreCase) == 0;
        }

        public static Result RemoveSectionParts(string courseRootPath)
        {
            foreach (var file in Directory.EnumerateFiles(courseRootPath, "*.mp4", SearchOption.AllDirectories))
            {
                try
                {
                    var videoFileName = VideoFileParser.ParseFromFileNameInLongFormat(file);
                    string newFullFilePath = Path.Combine(Path.GetDirectoryName(file), videoFileName.Lecture.ToString());

                    File.Move(file, newFullFilePath);
                }
                catch (Exception ex)
                {                    
                    return Result.Fail($"Error parsing file->{file}. Exception:{ex}");
                }
            }
            return Result.Ok();
        }

        public static void DeleteTmpDir(string dir)
        {
            string tmpDir = dir + "\\tmp";
            if (Directory.Exists(tmpDir))
            {
                Directory.Delete(tmpDir);
            }
        }
    }
}