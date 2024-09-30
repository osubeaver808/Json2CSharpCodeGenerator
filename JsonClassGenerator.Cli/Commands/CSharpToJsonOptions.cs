using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamasoft.JsonClassGenerator.Models;

namespace JsonClassGenerator.Cli.Commands
{
    [Verb("csharp", HelpText = "Generate CSharp code from Json file.")]
    internal class CSharpToJsonOptions
    {
        
        [Option('j', "json", Required = true, HelpText = "The Json File.")]
        public string JsonInputFile{ get; set; }
        [Option('o', "output", Required = false, HelpText = "The csharp file to output.If none is provided it will write to console.")]
        public string CsharpOutputFile { get; set; }
        [Option('p', "pascal-case", Required = false,Default =true, HelpText = "Use Pascal case for memeber names.")]

        public bool UsePascalCase { get; set; }
        [Option('c', "nested-class", Required = false, Default = true, HelpText = "Use nested classes.")]

        public bool UseNestedClasses { get; set; }
        [Option('l', "library", Required = false, Default = JsonLibrary.NewtonsoftJson, HelpText = "The library to use for options.")]

        public JsonLibrary AttributeLibrary { get; set; }
        [Option('i', "ignore", Required = false, Default = true, HelpText = "Ignore null values.")]

        public bool NullValueHandlingIgnore { get; set; }
        
        public JsonPropertyAttributeUsage AttributeUsage { get; set; }
        [Option('t', "type", Required = false, Default = OutputTypes.MutableClass, HelpText = "Output class type.")]

        public OutputTypes OutputType { get; set; }
        [Option('m', "member-type", Required = false, Default = OutputMembers.AsProperties, HelpText = "Output class members as properties or fields.")]

        public OutputMembers OutputMembers { get; set; }
        [Option('c', "collection", Required = false, Default = false, HelpText = "Read only collection type.")]

        public bool ReadOnlyCollectionProperties { get; set; }
        [Option('n', "nullable", Required = false, Default = true, HelpText = "Use nullable properties.")]

        public bool AlwaysUseNullables { get; set; }
    }
}
