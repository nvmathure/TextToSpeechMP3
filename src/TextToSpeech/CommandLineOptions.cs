using CommandLine;

namespace TextToSpeech
{
    public class CommandLineOptions
    {
        [Option('t', "inputText", Group = "Input")]
        public string InputText { get; set; }

        [Option('f', "inputFile", Group = "Input")]
        public string InputFile { get; set; }

        [Option('o', "outputFile", Group = "Output")]
        public string OutputFile { get; set; }

        [Option('p', "output", Group = "Output")]
        public string Output { get; set; }
    }
}
