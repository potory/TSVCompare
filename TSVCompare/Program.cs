namespace TSVCompare;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Enter the path to the first set of TSV files:");
        string folder1 = Console.ReadLine()!;

        Console.WriteLine("Enter the path to the second set of TSV files:");
        string folder2 = Console.ReadLine()!;

        Console.WriteLine("Enter the path to the output folder:");
        string outputFolder = Console.ReadLine()!;

        string[] files1 = Directory.GetFiles(folder1, "*.tsv");
        string[] files2 = Directory.GetFiles(folder2, "*.tsv");

        for (int i = 0; i < files1.Length; i++)
        {
            string file1 = files1[i];
            string file2 = files2[i];
            string outputFilePath = Path.Combine(outputFolder, Path.GetFileName(file1));

            CompareAndCopyMissingRows(file1, file2, outputFilePath);
        }

        Console.WriteLine("Comparison and copying completed.");
    }

    private static void CompareAndCopyMissingRows(string file1, string file2, string outputFilePath)
    {
        HashSet<string> lines1 = new HashSet<string>(File.ReadLines(file1));
        
        using StreamWriter writer = new StreamWriter(outputFilePath);
        foreach (string line2 in File.ReadLines(file2))
        {
            if (!lines1.Contains(line2))
            {
                writer.WriteLine(line2);
            }
        }
    }
}