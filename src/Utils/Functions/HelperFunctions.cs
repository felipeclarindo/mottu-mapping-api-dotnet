using DotNetEnv;
using System.IO;

namespace MotoMappingApiDotnet.Src.Utils.Functions
{
    public class HelperFunctions
    {

        public void LoadEnvFromRoot()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var rootDirectory = Path.GetFullPath(Path.Combine(currentDirectory, @"..\.."));
            var envPath = Path.Combine(rootDirectory, ".env");

            if (File.Exists(envPath))
            {
                Env.Load(envPath);
                Console.WriteLine($".env carregado de: {envPath}");
            }
            else
            {
                Console.WriteLine($".env NÃO encontrado em: {envPath}");
            }
        }
    }
}