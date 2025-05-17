using DotNetEnv;
using System.IO;

namespace MotoMappingApiDotnet.Src.WebApi.Utils
{
    public class Utils
    {
        public void LoadEnvFromRoot()
        {
            // Sobe dois níveis a partir do diretório atual
            var currentDirectory = Directory.GetCurrentDirectory(); // Ex: .../Src/WebApi
            var rootDirectory = Path.GetFullPath(Path.Combine(currentDirectory, @"..\..")); // Sobe 2 níveis
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
