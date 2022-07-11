using ClassLibrary1;

public class Program
{
    public static void Main(string[] args)
    {
        var username = string.Join("", args);
        Console.WriteLine(HelloConcatenation.FormatHelloMessage(username));
    }
}
