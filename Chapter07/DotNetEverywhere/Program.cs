WriteLine("I can run everywhere!");
WriteLine($"OS version is: {Environment.OSVersion}");

if (OperatingSystem.IsMacOS())
{
    WriteLine("Running on macOS");
}
else if (OperatingSystem.IsWindowsVersionAtLeast(major: 10, build: 22000))
{
    WriteLine("Running on Windows 11");
}
else if (OperatingSystem.IsWindowsVersionAtLeast(major: 10))
{
    WriteLine("Running on Windows 10");
}
else
{
    WriteLine("I am unknown OS");
}
WriteLine("Press any kew to stop me.");
ReadKey(intercept: true); //serve per non visualizzare il carattere premuto
