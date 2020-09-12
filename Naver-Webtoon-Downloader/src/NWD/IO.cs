﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WRforest.NWD
{
#if Console
    public delegate void PrintDelegate(string msg);
    public delegate void LogDelegate(string msg);
#endif
#if WPF
    public delegate void PrintDelegate(string msg);
    public delegate void LogDelegate(string msg);
#endif
    class IO
    {
        /// <summary>
        /// 기본 출력 델리게이트
        /// </summary>
        public static PrintDelegate Print;
        /// <summary>
        /// 기본 로그 델리게이트
        /// </summary>
        public static LogDelegate Log;

#if Console
        public static void Write(string msg, ConsoleColor foreground)
        {
            Console.ForegroundColor = foreground;
            Console.Write(msg);
            Console.ForegroundColor = ConsoleColor.Black;
        }
#endif

        public static string ReadTextFile(string directory, string filename)
        {
            string buff;
            using (FileStream fs = new FileStream(string.Format("{0}\\{1}", directory, filename), FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                    buff = sr.ReadToEnd();
            }
            return buff;
        }
        public static void WriteTextFile(string directory, string filename, string data)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            using (FileStream fs = new FileStream(string.Format("{0}\\{1}", directory, filename), FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                    sw.Write(data);
            }
        }
        /// <summary>
        /// <paramref name="directory"/>의 <paramref name="filename"/>에 <paramref name="data"/>를 Write합니다. 이미 있는 파일이라면 덮어쓰고, <paramref name="directory"/>가 존재하지 않는다면 생성합니다 
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="filename"></param>
        /// <param name="data"></param>
        public static void WriteAllBytes(string directory, string filename, byte[] data)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            using (FileStream fs = new FileStream(string.Format("{0}\\{1}", directory, filename), FileMode.Create, FileAccess.Write))
            {
                fs.Write(data, 0, data.Length);
            }
        }
        public static void AppendToFile(string directory, string filename, string text)
        {
            using (StreamWriter sw = new StreamWriter(string.Format("{0}\\{1}", directory, filename), true))
                sw.Write(text);
        }
        /// <summary>
        /// 해당 <paramref name="directory"/>에 <paramref name="filename"/>이 존재하는지 확인합니다.
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static bool Exists(string directory, string filename)
        {
            return File.Exists(string.Format("{0}\\{1}", directory, filename));
        }
        /// <summary>
        /// 해당 파일이 존재하는지 확인합니다
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static bool Exists(string filepath)
        {
            return File.Exists(filepath);
        }

    }
}