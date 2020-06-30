using System.Collections.Generic;

namespace VCManager.Core.StaticData
{
    public class CourseInfo
    {       
        public static Dictionary<CourseName, string> Folders = new Dictionary<CourseName, string>()
        {
            { CourseName.Wpf, @"Q:\OneDrive\Documents\FinalCoursesProduction\Udemy\01-Learn WPF with XAML From Scratch\" },
            { CourseName.Mvvm, @"Q:\OneDrive\Documents\FinalCoursesProduction\Udemy\02-MVVM in WPF Survival Guide From A to Z\" },
            { CourseName.Api, @"Q:\OneDrive\Documents\FinalCoursesProduction\Udemy\03-API in C# - The Best Practices of Design and Implementation\" },
            { CourseName.Modern, @"Q:\OneDrive\Documents\FinalCoursesProduction\Udemy\04-Modern .NET Ecosystem and .NET Core" },
            { CourseName.WhatsNew, @"Q:\OneDrive\Documents\FinalCoursesProduction\Udemy\05-What's New in C# 6, C# 7 and VS 2017" },
            { CourseName.UnitTesting, @"Q:\OneDrive\Documents\FinalCoursesProduction\Udemy\06-Learn Unit Testing with NUnit and C#" },
            { CourseName.Solid, @"Q:\OneDrive\Documents\FinalCoursesProduction\Udemy\07-Software Architecture - Meta and SOLID Principles" },
            { CourseName.DependencyInjection, @"Q:\OneDrive\Documents\FinalCoursesProduction\Udemy\08-Software Architecture - DI for C# Devs" },
            { CourseName.DateTime, @"Q:\OneDrive\Documents\FinalCoursesProduction\Udemy\09-Date and Time Fundamentals in .NET and SQL Server" },
            { CourseName.Puzzlers, @"Q:\OneDrive\Documents\FinalCoursesProduction\Udemy\10-C# Puzzles" },
            { CourseName.FunctionalProgramming, @"Q:\OneDrive\Documents\FinalCoursesProduction\Udemy\11-Functional Programming in C#" },
            { CourseName.TestDrivenDevelopment, @"Q:\OneDrive\Documents\FinalCoursesProduction\Udemy\12-TDD in C# From A to Z" },
            { CourseName.CleanCode, @"Q:\OneDrive\Documents\FinalCoursesProduction\Udemy\14-CleanCode" },
        };
    }

}
