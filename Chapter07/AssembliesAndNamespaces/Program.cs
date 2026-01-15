using Packt.Shared;
using System;
using System.Xml.Linq; //To use a XDocument

#region

XDocument doc = new();

string s1 = "Hello";
String s2 = "World";
WriteLine($"{s1} {s2}");

#endregion

#region Utilizzo il nuget info, usando il pacchetto creato e condiviso

Write("Enter a color value in hex: ");
string? hex = ReadLine();
WriteLine("Is {0} a valid color value? {1}", arg0: hex, arg1: hex.IsValidHex());

Write("Enter a XML element: ");
string? xmlTag = ReadLine();
WriteLine("Is {0} a valid color value? {1}", arg0: xmlTag, arg1: xmlTag.IsValidXmlTag());

Write("Enter a password: ");
string? password = ReadLine();
WriteLine("Is {0} a valid color value? {1}", arg0: password, arg1: password.IsValidPassword());

#endregion