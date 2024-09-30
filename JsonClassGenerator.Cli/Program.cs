using CommandLine;
using JsonClassGenerator.Cli.Commands;
using System.IO;
using Xamasoft.JsonClassGenerator.CodeWriterConfiguration;
using Xamasoft.JsonClassGenerator.CodeWriters;

namespace JsonClassGenerator.Cli
{
    internal class Program
    {
        static int Main(string[] args)
        {
            return CommandLine.Parser.Default.ParseArguments<CSharpToJsonOptions>(args)
  .MapResult(
    (CSharpToJsonOptions opts) => RunGenerateCsharpCodeCommand(opts),
            errs => 1);
        }

        private static int RunGenerateCsharpCodeCommand(CSharpToJsonOptions opts)
        {
            string input = File.ReadAllText(opts.JsonInputFile);

            var codeWriterConfig = new CSharpCodeWriterConfig();
            codeWriterConfig.UsePascalCase = opts.UsePascalCase;
            codeWriterConfig.UseNestedClasses = opts.UseNestedClasses;
            codeWriterConfig.AttributeLibrary = opts.AttributeLibrary;
            codeWriterConfig.NullValueHandlingIgnore = opts.NullValueHandlingIgnore;
            codeWriterConfig.AttributeUsage = opts.AttributeUsage;
            codeWriterConfig.OutputType = opts.OutputType;
            codeWriterConfig.OutputMembers = opts.OutputMembers;
            codeWriterConfig.ReadOnlyCollectionProperties = opts.ReadOnlyCollectionProperties;
            codeWriterConfig.AlwaysUseNullables = opts.AlwaysUseNullables;


            CSharpCodeWriter csharpCodeWriter = new CSharpCodeWriter(codeWriterConfig);

            var jsonClassGenerator = new Xamasoft.JsonClassGenerator.JsonClassGenerator();
            jsonClassGenerator.CodeWriter = csharpCodeWriter;
            string errorMessage;
            string returnVal = jsonClassGenerator.GenerateClasses(input, errorMessage: out errorMessage).ToString();
            if(string.IsNullOrEmpty(opts.CsharpOutputFile)) 
                Console.WriteLine(returnVal);
            if (string.IsNullOrEmpty(errorMessage) == false)
                return 1;

         

            
            return 0;
        }
    }
}
