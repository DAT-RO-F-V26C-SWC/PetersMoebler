// See https://aka.ms/new-console-template for more information
using PetersMoeblerLib.model;

Console.WriteLine("Hello, World!");

Product vare = new Product(1, "Jakobs hylde", 100);
Console.WriteLine(vare);

Product stol = new Chair(2, "Jakobs stol", 200, new List<string>() { "træ", "metal" }, 100, 50, 50);
Console.WriteLine(stol);

