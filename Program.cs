using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using CommandLine;

namespace ZipperFeli.CLI
{
    class Program
    {
        public static void Main(string[] args)
        {
            var result = Parser.Default.ParseArguments<Options>(args).WithParsed(Run);
        }

        private static void Run(Options options)
        {
            if (!string.IsNullOrEmpty(options.Zip))
            {
                if (!Directory.Exists(options.Zip))
                {
                    Console.WriteLine(options.UnZip + " does not exist");
                    return;
                }

                DirectoryInfo info = new DirectoryInfo(options.Zip);

                ZipFile.CreateFromDirectory(options.Zip, info.Parent.Name + $@"\{info.Name}.zip");
                return;
            }
            else if (!string.IsNullOrEmpty(options.UnZip))
            {
                if (!File.Exists(options.UnZip))
                {
                    Console.WriteLine(options.UnZip + " does not exist");
                    return;
                }

                FileInfo f = new FileInfo(options.UnZip);

                if (!Directory.Exists(f.DirectoryName + @"\UnZip"))
                {
                    Directory.CreateDirectory(f.DirectoryName + @"\UnZip");
                }

                ZipFile.ExtractToDirectory(options.UnZip, f.DirectoryName + @"\UnZip");
                return;
            }

            Console.WriteLine("You must set the UnZip [u] or the Zip [z] argument");
        }
    }
}
