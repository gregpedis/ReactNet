namespace ReactNet;

public static class ColorConsole
{
	public static void WriteLine(string value, ConsoleColor color)
	{
		var before = Console.ForegroundColor;
		Console.ForegroundColor = color;
		Console.WriteLine(value);
		Console.ForegroundColor = before;
	}

	public static void WriteLineHeader(string value)
	{
		var padding = new string('=', value.Length);

		WriteLine(padding, ConsoleColor.Gray);
		WriteLine(value, ConsoleColor.Gray);
		WriteLine(padding, ConsoleColor.Gray);
	}

	public static void WriteLineEffect(string value) =>
		WriteLine(value, ConsoleColor.Green);

	public static void WriteLineState(string value) =>
		WriteLine(value, ConsoleColor.DarkYellow);

	public static void WriteLineUser(string value) =>
		WriteLine(value, ConsoleColor.Red);
}
