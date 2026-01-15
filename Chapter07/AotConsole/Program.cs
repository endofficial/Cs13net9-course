using System.Reflection; //to use AssemblyName
using System.Reflection.Emit; //to use AssemblyBuilder
using System.Globalization;

WriteLine("This is an AOT compiled console app.");
WriteLine("Current Culture: {0}", CultureInfo.CurrentCulture.DisplayName);
WriteLine("OS version: {0}", Environment.OSVersion);

AssemblyBuilder ab = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("MyAssembly"), AssemblyBuilderAccess.Run);

WriteLine("Press any key to exit...");
ReadKey();