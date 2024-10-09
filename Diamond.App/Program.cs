using Diamond.Services;

namespace Diamond.App
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            var diamond = new DiamondGenerator();
            var lines = diamond?.Create('E', '.');
            System.Console.WriteLine(lines);

        }
    }
}
