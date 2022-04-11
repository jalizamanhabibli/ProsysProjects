using System;
using System.Threading.Tasks;
using ServiceReference1;

namespace ClientApp
{
    public class Program
    {
        private static readonly string BaseRoot = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("bin"));
        private static readonly string ReadFileName = "in.txt";
        private static readonly string WriteFileName = "out.txt";
        static async Task Main(string[] args)
        {
            try
            {
                var texts = FileOperation.ReadFile(BaseRoot + ReadFileName);
                if (texts.Length < 10)
                {
                    Console.WriteLine("Fayldaki sozlerin sayi 10-dan azdir!");
                    return;
                }
                texts = await ReverseTextInArrWithService(texts);
                FileOperation.WriteFile(BaseRoot + WriteFileName, texts);
                Console.WriteLine("Successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private static async Task<string[]> ReverseTextInArrWithService(string[] texts)
        {
            using TextOperationServiceClient serviceClient = new TextOperationServiceClient();
            try
            {
                for (int i = 0; i < texts.Length; i++)
                {
                    texts[i] = await serviceClient.DoWorkAsync(texts[i]);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Xeta bash verdi!");
            }
            finally
            {
                serviceClient.CloseAsync();
            }

            return texts;
        }
    }
}
