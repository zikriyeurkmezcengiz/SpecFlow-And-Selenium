using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SkillShare
{
    class Program
    {
        static void Main(string[] args)
        {
            var skillShare = new AutoSkillShare();
            skillShare.UploadCourse();

            Console.ReadLine();
        }
    }

    
}
