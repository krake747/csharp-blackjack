/// <summary>
/// A class that provides some convenience methods over the top of the console window for displaying text
/// with color.
/// </summary>
public static class ColoredConsole
{
    /// <summary>
    /// Writes a line of text in a specific color.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="color"></param>
    public static void WriteLine(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    /// <summary>
    /// Writes some text (no new line) in a specific color.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="color"></param>
    public static void Write(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ResetColor();
    }

    /// <summary>
    /// Asks the user a question and on the same line, gets a reply back, switching the user's response
    /// to a cyan color so it stands out.
    /// </summary>
    /// <param name="questionToAsk"></param>
    /// <returns></returns>
    public static string Prompt(string questionToAsk)
    {
        Write($"{questionToAsk} ", ConsoleColor.Gray);
        Console.ForegroundColor = ConsoleColor.Cyan;
        string input = Console.ReadLine() ?? ""; // If we got null, use empty string instead.
        Console.ResetColor();
        return input;
    }
}