using CommandLine;

namespace ZipperFeli.CLI
{
    public class Options
    {
        [Option('u', "unZip", Required = false, HelpText = "Set the path to the zip file")]
        public string UnZip { get; set; }

        [Option('z', "zip", Required = false, HelpText = "Set the path to the zip directory")]
        public string Zip { get; set; }
    }
}
