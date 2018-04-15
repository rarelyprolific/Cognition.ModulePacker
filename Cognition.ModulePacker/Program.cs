using System;
using System.IO;

namespace Cognition.ModulePacker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--_--__---___--___-__-___--");
            Console.WriteLine("Cognition.ModulePacker v0.1");
            Console.WriteLine("_-___-----_-----___--_-__--");

            // If no command line arguments are passed, just show the usage help text and exit..
            if (args.Length == 0)
            {
                ShowHelp();
                return;
            }

            // ..Otherwise we'll expect to be passed the path to a module file as the first parameter
            string moduleFilename = args[0].ToString();

            // Pack and save the module
            string packedModule = PackModule(moduleFilename);
            string jsPackedModule = BuildJsForPackedModule(packedModule, moduleFilename);

            SavePackedModuleJavaScriptFile(jsPackedModule, moduleFilename);
        }

        /// <summary>
        /// Shows the help text
        /// </summary>
        private static void ShowHelp()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Packs music modules (e.g. ProTracker, FastTracker) into JavaScript for easy replaying");
            Console.WriteLine("   (Currently, we just base64 encode the module, shove it into a global JavaScript variable");
            Console.WriteLine("    named after the module filename and save it in a new JavaScript file. This works for");
            Console.WriteLine("    now but I may do something more clever in the future! :p)");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("USAGE:");
            Console.WriteLine("    Cognition.ModulePacker.exe [module file to pack]");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("EXAMPLE:");
            Console.WriteLine("    Cognition.ModulePacker.exe checknobankh.mod");
        }

        /// <summary>
        /// Base64 encodes a file into a string
        /// </summary>
        private static string PackModule(string filename)
        {
            //// TODO: Need to add error checking here! What happens when we can't read the file or it does not exist?
            var fileBytes = File.ReadAllBytes(filename);
            return Convert.ToBase64String(fileBytes);
        }

        /// <summary>
        /// Wraps the packed module string inside a JavaScript file
        /// </summary>
        private static string BuildJsForPackedModule(string packedModule, string originalFilename)
        {
            //// TODO: To generate a name for the JavaScript module variable, I'll just strip the extension from the original filename and use that.
            //// (Yes, this IS a bad idea! The filename may not be a sensible or compatible JavaScript variable name. I need to come back and do something better later!)
            string moduleName = Path.GetFileNameWithoutExtension(originalFilename);

            return $"var {moduleName} = '{packedModule}';";
        }

        /// <summary>
        /// Saves a packed module JavaScript file using the original module filename with a *.js suffix
        /// </summary>
        private static void SavePackedModuleJavaScriptFile(string jsPackedModule, string originalFilename)
        {
            string saveFilename = $"{originalFilename}.js";

            //// TODO: Need to add error checking here! What happens if we couldn't save the file?
            File.WriteAllText(saveFilename, jsPackedModule);
        }
    }
}
