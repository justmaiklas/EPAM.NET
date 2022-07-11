namespace ClassLibrary1
{
    public class HelloConcatenation
    {
        public static string FormatHelloMessage(string name)
        {
            return $"{DateTime.Now} Hello, {name}";
        }
    }
}