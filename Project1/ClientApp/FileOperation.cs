using System;
using System.IO;

namespace ClientApp
{
    public static class FileOperation
    {
        public static string[] ReadFile(string path)
        {
            try
            {
                return File.ReadAllLines(path);
            }
            catch (Exception e)
            {
                throw new Exception("Bele bir fayl tapilmadi!");
            }
        }
        public static void WriteFile(string path, string[] texts)
        {
            try
            {
                File.WriteAllLines(path,texts);
            }
            catch (Exception e)
            {
                throw new Exception("Xeta bas verdi!");
            }
        }
    }
}