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
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ForegroundColor = previousColor;
    }

    /// <summary>
    /// Writes a line of text in a specific color and a specific background color.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="color"></param>
    /// <param name="backgroundColor"></param>
    public static void WriteLine(string text, ConsoleColor color, ConsoleColor backgroundColor)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        ConsoleColor previousBackgroundColor = Console.BackgroundColor;
        Console.ForegroundColor = color;
        Console.BackgroundColor = backgroundColor;
        Console.WriteLine(text);
        Console.ForegroundColor = previousColor;
        Console.BackgroundColor = previousBackgroundColor;
    }

    /// <summary>
    /// Writes some text (no new line) in a specific color.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="color"></param>
    public static void Write(string text, ConsoleColor color)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ForegroundColor = previousColor;
    }

    /// <summary>
    /// Writes some text (no new line) in a specific color and a specific background color.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="color"></param>
    /// <param name="backgroundColor"></param>
    public static void Write(string text, ConsoleColor color, ConsoleColor backgroundColor)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        ConsoleColor previousBackgroundColor = Console.BackgroundColor;
        Console.ForegroundColor = color;
        Console.BackgroundColor = backgroundColor;
        Console.Write(text);
        Console.ForegroundColor = previousColor;
        Console.BackgroundColor = previousBackgroundColor;
    }

    /// <summary>
    /// Asks the user a question and on the same line, gets a reply back, switching the user's response
    /// to a cyan color so it stands out.
    /// </summary>
    /// <param name="questionToAsk"></param>
    /// <returns></returns>
    public static string Prompt(string questionToAsk)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(questionToAsk + " ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        string input = Console.ReadLine() ?? ""; // If we got null, use empty string instead.
        Console.ForegroundColor = previousColor;
        return input;
    }
}